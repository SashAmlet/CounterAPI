namespace CounterAPI.Models
{
    public partial class TemplateSettings
    {
        public int Id { get; set; }
        public int NumOfProblems { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public bool Fructions { get; set; }
    }
}
