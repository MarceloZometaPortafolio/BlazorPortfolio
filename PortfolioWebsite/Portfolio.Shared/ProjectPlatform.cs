using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectPlatform
    {
        public int id { get; set; }

        public int ProjectId { get; set; }
        public int LanguageId { get; set; }
        public Project Project { get; set; }
        public Platform Platform { get; set; } 
    }
}
