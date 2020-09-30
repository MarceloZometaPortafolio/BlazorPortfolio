namespace Portfolio.Shared
{
    public class ProjectCategory
    {       
        public int id { get; set; }

        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public Project Project { get; set; }
        public Category Category { get; set; }
    }
}