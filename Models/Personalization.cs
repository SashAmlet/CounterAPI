namespace CounterAPI.Models
{
    public partial class Personalization
    {
        public int Id { get; set; }
        public bool Notifications { get; set; }
        public int LanguageId { get; set; }
        public LanguageList? Language { get; set; }
        public int ThemeId { get; set; }
        public ThemeList? Theme { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
