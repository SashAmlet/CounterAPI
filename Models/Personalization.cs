namespace CounterAPI.Models
{
    public partial class Personalization
    {
        public int Id { get; set; }
        public bool Notifications { get; set; }
        public string Theme { get; set; } = null!;
        public string Language { get; set; } = null!;
        public User? User { get; set; }
    }
}
