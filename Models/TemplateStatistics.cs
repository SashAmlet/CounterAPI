namespace CounterAPI.Models
{
    public partial class TemplateStatistics : IEntity
    {
        public int Id { get; set; }
        public int NumOfSolved { get; set; }
        public int NumOfUnsolved { get; set; }
        public int TemplateId { get; set; }
        public Template? Template { get; set; }
    }
}
