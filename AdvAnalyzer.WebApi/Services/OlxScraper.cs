using AdvAnalyzer.WebApi.Models;
using AdvAnalyzer.WebApi.Repositories;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Services
{
    public class OlxScraper : IOlxScraper
    {
        private IAdvertisementRepository _advertisementRepository;
        private ISearchQueryRepository _searchQueryRepository;
        private ILogger<OlxScraper> _logger;

        public OlxScraper(IAdvertisementRepository advertisementRepository, ISearchQueryRepository searchQueryRepository, ILogger<OlxScraper> logger)
        {
            _advertisementRepository = advertisementRepository;
            _searchQueryRepository = searchQueryRepository;
            _logger = logger;
        }

        public async Task TryParseOlx(SearchQuery searchQuery)
        {
            var browser = await LaunchBrowser();
            string totalCount = "0";
            var totalCountNumber = 0;
            var last52AdvertisementsUrl = new List<string>();
            int advertisementsPerPage = 52;
            List<string> pagesList = new List<string>();
            var searchResultsFromCurrentPage = new List<Advertisement>();
            bool isLastPageToScrap = false;

            try
            {
                _logger.Log(LogLevel.Information, DateTime.Now + "Start scrap: " + searchQuery.Name);
                var htmlAsTask = Load(searchQuery.Url, browser);
                htmlAsTask.Wait();
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(htmlAsTask.Result);

                if (searchQuery.IsInitialized)
                {
                    totalCount = htmlDoc.DocumentNode.SelectNodes(".//div[contains(@data-testid, 'total-count')]").FirstOrDefault().InnerText;
                    totalCountNumber = int.Parse(Regex.Match(totalCount, @"\d+").Value);
                    pagesList = CreatePagesList(totalCountNumber, searchQuery.Url);
                    last52AdvertisementsUrl = await _advertisementRepository.GetLast52AdvertisementsUrlBySearchQueryId(searchQuery.Id);

                }
                else
                {
                    pagesList = CreatePagesList(advertisementsPerPage, searchQuery.Url);
                    searchQuery.IsInitialized = true;
                    await _searchQueryRepository.Update(searchQuery);
                }

                var searchResults = new List<Advertisement>();
                for (int c = 0; c < pagesList.Count; c++)
                {
                    if (!isLastPageToScrap)
                    {
                        var htmlAsTask2 = Load(pagesList[c], browser);
                        htmlAsTask2.Wait();
                        var htmlDoc2 = new HtmlDocument();
                        htmlDoc2.LoadHtml(htmlAsTask2.Result);

                        var nodes = htmlDoc2.DocumentNode.SelectNodes("//div[contains(@data-cy, 'l-card')]//a");

                        var resultRiders = htmlDoc2.DocumentNode.SelectNodes("//div[contains(@data-cy, 'l-card')]//a").ToList();

                        for (int i = 0; i < resultRiders.Count; i++)
                        {

                            var priceNode = resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]/text()");
                            var price = 0;
                            if (priceNode != null)
                            {
                                if (resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]//text()").InnerText == "Zamienię")
                                {
                                    price = 0;
                                }
                                else
                                {
                                    price = int.Parse((resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]//text()")).InnerText.Trim().Replace("zł", "").Replace(" ", ""));

                                }
                            }

                            string[] locationAndDate = resultRiders[i].SelectNodes(".//p[contains(@data-testid, 'location-date')]").FirstOrDefault().InnerText.Split(" - ");

                            if (!locationAndDate[1].Contains("Odświeżono"))
                            {
                                var searchResult = new Advertisement()
                                {
                                    Url = resultRiders[i].GetAttributeValue("href", ""),
                                    ImgUrl = resultRiders[i].SelectNodes(".//div//div//div[1]//div[1]//div//img").FirstOrDefault().GetAttributeValue("src", ""),
                                    Title = resultRiders[i].SelectNodes(".//div//div//div[2]//div[1]//h6").FirstOrDefault().InnerText,
                                    Price = price,
                                    Location = locationAndDate[0],
                                    DateAdded = DateTime.Now,
                                    UserId = searchQuery.UserId,
                                    SearchQueryId = searchQuery.Id,
                                    IsSeen = false,
                                    IsFavorite = false
                                };
                                searchResultsFromCurrentPage.Add(searchResult);
                            }

                            ////uzyciu .// oznacza, ze szukamy wsrod dzieci, ale nie bezposrednio w poziomie nizej tylko tez w innych poziomach nizej
                            //Console.WriteLine(resultRiders[i].SelectNodes(".//p[contains(@data-testid, 'ad-price')]").FirstOrDefault().InnerText);
                        }

                        if (searchQuery.IsInitialized && searchResultsFromCurrentPage.Any(x => last52AdvertisementsUrl.Contains(x.Url)))
                        {
                            isLastPageToScrap = true;
                            searchResultsFromCurrentPage.RemoveAll(x => last52AdvertisementsUrl.Contains(x.Url));
                        }

                        foreach (var searchResult in searchResultsFromCurrentPage)
                        {
                            searchResults.Add(searchResult);
                        }
                    }
                }


                foreach (var advertisement in searchResults)
                {
                    await _advertisementRepository.InsertWithoutSave(advertisement);
                }

                await browser.CloseAsync();
                _logger.Log(LogLevel.Information, DateTime.Now + " finish scrap: " + searchQuery.Name);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
        }

        private async Task<string> Load(string url, Browser browser)
        {
            using (Page page = await browser.NewPageAsync())
            {
                await page.GoToAsync(url);
                await page.ScreenshotAsync(".\\somepage3.jpg", new ScreenshotOptions() { FullPage = true });
                return await page.GetContentAsync();
            }
        }

        private async Task<Browser> LaunchBrowser()
        {
            string[] args = { "--single-process", "--no-zygote", "--no-sandbox" };
            return await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = args,
                ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            });
        }

        private List<string> CreatePagesList(int totalCountNumber, string url)
        {
            List<string> pagesList = new List<string>();

            var pagesCount = totalCountNumber / 52 + 1;

            pagesList.Add(url);

            for (int i = 2; i <= pagesCount; i++)
            {
                pagesList.Add(url + "/?page=" + i);
            }

            return pagesList;
        }
    }
}
