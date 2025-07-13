using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewelery.Models
{
    public class HomeVM
    {
        public List<Ad> LastAdded { get; set; }
        public List<Ad> ReviewAds { get; set; }
        public List<Ad> Search { get; set; }
    }
}