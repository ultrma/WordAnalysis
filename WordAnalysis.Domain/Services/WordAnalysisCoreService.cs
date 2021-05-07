using System;
using System.Linq;
using System.Threading.Tasks;
using WordAnalysis.Domain.Models;

namespace WordAnalysis.Domain.Services
{
    public class WordAnalysisCoreService : IWordAnalysisCoreService
    {
        private readonly IWordAnalysisDataService _dataService;

        public WordAnalysisCoreService(IWordAnalysisDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Populate alias records
        /// </summary>
        /// <returns></returns>
        public async Task PopulateAliasRecords()
        {
            try
            {
                // 01. Get last advertiser.
                // So we can lookup duplicated ones per advertiser.
                var lastAdvertiser = await _dataService.GetLastAdvertiser();

                // Looping advertiser one by one
                for (int i = 1; i <= lastAdvertiser.Id; i++)
                {
                    // 02. Populate alias name per advertiser
                    var advertiser = await _dataService.GetAdvertiser(i);
                    Console.WriteLine($"Looking for alias associated with {advertiser.Name}.");
                    var duplicatedAdvertiserBLLs = await _dataService.GetDuplicatedAdvertisers(advertiser.Name);


                    // 03. Save records into Alias table
                    if (duplicatedAdvertiserBLLs != null && duplicatedAdvertiserBLLs.Any())
                    {
                        Console.WriteLine($"Inserting {duplicatedAdvertiserBLLs.Count} records into alias table.");
                        var aliasList = duplicatedAdvertiserBLLs
                            .Select(da => new AliasBLL { Advertiser = advertiser.Name , Name = da.Key, Rank = da.Rank }).ToList();
                        if (aliasList.Any())
                            await _dataService.AddAliasList(aliasList);
                    }

                    Console.WriteLine($"Progress: {i}/{lastAdvertiser.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
