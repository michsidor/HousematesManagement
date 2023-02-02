using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4e145c2e-5f61-4bad-ab24-7905e9c9ffce"), "Jaworscy-Sidor" },
                    { new Guid("d240afd8-2e5d-42de-a247-5c3f67ae30eb"), "Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FamilyId", "Gender", "Login", "Name", "Password", "SecondName" },
                values: new object[,]
                {
                    { new Guid("b6d26b53-8b0c-40a9-8e03-e20b614cd02d"), new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalenaSidor@email.com", new Guid("4e145c2e-5f61-4bad-ab24-7905e9c9ffce"), 1, "magdalenaSidor", "Magdalena", "$2a$11$PiWaBYJLph13aS0t3vs4POB3jkAixHVMNEItOz8Ne5Both9oZMU9q", "Jaworska-Sidor" },
                    { new Guid("ca01f38f-1290-44b6-b896-96cd9d3026a5"), new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "michalSidor@email.com", new Guid("d240afd8-2e5d-42de-a247-5c3f67ae30eb"), 0, "michalSidor", "Michal", "$2a$11$Ng3ERDjLUE7i7yE0DGk4cuYd37og1mchGaMXzL8b8ftgxfaaFG1ci", "Sidor" },
                    { new Guid("ca6fa9db-c751-42b0-89fe-fbeb23d26634"), new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mateuszJaworski@email.com", new Guid("4e145c2e-5f61-4bad-ab24-7905e9c9ffce"), 0, "mateuszJaworski", "Mateusz", "$2a$11$eSQltlK9BOY92UhK8TguZef6nplj1jzhCz3lqW6tQjTrV10e1mFFS", "Jaworski-Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("27f92fcb-cb28-4176-b812-5ddfd29a8eed"), "Mateusz initial comment", new DateTime(2023, 1, 28, 15, 59, 36, 637, DateTimeKind.Local).AddTicks(4825), "Mateusz Description", "Mateusz Title", new Guid("ca6fa9db-c751-42b0-89fe-fbeb23d26634") },
                    { new Guid("91008caf-9e57-4db4-80ea-7016ab6f7777"), "Michal initial comment", new DateTime(2023, 1, 28, 15, 59, 36, 637, DateTimeKind.Local).AddTicks(4831), "Michal Description", "Michal Title", new Guid("ca01f38f-1290-44b6-b896-96cd9d3026a5") },
                    { new Guid("a1601a68-0e11-4dee-9c23-d9c6c0532a56"), "Magda initial comment", new DateTime(2023, 1, 28, 15, 59, 36, 637, DateTimeKind.Local).AddTicks(4812), "Magda Description", "Magda title", new Guid("b6d26b53-8b0c-40a9-8e03-e20b614cd02d") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Deadline", "DebtorsMetadata", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f8de958-2efa-4f29-8b6e-f838635e09a3"), 50, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca6fa9db-c751-42b0-89fe-fbeb23d26634", new Guid("b6d26b53-8b0c-40a9-8e03-e20b614cd02d") },
                    { new Guid("6536d37e-28df-49f8-82dc-08dd24c6d0df"), 75, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ca6fa9db-c751-42b0-89fe-fbeb23d26634", new Guid("b6d26b53-8b0c-40a9-8e03-e20b614cd02d") },
                    { new Guid("d9eadea5-6d83-4036-9d6d-a70287cc6fa6"), 100, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new Guid("ca01f38f-1290-44b6-b896-96cd9d3026a5") }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("4e1e2830-a8af-45d8-b3bc-f959a3a2c0ff"), "Initial Magda comment", new DateTime(2023, 1, 28, 15, 59, 36, 637, DateTimeKind.Local).AddTicks(4473), "Task description Magda", false, "Task title Magda", new Guid("b6d26b53-8b0c-40a9-8e03-e20b614cd02d") },
                    { new Guid("99e1a2ec-d6ad-4718-a728-c9580240155f"), "Initial Michal comment", new DateTime(2023, 1, 28, 15, 59, 36, 637, DateTimeKind.Local).AddTicks(4607), "Task description Michal", false, "Task title Michal", new Guid("ca01f38f-1290-44b6-b896-96cd9d3026a5") },
                    { new Guid("c4eb3fdc-c794-4c22-af67-afd8804c8a3a"), "Initial Mateusz comment", new DateTime(2023, 1, 28, 15, 59, 36, 637, DateTimeKind.Local).AddTicks(4599), "Task description Mateusz", false, "Task title Mateusz", new Guid("ca6fa9db-c751-42b0-89fe-fbeb23d26634") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("27f92fcb-cb28-4176-b812-5ddfd29a8eed"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("91008caf-9e57-4db4-80ea-7016ab6f7777"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("a1601a68-0e11-4dee-9c23-d9c6c0532a56"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4f8de958-2efa-4f29-8b6e-f838635e09a3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6536d37e-28df-49f8-82dc-08dd24c6d0df"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d9eadea5-6d83-4036-9d6d-a70287cc6fa6"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4e1e2830-a8af-45d8-b3bc-f959a3a2c0ff"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("99e1a2ec-d6ad-4718-a728-c9580240155f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("c4eb3fdc-c794-4c22-af67-afd8804c8a3a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b6d26b53-8b0c-40a9-8e03-e20b614cd02d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca01f38f-1290-44b6-b896-96cd9d3026a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca6fa9db-c751-42b0-89fe-fbeb23d26634"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("4e145c2e-5f61-4bad-ab24-7905e9c9ffce"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("d240afd8-2e5d-42de-a247-5c3f67ae30eb"));
        }
    }
}
