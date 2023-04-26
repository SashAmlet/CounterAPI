namespace CounterAPI.Models
{
    public partial class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PersonalizationId { get; set; }
        public IEnumerable<TemplateList>? TemplateLists { get; set; } = new List<TemplateList>();
        public Personalization? Personalization { get; set; }

    }
}
