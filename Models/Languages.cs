namespace CounterAPI.Models
{
    public partial class Languages
    {
        public int Id { get; set; }
        public string UkranianWord { get; set; } = string.Empty!;
        public string EnglishWord { get; set; } = string.Empty!;
    }
}
