using HamroKitab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamroKitab.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM ()
        {
            Publishers = new List<Publisher>();
            Author = new List<Author>();
            Category = new List<Category>();
        }
        public List<Publisher> Publishers { get; set; }
        public List<Author> Author { get; set; }
        public List<Category> Category { get; set; }

    }
}
