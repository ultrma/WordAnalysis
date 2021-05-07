using System.Collections.Generic;
using System.Threading.Tasks;
using WordAnalysis.Domain.Models;

namespace WordAnalysis.Domain.Services
{
    public interface IWordAnalysisDataService
    {
        /// <summary>
        /// Add records into Alias table
        /// </summary>
        /// <param name="aliasBLLs">List<AliasBLL></param>
        /// <returns>void</returns>
        Task AddAliasList(List<AliasBLL> aliasBLLs);
        /// <summary>
        /// Get advertiser record by Advertiser Id
        /// </summary>
        /// <param name="Id">int</param>
        /// <returns>AdvertiserBLL</returns>
        Task<AdvertiserBLL> GetAdvertiser(int Id);
        /// <summary>
        /// Get duplicated advertisers
        /// </summary>
        /// <param name="advertiser">string</param>
        /// <returns>List<DuplicatedAdvertiserBLL></returns>
        Task<List<DuplicatedAdvertiserBLL>> GetDuplicatedAdvertisers(string advertiser);
        /// <summary>
        /// Get last Advertiser
        /// </summary>
        /// <returns>AdvertiserBLL</returns>
        Task<AdvertiserBLL> GetLastAdvertiser();
    }
}