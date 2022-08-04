using AdvAnalyzer.WebApi.Dtos;
using AdvAnalyzer.WebApi.Models;
using AdvAnalyzer.WebApi.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi.Services
{
    public class OlxScrapperScheduler5min : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger _logger;

        public OlxScrapperScheduler5min(IServiceScopeFactory serviceScopeFactory, ILogger<OlxScrapperScheduler5min> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    var searchQueries = new List<SearchQuery>();
            //    var tasks = new List<Task>();
            //    using (var scope = _serviceScopeFactory.CreateScope())
            //    {
            //        var searchQueryRepository = scope.ServiceProvider.GetRequiredService<ISearchQueryRepository>();

            //        searchQueries = await searchQueryRepository.GetAllByRefreshFrequencyInMinutes(5);
            //    }

            //    _logger.Log(LogLevel.Information, "start scraping");
            //    using (var scope = _serviceScopeFactory.CreateScope())
            //    {
            //        foreach (var searchQuery in searchQueries)
            //        {
            //            var advertisementRepository = scope.ServiceProvider.GetRequiredService<IAdvertisementRepository>();
            //            var taskGetLast52 = advertisementRepository.GetLast52AdvertisementsUrlBySearchQueryId(searchQuery.Id);
            //            await Task.WhenAll(taskGetLast52);
            //            var result52 = ((Task<List<string>>)taskGetLast52).Result;
            //            var olxScraper = scope.ServiceProvider.GetRequiredService<IOlxScraper>();
            //            tasks.Add(olxScraper.TryParseOlx(searchQuery, result52));
            //        }
            //        _logger.Log(LogLevel.Information, "Waiting for tasks...");

            //        await Task.WhenAll(tasks);
            //        _logger.Log(LogLevel.Information, "Tasks are finished !");

            //        List<OlxScraperResultDto> results = new List<OlxScraperResultDto>();
            //        List<Advertisement> advertisementsToInsert = new List<Advertisement>();
            //        List<Notification> notificationsToInsert = new List<Notification>();
            //        List<SearchQuery> searchQueriesToUpdate = new List<SearchQuery>();

            //        foreach (var task in tasks)
            //        {
            //            var result = ((Task<OlxScraperResultDto>)task).Result;

            //            if (result != null)
            //            {
            //                advertisementsToInsert.AddRange(result.Advertisements);
            //                if (result.Notification != null) notificationsToInsert.Add(result.Notification);
            //                if (result.UpdateSearchQueryIsInitialized == true)
            //                {
            //                    SearchQuery searchQueryToUpdate = searchQueries.Find(x => x.Id == result.SearchQueryId);
            //                    searchQueryToUpdate.IsInitialized = true;
            //                    searchQueriesToUpdate.Add(searchQueryToUpdate);
            //                }

            //                results.Add(result);
            //            }
            //        }
            //        await Task.WhenAll(SaveResults(scope, advertisementsToInsert, notificationsToInsert, searchQueriesToUpdate));
            //    }

            //    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            //    _logger.Log(LogLevel.Information, "finish scraping");
            }
        }

        //private async Task SaveResults(IServiceScope scope, List<Advertisement> advertisements, List<Notification> notifications, List<SearchQuery> searchQueries)
        //{

        //    var searchQueryRepository = scope.ServiceProvider.GetRequiredService<ISearchQueryRepository>();
        //    var advertisementRepository = scope.ServiceProvider.GetRequiredService<IAdvertisementRepository>();
        //    var notificationRepository = scope.ServiceProvider.GetRequiredService<INotificationRepository>();

        //    await advertisementRepository.InsertMany(advertisements);
        //    await notificationRepository.InsertMany(notifications);

        //    foreach (var searchQueryToUpdate in searchQueries)
        //    {
        //        await searchQueryRepository.Update(searchQueryToUpdate);
        //    }
        //}
    //}
}
