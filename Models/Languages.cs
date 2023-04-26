using System.ComponentModel;

namespace CounterAPI.Models
{
    [ReadOnly(true)]
    public partial class Languages : IEntity
    {
        public int Id { get; set; }
        public string UkranianWord { get; set; } = string.Empty!;
        public string EnglishWord { get; set; } = string.Empty!;
    }
}
