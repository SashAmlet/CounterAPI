﻿// <auto-generated />
using System;
using CounterAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CounterAPI.Migrations.PageItems
{
    [DbContext(typeof(PageItemsContext))]
    [Migration("20230427190834_0")]
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

            modelBuilder.Entity("CounterAPI.Models.EventListener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageItemId")
                        .HasColumnType("int");

                    b.Property<string>("SecondWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PageItemId");

                    b.ToTable("EventListeners");
                });

            modelBuilder.Entity("CounterAPI.Models.PageItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CssClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("PageItems");
                });

            modelBuilder.Entity("CounterAPI.Models.PageItemAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageItemId")
                        .HasColumnType("int");

                    b.Property<string>("SecondWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PageItemId");

                    b.ToTable("PageItemAttributes");
                });

            modelBuilder.Entity("CounterAPI.Models.EventListener", b =>
                {
                    b.HasOne("CounterAPI.Models.PageItem", "PageItem")
                        .WithMany("EventListeners")
                        .HasForeignKey("PageItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PageItem");
                });

            modelBuilder.Entity("CounterAPI.Models.PageItem", b =>
                {
                    b.HasOne("CounterAPI.Models.PageItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("CounterAPI.Models.PageItemAttribute", b =>
                {
                    b.HasOne("CounterAPI.Models.PageItem", "PageItem")
                        .WithMany("Attributes")
                        .HasForeignKey("PageItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PageItem");
                });

            modelBuilder.Entity("CounterAPI.Models.PageItem", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Children");

                    b.Navigation("EventListeners");
                });
#pragma warning restore 612, 618
        }
    }
}
