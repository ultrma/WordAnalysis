using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAnalysis.DataAccess.Helpers
{
    public class FullTextSearchHelper
    {
        /// <summary>
        /// This helper function returns formated text which will be used in SQL full text search
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>string</returns>
        public static string GetQueryString(string s)
        {
            var sArray= s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // If s is a single string without space (i.e. Platt), we return in this format. 
            // "*Platt*"
            if (sArray.Length == 1)
                return @$"""*{s}*""";


            // If s has space(s) (i.e. Platt College), we split it by space and return in such format. 
            // "*Platt*" or "*College*"
            const int maxSize = 146; // have to keep 4 chars for prefix and posfix chars
            var result = string.Join(@"*"" or ""*", sArray);
            if(result.Length <= maxSize)
                return @$"""*{result}*""";
            else
                return @$"""*{s}*"""; // If the size of query exceeds 150 chars, we just send orginal string back.
        }
    }
}
