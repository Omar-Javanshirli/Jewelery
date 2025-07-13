using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewelery.Models
{
    public class DetailedVM
    {
        public Ad Ad { get; set; }
        public List<Ad> LastAdded { get; set; }
        public List<Ad> SameAds{ get; set; }
    }
}