﻿// <auto-generated />
using CounterAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CounterAPI.Migrations
{
    [DbContext(typeof(CounterAPIContext))]
    [Migration("20230426171148_0")]
    partial class _0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CounterAPI.Models.LanguageList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("CounterAPI.Models.Languages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EnglishWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UkranianWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CounterAPI.Models.Personalization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<bool>("Notifications")
                        .HasColumnType("bit");

                    b.Property<int>("ThemeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ThemeId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Personalizations");
                });

            modelBuilder.Entity("CounterAPI.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateListId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateSettingsId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateStatisticsId")
                        .HasColumnType("int");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateListId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TemplateLists");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Fructions")
                        .HasColumnType("bit");

                    b.Property<int>("MaxValue")
                        .HasColumnType("int");

                    b.Property<int>("MinValue")
                        .HasColumnType("int");

                    b.Property<int>("NumOfProblems")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId")
                        .IsUnique();

                    b.ToTable("TemplateSettings");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumOfSolved")
                        .HasColumnType("int");

                    b.Property<int>("NumOfUnsolved")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId")
                        .IsUnique();

                    b.ToTable("TemplateStatistics");
                });

            modelBuilder.Entity("CounterAPI.Models.ThemeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserThemes");
                });

            modelBuilder.Entity("CounterAPI.Models.Themes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DarkWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhiteWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("CounterAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CounterAPI.Models.Personalization", b =>
                {
                    b.HasOne("CounterAPI.Models.LanguageList", "Language")
                        .WithMany("Personalizations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CounterAPI.Models.ThemeList", "Theme")
                        .WithMany("Personalizations")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CounterAPI.Models.User", "User")
                        .WithOne("Personalization")
                        .HasForeignKey("CounterAPI.Models.Personalization", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Theme");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CounterAPI.Models.Template", b =>
                {
                    b.HasOne("CounterAPI.Models.TemplateList", "TemplateList")
                        .WithMany("Templates")
                        .HasForeignKey("TemplateListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateList");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateList", b =>
                {
                    b.HasOne("CounterAPI.Models.User", "User")
                        .WithMany("TemplateLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateSettings", b =>
                {
                    b.HasOne("CounterAPI.Models.Template", "Template")
                        .WithOne("TemplateSettings")
                        .HasForeignKey("CounterAPI.Models.TemplateSettings", "TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateStatistics", b =>
                {
                    b.HasOne("CounterAPI.Models.Template", "Template")
                        .WithOne("TemplateStatistics")
                        .HasForeignKey("CounterAPI.Models.TemplateStatistics", "TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("CounterAPI.Models.LanguageList", b =>
                {
                    b.Navigation("Personalizations");
                });

            modelBuilder.Entity("CounterAPI.Models.Template", b =>
                {
                    b.Navigation("TemplateSettings");

                    b.Navigation("TemplateStatistics");
                });

            modelBuilder.Entity("CounterAPI.Models.TemplateList", b =>
                {
                    b.Navigation("Templates");
                });

            modelBuilder.Entity("CounterAPI.Models.ThemeList", b =>
                {
                    b.Navigation("Personalizations");
                });

            modelBuilder.Entity("CounterAPI.Models.User", b =>
                {
                    b.Navigation("Personalization");

                    b.Navigation("TemplateLists");
                });
#pragma warning restore 612, 618
        }
    }
}
