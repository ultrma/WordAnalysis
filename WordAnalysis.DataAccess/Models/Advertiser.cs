using System;
using System.Collections.Generic;

#nullable disable

namespace WordAnalysis.DataAccess.Models
{
    /// <summary>
    /// Entity model for Advertiser table
    /// </summary>
    public partial class Advertiser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
