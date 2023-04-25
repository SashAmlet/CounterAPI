using System.ComponentModel;

namespace CounterAPI.Models
{
    public partial class Themes
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        public string WhiteWord { get; set; } = string.Empty!;
        public string DarkWord { get; set; } = string.Empty!;
    }
}
