using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Context
{
    public class PageItemsContext: DbContext
    {
        public PageItemsContext(DbContextOptions<PageItemsContext> options) : base(options)
        {
            // замість Database.EnsureCreated(); треба спочатку створювати міграцію, а потім прописувати update-database
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MYPC;Database=CounterAPI;Trusted_Connection=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageItem>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d=>d.Parent)
                    .WithMany(p=>p.Children)
                    .HasForeignKey(p=>p.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Navigation(a => a.Attributes).AutoInclude();

            });

            modelBuilder.Entity<PageItemAttribute>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.PageItem)
                    .WithMany(p => p.Attributes)
                    .HasForeignKey(a => a.PageItemId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }
        public virtual DbSet<PageItem> PageItems { get; set; }
        public virtual DbSet<PageItemAttribute> PageItemAttributes { get; set; }

    }
}
