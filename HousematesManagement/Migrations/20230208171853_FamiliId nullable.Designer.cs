﻿// <auto-generated />
using System;
using Entity.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HousemateManagement.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230208171853_FamiliId nullable")]
    partial class FamiliIdnullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Entities.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfAddition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(9581));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Advertisements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f11235f-9ab8-4630-8aae-60bd2bdb7e34"),
                            Comments = "Magda initial comment",
                            DateOfAddition = new DateTime(2023, 2, 8, 18, 18, 52, 806, DateTimeKind.Local).AddTicks(261),
                            Description = "Magda Description",
                            Title = "Magda title",
                            UserId = new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485")
                        },
                        new
                        {
                            Id = new Guid("8219a4e0-2c1e-48c1-8f49-638882fdccef"),
                            Comments = "Mateusz initial comment",
                            DateOfAddition = new DateTime(2023, 2, 8, 18, 18, 52, 806, DateTimeKind.Local).AddTicks(287),
                            Description = "Mateusz Description",
                            Title = "Mateusz Title",
                            UserId = new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f")
                        },
                        new
                        {
                            Id = new Guid("e9c51e61-f60d-42c2-b52e-8626a92a34f5"),
                            Comments = "Michal initial comment",
                            DateOfAddition = new DateTime(2023, 2, 8, 18, 18, 52, 806, DateTimeKind.Local).AddTicks(302),
                            Description = "Michal Description",
                            Title = "Michal Title",
                            UserId = new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539")
                        });
                });

            modelBuilder.Entity("Entity.Entities.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfAddition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 8, 17, 18, 52, 805, DateTimeKind.Utc).AddTicks(4977));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4028437b-f68b-4823-9f3c-609a8fb8589a"),
                            Comments = "Initial Magda comment",
                            DateOfAddition = new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(8528),
                            Description = "Task description Magda",
                            Status = false,
                            Title = "Task title Magda",
                            UserId = new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485")
                        },
                        new
                        {
                            Id = new Guid("4d610cdb-da46-4d46-9e70-9f5e20dc4846"),
                            Comments = "Initial Mateusz comment",
                            DateOfAddition = new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(8608),
                            Description = "Task description Mateusz",
                            Status = false,
                            Title = "Task title Mateusz",
                            UserId = new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f")
                        },
                        new
                        {
                            Id = new Guid("1c0ff047-e5e5-433c-af81-d372462ff675"),
                            Comments = "Initial Michal comment",
                            DateOfAddition = new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(8628),
                            Description = "Task description Michal",
                            Status = false,
                            Title = "Task title Michal",
                            UserId = new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539")
                        });
                });

            modelBuilder.Entity("Entity.Entities.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Families");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c850e0b-445b-487e-92cc-724604f9d73c"),
                            Name = "Sidor"
                        },
                        new
                        {
                            Id = new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"),
                            Name = "Jaworscy-Sidor"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebtorsMetadata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8b3bbb7-d5e8-4fbf-9953-eb9cab8193c7"),
                            Amount = 100,
                            Deadline = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebtorsMetadata = "John Doe",
                            UserId = new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539")
                        },
                        new
                        {
                            Id = new Guid("c36055f7-c35f-43cb-a606-72c45ec5e2a7"),
                            Amount = 50,
                            Deadline = new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebtorsMetadata = "037269fb-b3d3-478a-ac83-0db8b2f31a3f",
                            UserId = new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485")
                        },
                        new
                        {
                            Id = new Guid("ef1305d3-a805-431a-85dd-f086526142ad"),
                            Amount = 75,
                            Deadline = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebtorsMetadata = "037269fb-b3d3-478a-ac83-0db8b2f31a3f",
                            UserId = new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485")
                        });
                });

            modelBuilder.Entity("Entity.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("FamilyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539"),
                            Birthday = new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michalSidor@email.com",
                            FamilyId = new Guid("9c850e0b-445b-487e-92cc-724604f9d73c"),
                            Gender = 0,
                            Login = "michalSidor",
                            Name = "Michal",
                            Password = "$2a$11$5x3w70qs70dzMLxmws96QOxjHisD8UWvNkpcxlQqZQHk7YSNEOlKC",
                            SecondName = "Sidor"
                        },
                        new
                        {
                            Id = new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485"),
                            Birthday = new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "magdalenaSidor@email.com",
                            FamilyId = new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"),
                            Gender = 1,
                            Login = "magdalenaSidor",
                            Name = "Magdalena",
                            Password = "$2a$11$BAqcZ3UjfC.Q6b4YJVoFYOZk2Kgl3Ir05ndzlkGC/U.27ESVyBcqq",
                            SecondName = "Jaworska-Sidor"
                        },
                        new
                        {
                            Id = new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f"),
                            Birthday = new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mateuszJaworski@email.com",
                            FamilyId = new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"),
                            Gender = 0,
                            Login = "mateuszJaworski",
                            Name = "Mateusz",
                            Password = "$2a$11$2vpv2KfBsSH1H9Zop36M3ORrXItMmRN0WiGKkje1yjuzHT/XCs/ga",
                            SecondName = "Jaworski-Sidor"
                        });
                });

            modelBuilder.Entity("Entity.Entities.Advertisement", b =>
                {
                    b.HasOne("Entity.Entities.User", "User")
                        .WithMany("Advertisements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Entities.Assignment", b =>
                {
                    b.HasOne("Entity.Entities.User", "User")
                        .WithMany("Assignment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Entities.Payment", b =>
                {
                    b.HasOne("Entity.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Entities.User", b =>
                {
                    b.HasOne("Entity.Entities.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Entity.Entities.User", b =>
                {
                    b.Navigation("Advertisements");

                    b.Navigation("Assignment");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}