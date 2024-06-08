﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestsBuilder.Infastructure.Persistence;

#nullable disable

namespace TestsBuilder.Infastructure.Migrations
{
    [DbContext(typeof(TestsBuilderDbContext))]
    partial class TestsBuilderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TestsBuilder.Domain.Test.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tests", (string)null);
                });

            modelBuilder.Entity("TestsBuilder.Domain.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TestsBuilder.Domain.Test.Test", b =>
                {
                    b.OwnsMany("TestsBuilder.Domain.Test.Entities.Example", "Examples", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)")
                                .HasColumnName("ExampleId");

                            b1.Property<Guid>("TestId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("BaseAnswers")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("BaseAnswers");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)");

                            b1.HasKey("Id", "TestId");

                            b1.HasIndex("TestId");

                            b1.ToTable("Examples", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("TestId");

                            b1.OwnsMany("TestsBuilder.Domain.Test.Entities.ExampleVariant", "Variants", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("char(36)")
                                        .HasColumnName("ExampleVariantId");

                                    b2.Property<Guid>("ExampleId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("TestId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Answers")
                                        .IsRequired()
                                        .HasColumnType("longtext")
                                        .HasColumnName("Answers");

                                    b2.Property<string>("CorrectAnswer")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.Property<string>("Expression")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("varchar(100)");

                                    b2.Property<string>("Number")
                                        .IsRequired()
                                        .HasMaxLength(3)
                                        .HasColumnType("varchar(3)");

                                    b2.HasKey("Id", "ExampleId", "TestId");

                                    b2.HasIndex("ExampleId", "TestId");

                                    b2.ToTable("ExampleVariants", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("ExampleId", "TestId");
                                });

                            b1.Navigation("Variants");
                        });

                    b.Navigation("Examples");
                });
#pragma warning restore 612, 618
        }
    }
}
