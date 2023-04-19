namespace CounterAPI.Models
{
    public partial class Language
    {
        public int Id { get; set; }
        public string? Ukranian { get; set; }
        public string? English { get; set; }
        public int PersonalizationId { get; set; }
        public Personalization? Personalization { get; set; }
    }
}
