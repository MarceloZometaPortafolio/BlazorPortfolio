using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectTechnology
    {
        public int id { get; set; }

        public int ProjectId { get; set; }
        public int LanguageId { get; set; }
        public Project Project { get; set; }
        //public Technology Technology { get; set; }
    }
}
