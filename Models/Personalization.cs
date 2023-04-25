namespace CounterAPI.Models
{
    public partial class Personalization
    {
        public int Id { get; set; }
        public bool Notifications { get; set; }
        public int ThemeId { get; set; }
        public int LanguageId { get; set; }
        public UserTheme? Theme { get; set; } = null!;
        public UserLanguage? Language { get; set; } = null!;
        public User? User { get; set; }
    }
}
