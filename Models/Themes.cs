using System.ComponentModel;

namespace CounterAPI.Models
{
    [ReadOnly(true)]
    public partial class Themes : IEntity
    {
        public int Id { get; set; }
        public string WhiteWord { get; set; } = string.Empty!;
        public string DarkWord { get; set; } = string.Empty!;
    }
}
