using AdvAnalyzer.WebApi.Dtos;
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
        private ILogger<OlxScraper> _logger;

        public OlxScraper(IAdvertisementRepository advertisementRepository, ILogger<OlxScraper> logger)
        {
            _advertisementRepository = advertisementRepository;
            _logger = logger;
        }

        public async Task<OlxScraperResultDto> TryParseOlx(SearchQuery searchQuery, List<string> last52AdvertisementsUrl)
        {
            string totalCount = "0";
            var totalCountNumber = 0;
            int advertisementsPerPage = 52;
            List<string> pagesList = new List<string>();
            var searchResults = new List<Advertisement>();
            Notification notification = null;
            bool isLastPageToScrap = false;
            string[] args = { "--no-zygote", "--no-sandbox", "--start-maximized" };
            OlxScraperResultDto olxScraperResult = new OlxScraperResultDto();

            try
            {
                using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = args,
                    ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                    DefaultViewport = null
                }))
                {
                    _logger.Log(LogLevel.Information, DateTime.Now + "Start scrap: " + searchQuery.Name);
                    var htmlAsTask = Load(searchQuery.Url, browser, searchQuery.Id);
                    htmlAsTask.Wait();
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(htmlAsTask.Result);

                    if (searchQuery.IsInitialized)
                    {
                        totalCount = htmlDoc.DocumentNode.SelectNodes(".//div[contains(@data-testid, 'total-count')]").FirstOrDefault().InnerText;
                        totalCountNumber = int.Parse(Regex.Match(totalCount, @"\d+").Value);
                        pagesList = CreatePagesList(totalCountNumber, searchQuery.Url);
                    }
                    else
                    {
                        pagesList = CreatePagesList(advertisementsPerPage, searchQuery.Url);
                        olxScraperResult.SearchQueryId = searchQuery.Id;
                        olxScraperResult.UpdateSearchQueryIsInitialized = true;
                    }

                    for (int c = 0; c < pagesList.Count; c++)
                    {
                        _logger.Log(LogLevel.Information, DateTime.Now + "Start Search Query: " + searchQuery.Id + " " + searchQuery.Name + "Page: " + (c + 1));

                        var searchResultsFromCurrentPage = new List<Advertisement>();

                        if (!isLastPageToScrap)
                        {
                            var htmlAsTask2 = Load(pagesList[c], browser, searchQuery.Id);
                            htmlAsTask2.Wait();
                            var htmlDoc2 = new HtmlDocument();
                            htmlDoc2.LoadHtml(htmlAsTask2.Result);

                            var nodes = htmlDoc2.DocumentNode.SelectNodes("//div[contains(@data-cy, 'l-card')]//a");

                            var resultRiders = htmlDoc2.DocumentNode.SelectNodes("//div[contains(@data-cy, 'l-card')]//a").ToList();

                            for (int i = 0; i < resultRiders.Count; i++)
                            {

                                var priceNode = resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]/text()");
                                double price = 0;
                                if (priceNode != null)
                                {
                                    if (resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]//text()").InnerText == "Zamienię")
                                    {
                                        price = 0;
                                    } 
                                    else if(resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]//text()").InnerText == "Za darmo")
                                    {
                                        price = -1;
                                    }
                                    else
                                    {
                                        price = double.Parse((resultRiders[i].SelectSingleNode(".//p[contains(@data-testid, 'ad-price')]//text()")).InnerText.Trim().Replace("zł", "").Replace(" ", ""));
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
                            _logger.Log(LogLevel.Information, DateTime.Now + "Finish Search Query: " + searchQuery.Id + " " + searchQuery.Name + "Page: " + (c + 1));
                        }
                    }
                    if (searchResults.Count > 0 && searchQuery.IsInitialized == true)
                    {
                        notification = CreateNotification(searchQuery.Name, searchQuery.Id, searchQuery.UserId, searchResults.Count);
                    }

                    if (searchQuery.IsInitialized == false)
                    {
                        searchResults.ForEach(x => x.IsAddedAtFirstIteration = true);
                    }

                    olxScraperResult.Advertisements = searchResults;
                    olxScraperResult.Notification = notification;

                    _logger.Log(LogLevel.Information, DateTime.Now + " finish scrap: " + searchQuery.Name);
                }
                return olxScraperResult;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        private async Task<string> Load(string url, Browser browser, int searchQueryId)
        {
            using (Page page = await browser.NewPageAsync())
            {
                await page.GoToAsync(url);
                await page.ScreenshotAsync(".\\somepage" + searchQueryId + ".jpg", new ScreenshotOptions() { FullPage = true });
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

            var pagesCount = totalCountNumber / 52;

            if (totalCountNumber % 52 != 0) pagesCount += 1;

            pagesList.Add(url);

            for (int i = 2; i <= pagesCount; i++)
            {
                pagesList.Add(url + "&page=" + i);
            }

            return pagesList;
        }

        private Notification CreateNotification(string searchQueryName, int searchQueryId, int userId, int newAdvertisementsCount)
        {
            return new Notification() { Message = newAdvertisementsCount + " new advertisements from " + searchQueryName, DateAdded = DateTime.Now, IsSeen = false, UserId = userId, SearchQueryId = searchQueryId };
        }
    }
}
