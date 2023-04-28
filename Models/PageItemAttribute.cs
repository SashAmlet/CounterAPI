using System.ComponentModel;

namespace CounterAPI.Models
{
    public class PageItemAttribute: IEntity
    {
        public int Id { get; set; }
        public string FirstWord { get; set; } = null!;
        public string SecondWord { get; set; } = null!;
        public int PageItemId { get; set; }
        public PageItem? PageItem { get; set; } 
    }
}
