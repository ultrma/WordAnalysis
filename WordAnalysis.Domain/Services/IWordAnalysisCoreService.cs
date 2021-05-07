using System.Threading.Tasks;

namespace WordAnalysis.Domain.Services
{
    public interface IWordAnalysisCoreService
    {
        /// <summary>
        /// Populate alias records
        /// </summary>
        /// <returns></returns>
        Task PopulateAliasRecords();
    }
}