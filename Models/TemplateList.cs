namespace CounterAPI.Models
{
    public partial class TemplateList : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Template>? Templates { get; set; } = new List<Template>();
    }
}
