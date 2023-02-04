using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HousemateManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfAddition = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(8205)),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfAddition = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 4, 16, 49, 47, 921, DateTimeKind.Utc).AddTicks(4177)),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtorsMetadata = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("100acc84-868a-40a3-a3d6-64ec0fa59443"), "Jaworscy-Sidor" },
                    { new Guid("9dc3029d-72d3-4777-b6f1-77b4f8291432"), "Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FamilyId", "Gender", "Login", "Name", "Password", "SecondName" },
                values: new object[,]
                {
                    { new Guid("56725f34-35af-4455-ac9e-79f4959a6418"), new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mateuszJaworski@email.com", new Guid("100acc84-868a-40a3-a3d6-64ec0fa59443"), 0, "mateuszJaworski", "Mateusz", "$2a$11$0qchJcI1WEjawWk0DvZBuO7eXeWWADimDvUWzXhzZcCdV0R3nBO9a", "Jaworski-Sidor" },
                    { new Guid("b6b4511c-f371-464b-b070-3620fcf9a4fe"), new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalenaSidor@email.com", new Guid("100acc84-868a-40a3-a3d6-64ec0fa59443"), 1, "magdalenaSidor", "Magdalena", "$2a$11$M33Xf6gW5kxqr/92gTDlLeXMKS9/Xx.YsvghCwzSyq5cLH3090C5y", "Jaworska-Sidor" },
                    { new Guid("f5ea2289-d51a-48ef-8046-8b28b18d99bf"), new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "michalSidor@email.com", new Guid("9dc3029d-72d3-4777-b6f1-77b4f8291432"), 0, "michalSidor", "Michal", "$2a$11$W3LCSKsSp82jYffMjdieueGelODw2dDrYR2EUBPY.akGILnjrul0O", "Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a285a89-c135-49f8-9a28-c30815723c38"), "Mateusz initial comment", new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(8928), "Mateusz Description", "Mateusz Title", new Guid("56725f34-35af-4455-ac9e-79f4959a6418") },
                    { new Guid("c5499e1a-8092-4b21-869a-192c5f84ec0e"), "Michal initial comment", new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(8943), "Michal Description", "Michal Title", new Guid("f5ea2289-d51a-48ef-8046-8b28b18d99bf") },
                    { new Guid("d25d74af-9a38-4dbb-aa3d-1d5ab0915a91"), "Magda initial comment", new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(8900), "Magda Description", "Magda title", new Guid("b6b4511c-f371-464b-b070-3620fcf9a4fe") }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("07b7abc9-0573-4dfc-a74f-84d909a23410"), "Initial Magda comment", new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(7244), "Task description Magda", "Task title Magda", new Guid("b6b4511c-f371-464b-b070-3620fcf9a4fe") },
                    { new Guid("a236d6fa-2dba-4b66-9fce-1414b07f8143"), "Initial Michal comment", new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(7325), "Task description Michal", "Task title Michal", new Guid("f5ea2289-d51a-48ef-8046-8b28b18d99bf") },
                    { new Guid("bf7e86fc-4f15-455f-ae3e-2fd34ac0b545"), "Initial Mateusz comment", new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(7316), "Task description Mateusz", "Task title Mateusz", new Guid("56725f34-35af-4455-ac9e-79f4959a6418") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Deadline", "DebtorsMetadata", "UserId" },
                values: new object[,]
                {
                    { new Guid("4840fc48-68c7-4733-8959-e9c2944e88af"), 50, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "56725f34-35af-4455-ac9e-79f4959a6418", new Guid("b6b4511c-f371-464b-b070-3620fcf9a4fe") },
                    { new Guid("a132b8e9-a95a-44d7-8206-b50d65b58eb1"), 75, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "56725f34-35af-4455-ac9e-79f4959a6418", new Guid("b6b4511c-f371-464b-b070-3620fcf9a4fe") },
                    { new Guid("e5aff18f-2b5a-4358-bf4a-68d596bc3e21"), 100, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new Guid("f5ea2289-d51a-48ef-8046-8b28b18d99bf") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyId",
                table: "Users",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
