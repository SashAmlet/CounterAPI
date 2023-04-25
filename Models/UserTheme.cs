namespace CounterAPI.Models
{
    public partial class UserTheme
    {
        public int Id { get; set; }
        public string ThemeWord { get; set; } = string.Empty!;
        public Personalization? Personalization { get; set; }
    }
}
