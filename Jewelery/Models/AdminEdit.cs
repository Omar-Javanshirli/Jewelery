using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jewelery.Models;
namespace Jewelery.Models
{
    public class AdminEdit
    {
        public Ad Ad { get; set; }

        public List<MenuItemLanguage> menuItems { get; set; }
        public List<CategoryLanguage> menuCategories { get; set; }
        public List<SubCategoryLanguage> subCategories { get; set; }
        public List<SubSubCategoryLanguage> subSubCategories { get; set; }
    }
}