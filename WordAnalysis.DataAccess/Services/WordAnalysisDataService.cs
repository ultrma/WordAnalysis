using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordAnalysis.DataAccess.Helpers;
using WordAnalysis.DataAccess.Models;
using WordAnalysis.Domain.Models;
using WordAnalysis.Domain.Services;

namespace WordAnalysis.DataAccess.Services
{
    public class WordAnalysisDataService : IWordAnalysisDataService
    {
        private readonly WordAnalysisContext _context;
        public WordAnalysisDataService(WordAnalysisContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get last advertiser from Advertiser table
        /// </summary>
        /// <returns>AdvertiserBLL</returns>
        public async Task<AdvertiserBLL> GetLastAdvertiser()
        {
            var advertiser = await _context.Advertisers.OrderByDescending(a => a.Id).FirstOrDefaultAsync();
            if (advertiser != null)
                return new AdvertiserBLL { Id = advertiser.Id, Name = advertiser.Name };
            return null;
        }

        /// <summary>
        /// Get Advertiser by AdvertiserId
        /// </summary>
        /// <param name="Id">int</param>
        /// <returns>AdvertiserBLL</returns>
        public async Task<AdvertiserBLL> GetAdvertiser(int Id)
        {
            var advertiser = await _context.Advertisers.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (advertiser != null)
                return new AdvertiserBLL { Id = advertiser.Id, Name = advertiser.Name };
            return null;
        }

        /// <summary>
        /// Add alias records into Alias table
        /// </summary>
        /// <param name="aliasBLLs">List<AliasBLL></param>
        /// <returns>void</returns>
        public async Task AddAliasList(List<AliasBLL> aliasBLLs)
        {
            List<Alias> aliasList = aliasBLLs.Select(a => new Alias { Name = a.Name, Advertiser =a.Advertiser, Rank = a.Rank }).ToList();
            await _context.Aliases.AddRangeAsync(aliasList);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get duplicated advertisers.
        /// This invokes a stored procedure in MS SQL for fetching similar advertisers.
        /// </summary>
        /// <param name="advertiser">string</param>
        /// <returns>List<DuplicatedAdvertiserBLL></returns>
        public async Task<List<DuplicatedAdvertiserBLL>> GetDuplicatedAdvertisers(string advertiser)
        {
            // Get full text query string from helper function.
            var query = FullTextSearchHelper.GetQueryString(advertiser);

            // Get records from stored procedure "GetDuplicatedNames"
            var duplicatedAdvertisers = await _context
               .DuplicatedAdvertisers
               .FromSqlRaw("exec [dbo].[GetDuplicatedNames] @p0, @p1", query, advertiser)
               .ToListAsync();

            // Transform and return these records to BLL objects
            var result = duplicatedAdvertisers
                .OrderByDescending(da=>da.Rank)
                .Select(da => new DuplicatedAdvertiserBLL
            {
                Id = da.Id,
                Key = da.Key,
                Rank = da.Rank
            }).ToList();

            return result;
        }

        
    }
}
