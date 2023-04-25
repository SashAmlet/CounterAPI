namespace CounterAPI.Models
{
    public partial class UserLanguage
    {
        public int Id { get; set; }
        public string LanguageWord { get; set; } = string.Empty!;
        public Personalization? Personalization { get; set; }
    }
}
