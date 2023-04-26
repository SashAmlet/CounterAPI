namespace CounterAPI.Models
{
    public partial class Template : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Word { get; set; } = null!;
        public int TemplateListId { get; set; }
        public TemplateList? TemplateList { get; set; }
        public int TemplateStatisticsId { get; set; }
        public TemplateStatistics? TemplateStatistics { get; set; }
        public int TemplateSettingsId { get; set; }
        public TemplateSettings? TemplateSettings { get; set; }
    }
}
