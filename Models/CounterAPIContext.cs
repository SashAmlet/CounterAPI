﻿using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Models
{
    public class CounterAPIContext: DbContext
    {
        public CounterAPIContext(DbContextOptions<CounterAPIContext> options): base(options)
        {
            Database.EnsureCreated();        
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

                entity.HasOne(d => d.Personalization).WithOne();

                entity.HasMany(d => d.TemplateLists).WithOne(p => p.User);

            });

            modelBuilder.Entity<TemplateList>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(d => d.TemplateStatistics).WithOne();

                entity.HasOne(d => d.TemplateSettings).WithOne();
            });

            modelBuilder.Entity<Personalization>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<TemplateSettings>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<TemplateStatistics>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(a => a.Ukranian).IsRequired(false);
                entity.Property(a => a.English).IsRequired(false);
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(a => a.White).IsRequired(false);
                entity.Property(a => a.Dark).IsRequired(false);
            });
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TemplateList> TemplateLists { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateStatistics> TemplateStatistics { get; set; }
        public virtual DbSet<TemplateSettings> TemplateSettings { get; set; }
        public virtual DbSet<Personalization> Personalizations { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }

    }
}
