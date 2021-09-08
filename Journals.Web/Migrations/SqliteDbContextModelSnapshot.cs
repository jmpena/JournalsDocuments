﻿// <auto-generated />
using System;
using Journals.Web.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Journals.Web.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Journals.Web.Entities.JournalsDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Document")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ResearcherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ResearcherId");

                    b.ToTable("JournalsDocuments");
                });

            modelBuilder.Entity("Journals.Web.Entities.Researcher", b =>
                {
                    b.Property<int>("ResearcherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("ResearcherId");

                    b.ToTable("Researchers");
                });

            modelBuilder.Entity("Journals.Web.Entities.Subscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResearcherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubscriptionToResearcherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Journals.Web.Entities.JournalsDocument", b =>
                {
                    b.HasOne("Journals.Web.Entities.Researcher", "Researcher")
                        .WithMany("JournalsDocuments")
                        .HasForeignKey("ResearcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Researcher");
                });

            modelBuilder.Entity("Journals.Web.Entities.Researcher", b =>
                {
                    b.Navigation("JournalsDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
