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

            while (!stoppingToken.IsCancellationRequested)
            {
                var searchQueries = new List<SearchQuery>();
                var tasks = new List<Task>();
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var searchQueryRepository = scope.ServiceProvider.GetRequiredService<ISearchQueryRepository>();

                    searchQueries = await searchQueryRepository.GetAllByRefreshFrequencyInMinutes(5);
                }

                _logger.Log(LogLevel.Information, "start scraping");
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    foreach (var searchQuery in searchQueries)
                    {
                        var olxScraper = scope.ServiceProvider.GetRequiredService<IOlxScraper>();

                        tasks.Add(olxScraper.TryParseOlx(searchQuery));
                    }
                    await Task.WhenAll(tasks);
                    var searchQueryRepository = scope.ServiceProvider.GetRequiredService<ISearchQueryRepository>();
                    var advertisementRepository = scope.ServiceProvider.GetRequiredService<IAdvertisementRepository>();
                    var notificationRepository =  scope.ServiceProvider.GetRequiredService<INotificationRepository>();

                    await searchQueryRepository.SaveChangesAsync();
                    await advertisementRepository.SaveChangesAsync();
                    await notificationRepository.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                _logger.Log(LogLevel.Information, "finish scraping");
            }
        }
    }
}
