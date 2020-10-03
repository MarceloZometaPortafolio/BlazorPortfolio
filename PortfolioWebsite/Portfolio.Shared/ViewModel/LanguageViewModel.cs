using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Shared.ViewModel
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }

        public LanguageViewModel(Language language)
        {
            Id = language.Id;
            Name = language.Name;

            Projects = new List<Project>();

            //foreach(var pl in language.ProjectLanguages){
            //    Projects.Add(pl.Project);
            //}

            Projects = language.ProjectLanguages.Select(pl => pl.Project).ToList();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public IList<Project> Projects { get; set; }
    }
}
