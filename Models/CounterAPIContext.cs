﻿using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Models
{
    public class CounterAPIContext: DbContext
    {
        public CounterAPIContext(DbContextOptions<CounterAPIContext> options): base(options)
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

                entity.HasIndex(x=>x.PersonalizationId).IsUnique();

                entity.HasOne(d => d.Personalization)
                    .WithOne(p=>p.User)
                    .HasForeignKey<User>(a => a.PersonalizationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(d => d.TemplateLists)
                    .WithOne(p => p.User)
                    .HasForeignKey(b=>b.UserId);

            });

            modelBuilder.Entity<TemplateList>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasMany(d=>d.Templates)
                    .WithOne(p=>p.TemplateList)
                    .HasForeignKey(a=>a.TemplateListId);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasIndex(a => a.TemplateSettingsId).IsUnique();
                entity.HasIndex(a => a.TemplateStatisticsId).IsUnique();

                entity.HasOne(d => d.TemplateStatistics)
                    .WithOne(p=>p.Template)
                    .HasForeignKey<Template>(a=>a.TemplateStatisticsId);

                entity.HasOne(d => d.TemplateSettings)
                    .WithOne(p => p.Template)
                    .HasForeignKey<Template>(a => a.TemplateSettingsId);
            });

            modelBuilder.Entity<Personalization>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Personalizations)
                    .HasForeignKey(a=>a.LanguageId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Personalizations)
                    .HasForeignKey(a => a.ThemeId)
                    .OnDelete(DeleteBehavior.NoAction);
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
