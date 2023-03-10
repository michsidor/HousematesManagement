// <auto-generated />
using System;
using Entity.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HousemateManagement.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(3196));

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
                            Id = new Guid("50fb6f2c-1b79-4231-8db9-d805c4e9d7bc"),
                            Comments = "Magda initial comment",
                            DateOfAddition = new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(5054),
                            Description = "Magda Description",
                            Title = "Magda title",
                            UserId = new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013")
                        },
                        new
                        {
                            Id = new Guid("958a0555-73a5-422b-85db-af39320e3930"),
                            Comments = "Mateusz initial comment",
                            DateOfAddition = new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(5109),
                            Description = "Mateusz Description",
                            Title = "Mateusz Title",
                            UserId = new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032")
                        },
                        new
                        {
                            Id = new Guid("4ffb5103-bab1-466c-9aff-d00a8a18ee18"),
                            Comments = "Michal initial comment",
                            DateOfAddition = new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(5125),
                            Description = "Michal Description",
                            Title = "Michal Title",
                            UserId = new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5")
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
                        .HasDefaultValue(new DateTime(2023, 2, 13, 16, 22, 36, 547, DateTimeKind.Utc).AddTicks(3526));

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
                            Id = new Guid("d7807704-a01e-4a4a-a725-f7dbd49e2313"),
                            Comments = "Initial Magda comment",
                            DateOfAddition = new DateTime(2023, 2, 13, 17, 22, 36, 547, DateTimeKind.Local).AddTicks(8401),
                            Description = "Task description Magda",
                            Status = false,
                            Title = "Task title Magda",
                            UserId = new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013")
                        },
                        new
                        {
                            Id = new Guid("3c53be67-be24-418e-b159-2fa1c1fdc83f"),
                            Comments = "Initial Mateusz comment",
                            DateOfAddition = new DateTime(2023, 2, 13, 17, 22, 36, 547, DateTimeKind.Local).AddTicks(8474),
                            Description = "Task description Mateusz",
                            Status = false,
                            Title = "Task title Mateusz",
                            UserId = new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032")
                        },
                        new
                        {
                            Id = new Guid("e567a7c7-88d8-4f58-a4e0-dacc1f2d7e0b"),
                            Comments = "Initial Michal comment",
                            DateOfAddition = new DateTime(2023, 2, 13, 17, 22, 36, 547, DateTimeKind.Local).AddTicks(8496),
                            Description = "Task description Michal",
                            Status = false,
                            Title = "Task title Michal",
                            UserId = new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5")
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
                            Id = new Guid("45120579-d7af-41c7-80f6-fddaabca8718"),
                            Name = "Sidor"
                        },
                        new
                        {
                            Id = new Guid("15525635-e62a-4317-8b14-8486687423e1"),
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
                            Id = new Guid("c7a5c901-c4be-483f-988d-c3cff8366382"),
                            Amount = 100,
                            Deadline = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebtorsMetadata = "John Doe",
                            UserId = new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5")
                        },
                        new
                        {
                            Id = new Guid("75268b13-a0d7-4472-bbb0-3e5d2237bccb"),
                            Amount = 50,
                            Deadline = new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebtorsMetadata = "c5a01d26-fba9-4769-bc92-af9438f2c032",
                            UserId = new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013")
                        },
                        new
                        {
                            Id = new Guid("542af29c-86d3-40c8-af3e-d67fec7f09b3"),
                            Amount = 75,
                            Deadline = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DebtorsMetadata = "c5a01d26-fba9-4769-bc92-af9438f2c032",
                            UserId = new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013")
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

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FamilyId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5"),
                            Birthday = new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michalSidor@email.com",
                            FamilyId = new Guid("45120579-d7af-41c7-80f6-fddaabca8718"),
                            Gender = 0,
                            Login = "michalSidor",
                            Name = "Michal",
                            Password = "$2a$11$OgQ.w8posU6L/33Bkw/DWOYmxTsSgrlectQBSYdSgHIzg9jQoPaO.",
                            SecondName = "Sidor"
                        },
                        new
                        {
                            Id = new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013"),
                            Birthday = new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "magdalenaSidor@email.com",
                            FamilyId = new Guid("15525635-e62a-4317-8b14-8486687423e1"),
                            Gender = 1,
                            Login = "magdalenaSidor",
                            Name = "Magdalena",
                            Password = "$2a$11$lIzZZJQWeuFD94CsQruO8e0XOfwyZL8QB8U2DyEnOF1MH9Uid8iny",
                            SecondName = "Jaworska-Sidor"
                        },
                        new
                        {
                            Id = new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032"),
                            Birthday = new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mateuszJaworski@email.com",
                            FamilyId = new Guid("15525635-e62a-4317-8b14-8486687423e1"),
                            Gender = 0,
                            Login = "mateuszJaworski",
                            Name = "Mateusz",
                            Password = "$2a$11$sw.dWVTIyZ2Il3tJgbE8IOPF3o/RxXpyCkviWYlLxHDjWq865Lsoa",
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
