using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Shared.ViewModel
{
    public class ProjectViewModel
    {
        public ProjectViewModel() { }

        public ProjectViewModel(Project project)
        {
            Id = project.id;
            Title = project.Title;
            Design = project.Design;
            Requirement = project.Requirement;
            Languages = new List<BasicLanguage>();

            //foreach(var pl in language.ProjectLanguages){
            //    Projects.Add(pl.Project);
            //}

            //Languages = project.ProjectLanguages.Select(pl => pl.Project).ToList();
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Design { get; private set; }
        public string Requirement { get; private set; }
        public IList<BasicLanguage> Languages { get; set; }
    }
}
