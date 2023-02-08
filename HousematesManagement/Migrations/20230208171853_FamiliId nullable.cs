using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HousemateManagement.Migrations
{
    /// <inheritdoc />
    public partial class FamiliIdnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Families_FamilyId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("1a285a89-c135-49f8-9a28-c30815723c38"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("c5499e1a-8092-4b21-869a-192c5f84ec0e"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("d25d74af-9a38-4dbb-aa3d-1d5ab0915a91"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("07b7abc9-0573-4dfc-a74f-84d909a23410"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("a236d6fa-2dba-4b66-9fce-1414b07f8143"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("bf7e86fc-4f15-455f-ae3e-2fd34ac0b545"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4840fc48-68c7-4733-8959-e9c2944e88af"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a132b8e9-a95a-44d7-8206-b50d65b58eb1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e5aff18f-2b5a-4358-bf4a-68d596bc3e21"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("56725f34-35af-4455-ac9e-79f4959a6418"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b6b4511c-f371-464b-b070-3620fcf9a4fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5ea2289-d51a-48ef-8046-8b28b18d99bf"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("100acc84-868a-40a3-a3d6-64ec0fa59443"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("9dc3029d-72d3-4777-b6f1-77b4f8291432"));

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 8, 17, 18, 52, 805, DateTimeKind.Utc).AddTicks(4977),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 4, 16, 49, 47, 921, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(9581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(8205));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Families_FamilyId",
                table: "Users",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Families_FamilyId",
                table: "Users");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Assignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 4, 16, 49, 47, 921, DateTimeKind.Utc).AddTicks(4177),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 8, 17, 18, 52, 805, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 4, 17, 49, 47, 921, DateTimeKind.Local).AddTicks(8205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 8, 18, 18, 52, 805, DateTimeKind.Local).AddTicks(9581));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Families_FamilyId",
                table: "Users",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
