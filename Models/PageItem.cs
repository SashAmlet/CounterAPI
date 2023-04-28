using System.ComponentModel;

namespace CounterAPI.Models
{
    public class PageItem: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CssClass { get; set; }
        public string? Value { get; set; }
        public string? Text { get; set; }
        public string? InsertBeforeId { get; set; }
        public int? ParentId { get; set; }
        public PageItem? Parent { get; set; }
        public IEnumerable<PageItem>? Children { get; set; }
        public IEnumerable<PageItemAttribute>? Attributes { get; set; }
        public IEnumerable<EventListener>? EventListeners { get; set; }
    }
}
