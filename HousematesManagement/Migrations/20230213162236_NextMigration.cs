using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HousemateManagement.Migrations
{
    /// <inheritdoc />
    public partial class NextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("1f11235f-9ab8-4630-8aae-60bd2bdb7e34"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("8219a4e0-2c1e-48c1-8f49-638882fdccef"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("e9c51e61-f60d-42c2-b52e-8626a92a34f5"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("1c0ff047-e5e5-433c-af81-d372462ff675"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("4028437b-f68b-4823-9f3c-609a8fb8589a"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("4d610cdb-da46-4d46-9e70-9f5e20dc4846"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c36055f7-c35f-43cb-a606-72c45ec5e2a7"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e8b3bbb7-d5e8-4fbf-9953-eb9cab8193c7"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ef1305d3-a805-431a-85dd-f086526142ad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("9c850e0b-445b-487e-92cc-724604f9d73c"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 16, 22, 36, 547, DateTimeKind.Utc).AddTicks(3526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 8, 17, 18, 52, 805, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(3196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(9581));

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15525635-e62a-4317-8b14-8486687423e1"), "Jaworscy-Sidor" },
                    { new Guid("45120579-d7af-41c7-80f6-fddaabca8718"), "Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FamilyId", "Gender", "Login", "Name", "Password", "SecondName" },
                values: new object[,]
                {
                    { new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013"), new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalenaSidor@email.com", new Guid("15525635-e62a-4317-8b14-8486687423e1"), 1, "magdalenaSidor", "Magdalena", "$2a$11$lIzZZJQWeuFD94CsQruO8e0XOfwyZL8QB8U2DyEnOF1MH9Uid8iny", "Jaworska-Sidor" },
                    { new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5"), new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "michalSidor@email.com", new Guid("45120579-d7af-41c7-80f6-fddaabca8718"), 0, "michalSidor", "Michal", "$2a$11$OgQ.w8posU6L/33Bkw/DWOYmxTsSgrlectQBSYdSgHIzg9jQoPaO.", "Sidor" },
                    { new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032"), new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mateuszJaworski@email.com", new Guid("15525635-e62a-4317-8b14-8486687423e1"), 0, "mateuszJaworski", "Mateusz", "$2a$11$sw.dWVTIyZ2Il3tJgbE8IOPF3o/RxXpyCkviWYlLxHDjWq865Lsoa", "Jaworski-Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("4ffb5103-bab1-466c-9aff-d00a8a18ee18"), "Michal initial comment", new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(5125), "Michal Description", "Michal Title", new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5") },
                    { new Guid("50fb6f2c-1b79-4231-8db9-d805c4e9d7bc"), "Magda initial comment", new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(5054), "Magda Description", "Magda title", new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013") },
                    { new Guid("958a0555-73a5-422b-85db-af39320e3930"), "Mateusz initial comment", new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(5109), "Mateusz Description", "Mateusz Title", new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032") }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c53be67-be24-418e-b159-2fa1c1fdc83f"), "Initial Mateusz comment", new DateTime(2023, 2, 13, 17, 22, 36, 547, DateTimeKind.Local).AddTicks(8474), "Task description Mateusz", "Task title Mateusz", new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032") },
                    { new Guid("d7807704-a01e-4a4a-a725-f7dbd49e2313"), "Initial Magda comment", new DateTime(2023, 2, 13, 17, 22, 36, 547, DateTimeKind.Local).AddTicks(8401), "Task description Magda", "Task title Magda", new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013") },
                    { new Guid("e567a7c7-88d8-4f58-a4e0-dacc1f2d7e0b"), "Initial Michal comment", new DateTime(2023, 2, 13, 17, 22, 36, 547, DateTimeKind.Local).AddTicks(8496), "Task description Michal", "Task title Michal", new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Deadline", "DebtorsMetadata", "UserId" },
                values: new object[,]
                {
                    { new Guid("542af29c-86d3-40c8-af3e-d67fec7f09b3"), 75, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "c5a01d26-fba9-4769-bc92-af9438f2c032", new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013") },
                    { new Guid("75268b13-a0d7-4472-bbb0-3e5d2237bccb"), 50, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "c5a01d26-fba9-4769-bc92-af9438f2c032", new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013") },
                    { new Guid("c7a5c901-c4be-483f-988d-c3cff8366382"), 100, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("4ffb5103-bab1-466c-9aff-d00a8a18ee18"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("50fb6f2c-1b79-4231-8db9-d805c4e9d7bc"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("958a0555-73a5-422b-85db-af39320e3930"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("3c53be67-be24-418e-b159-2fa1c1fdc83f"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("d7807704-a01e-4a4a-a725-f7dbd49e2313"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("e567a7c7-88d8-4f58-a4e0-dacc1f2d7e0b"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("542af29c-86d3-40c8-af3e-d67fec7f09b3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("75268b13-a0d7-4472-bbb0-3e5d2237bccb"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c7a5c901-c4be-483f-988d-c3cff8366382"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07c3ba84-53a5-4133-bab8-c3a400c53013"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1dc4ac4-03fb-4f65-b303-1134d4eb90a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5a01d26-fba9-4769-bc92-af9438f2c032"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("15525635-e62a-4317-8b14-8486687423e1"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("45120579-d7af-41c7-80f6-fddaabca8718"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 8, 17, 18, 52, 805, DateTimeKind.Utc).AddTicks(4977),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 16, 22, 36, 547, DateTimeKind.Utc).AddTicks(3526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(9581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 17, 22, 36, 552, DateTimeKind.Local).AddTicks(3196));

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9c850e0b-445b-487e-92cc-724604f9d73c"), "Sidor" },
                    { new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"), "Jaworscy-Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FamilyId", "Gender", "Login", "Name", "Password", "SecondName" },
                values: new object[,]
                {
                    { new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f"), new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mateuszJaworski@email.com", new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"), 0, "mateuszJaworski", "Mateusz", "$2a$11$2vpv2KfBsSH1H9Zop36M3ORrXItMmRN0WiGKkje1yjuzHT/XCs/ga", "Jaworski-Sidor" },
                    { new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539"), new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "michalSidor@email.com", new Guid("9c850e0b-445b-487e-92cc-724604f9d73c"), 0, "michalSidor", "Michal", "$2a$11$5x3w70qs70dzMLxmws96QOxjHisD8UWvNkpcxlQqZQHk7YSNEOlKC", "Sidor" },
                    { new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485"), new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalenaSidor@email.com", new Guid("fe2fe462-9bde-47f7-b2f5-eec0d5e05bfe"), 1, "magdalenaSidor", "Magdalena", "$2a$11$BAqcZ3UjfC.Q6b4YJVoFYOZk2Kgl3Ir05ndzlkGC/U.27ESVyBcqq", "Jaworska-Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f11235f-9ab8-4630-8aae-60bd2bdb7e34"), "Magda initial comment", new DateTime(2023, 2, 8, 18, 18, 52, 806, DateTimeKind.Local).AddTicks(261), "Magda Description", "Magda title", new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485") },
                    { new Guid("8219a4e0-2c1e-48c1-8f49-638882fdccef"), "Mateusz initial comment", new DateTime(2023, 2, 8, 18, 18, 52, 806, DateTimeKind.Local).AddTicks(287), "Mateusz Description", "Mateusz Title", new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f") },
                    { new Guid("e9c51e61-f60d-42c2-b52e-8626a92a34f5"), "Michal initial comment", new DateTime(2023, 2, 8, 18, 18, 52, 806, DateTimeKind.Local).AddTicks(302), "Michal Description", "Michal Title", new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539") }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("1c0ff047-e5e5-433c-af81-d372462ff675"), "Initial Michal comment", new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(8628), "Task description Michal", "Task title Michal", new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539") },
                    { new Guid("4028437b-f68b-4823-9f3c-609a8fb8589a"), "Initial Magda comment", new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(8528), "Task description Magda", "Task title Magda", new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485") },
                    { new Guid("4d610cdb-da46-4d46-9e70-9f5e20dc4846"), "Initial Mateusz comment", new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(8608), "Task description Mateusz", "Task title Mateusz", new Guid("037269fb-b3d3-478a-ac83-0db8b2f31a3f") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Deadline", "DebtorsMetadata", "UserId" },
                values: new object[,]
                {
                    { new Guid("c36055f7-c35f-43cb-a606-72c45ec5e2a7"), 50, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "037269fb-b3d3-478a-ac83-0db8b2f31a3f", new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485") },
                    { new Guid("e8b3bbb7-d5e8-4fbf-9953-eb9cab8193c7"), 100, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new Guid("5517beaf-0955-4089-9ab2-4c1b7a9ba539") },
                    { new Guid("ef1305d3-a805-431a-85dd-f086526142ad"), 75, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "037269fb-b3d3-478a-ac83-0db8b2f31a3f", new Guid("b1d83198-a758-4b7c-b71e-0f8fdabce485") }
                });
        }
    }
}
