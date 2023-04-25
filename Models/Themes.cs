namespace CounterAPI.Models
{
    public partial class Themes
    {
        public int Id { get; set; }
        public string WhiteWord { get; set; } = string.Empty!;
        public string DarkWord { get; set; } = string.Empty!;
        public Personalization? Personalization { get; set; }
    }
}
