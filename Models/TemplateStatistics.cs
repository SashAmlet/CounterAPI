namespace CounterAPI.Models
{
    public partial class TemplateStatistics
    {
        public int Id { get; set; }
        public int NumOfSolved { get; set; }
        public int NumOfUnsolved { get; set; }
        public Template? Template { get; set; }
    }
}
