namespace CounterAPI.Models
{
    public partial class Theme
    {
        public int Id { get; set; }
        public string? White { get; set; }
        public string? Dark { get; set; }
        public int PersonalizationId { get; set; }
        public Personalization? Personalization { get; set; }
    }
}
