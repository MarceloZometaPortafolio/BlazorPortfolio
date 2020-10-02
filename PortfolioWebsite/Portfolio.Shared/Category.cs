using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }

        public List<ProjectLanguage> ProjectCategories { get; set; }
    }
}
