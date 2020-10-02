namespace Portfolio.Shared
{
    public class ProjectLanguage
    {       
        public int id { get; set; }

        public int ProjectId { get; set; }
        public int LanguageId { get; set; }
        public Project Project { get; set; }
        public Language Language{ get; set; }
    }
}