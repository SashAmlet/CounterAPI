using System.ComponentModel;

namespace CounterAPI.Models
{
    public partial class ThemeList
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public ICollection<Personalization>? Personalizations { get; set; } = new List<Personalization>();
    }
}
