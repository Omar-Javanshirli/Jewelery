using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jewelery.Models;
namespace Jewelery.Areas.Crm.Data
{
    public class DashboardVM
    {
        public List<Ad> Ads { get; set; }
        public int TotalAds { get; set; }
        public int ActiveAds { get; set; }
        public int WaitingAds { get; set; }
        public int NewMessages { get; set; }
        public int TotalUsers { get; set; }
    }
}