using System.ComponentModel;

namespace CounterAPI.Models
{
    [ReadOnly(true)]
    public partial class LanguageList: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public ICollection<Personalization>? Personalizations { get; set; } = new List<Personalization>();

    }
}
