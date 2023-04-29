using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Context
{
    public class CounterAPIContext : DbContext
    {
        public CounterAPIContext(DbContextOptions<CounterAPIContext> options) : base(options)
        {
            // замість Database.EnsureCreated(); треба спочатку створювати міграцію, а потім прописувати update-database
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MYPC;Database=CounterAPI;Trusted_Connection=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.Personalization)
                    .WithOne(p => p.User)
                    .HasForeignKey<Personalization>(a => a.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Navigation(a => a.Personalization).AutoInclude();
                entity.Navigation(a => a.TemplateLists).AutoInclude();

            });

            modelBuilder.Entity<TemplateList>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TemplateLists)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Navigation(a => a.User).AutoInclude();
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.TemplateList)
                    .WithMany(p => p.Templates)
                    .HasForeignKey(a => a.TemplateListId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.TemplateStatistics)
                    .WithOne(p => p.Template)
                    .HasForeignKey<TemplateStatistics>(a => a.TemplateId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.TemplateSettings)
                    .WithOne(p => p.Template)
                    .HasForeignKey<TemplateSettings>(a => a.TemplateId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Personalization>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Personalizations)
                    .HasForeignKey(a => a.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Personalizations)
                    .HasForeignKey(a => a.ThemeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Navigation(a => a.Language).AutoInclude();
                entity.Navigation(a => a.Theme).AutoInclude();
            });
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TemplateList> TemplateLists { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateStatistics> TemplateStatistics { get; set; }
        public virtual DbSet<TemplateSettings> TemplateSettings { get; set; }
        public virtual DbSet<Personalization> Personalizations { get; set; }
        public virtual DbSet<ThemeList> UserThemes { get; set; }
        public virtual DbSet<LanguageList> UserLanguages { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }

    }
}
