using System;
using System.Collections.Generic;

#nullable disable

namespace WordAnalysis.DataAccess.Models
{
    /// <summary>
    /// Entity model for Alias table
    /// </summary>
    public partial class Alias
    {
        public int Id { get; set; }
        public string Advertiser { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}
