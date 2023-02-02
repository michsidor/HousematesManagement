using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertiesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 18, 18, 24, 291, DateTimeKind.Utc).AddTicks(5262),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DebtorsMetadata",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Families",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advertisements",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 18, 18, 24, 291, DateTimeKind.Utc).AddTicks(8601),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1453d1eb-f3e7-4c80-9c4f-92446641dda5"), "Jaworscy-Sidor" },
                    { new Guid("32203efb-43db-4e93-a9b7-68d727494c63"), "Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FamilyId", "Gender", "Login", "Name", "Password", "SecondName" },
                values: new object[,]
                {
                    { new Guid("57e468a0-ef0b-431e-9e55-88effd0a5acb"), new DateTime(1989, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalenaSidor@email.com", new Guid("1453d1eb-f3e7-4c80-9c4f-92446641dda5"), 1, "magdalenaSidor", "Magdalena", "$2a$11$PH1MUZcG.9vUW7SWlKWmGuS7bwWP5SnaL1tHORYkPTNohf6WdKEyC", "Jaworska-Sidor" },
                    { new Guid("938ad847-5da3-43c6-9bb5-16666f03e57b"), new DateTime(1985, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mateuszJaworski@email.com", new Guid("1453d1eb-f3e7-4c80-9c4f-92446641dda5"), 0, "mateuszJaworski", "Mateusz", "$2a$11$A14W4IRiuLM7JOIgpEOrDeZ3sLPXlCZyh1OH930MuK0P2GmQ3hX7G", "Jaworski-Sidor" },
                    { new Guid("c569a646-fe5a-4628-99cb-ea5686a5788f"), new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "michalSidor@email.com", new Guid("32203efb-43db-4e93-a9b7-68d727494c63"), 0, "michalSidor", "Michal", "$2a$11$CEh5KD.MiY0XtoyiE.nYXuTjDH31Uaor3W1A2JKTdeKKcM7EIUt/O", "Sidor" }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("5b4db6c0-227f-48a8-9c13-24a3a45afe54"), "Michal initial comment", new DateTime(2023, 1, 28, 19, 18, 24, 291, DateTimeKind.Local).AddTicks(9075), "Michal Description", "Michal Title", new Guid("c569a646-fe5a-4628-99cb-ea5686a5788f") },
                    { new Guid("727f2251-a664-4cf4-9cb2-526e0a23fd8a"), "Magda initial comment", new DateTime(2023, 1, 28, 19, 18, 24, 291, DateTimeKind.Local).AddTicks(9050), "Magda Description", "Magda title", new Guid("57e468a0-ef0b-431e-9e55-88effd0a5acb") },
                    { new Guid("831d852c-652d-4611-a966-e03ac1612578"), "Mateusz initial comment", new DateTime(2023, 1, 28, 19, 18, 24, 291, DateTimeKind.Local).AddTicks(9071), "Mateusz Description", "Mateusz Title", new Guid("938ad847-5da3-43c6-9bb5-16666f03e57b") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "Deadline", "DebtorsMetadata", "UserId" },
                values: new object[,]
                {
                    { new Guid("b7fa0686-8f9a-4d74-8994-09d6f831be23"), 50, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "938ad847-5da3-43c6-9bb5-16666f03e57b", new Guid("57e468a0-ef0b-431e-9e55-88effd0a5acb") },
                    { new Guid("c80323c0-997d-4105-ab88-7a989024facf"), 75, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "938ad847-5da3-43c6-9bb5-16666f03e57b", new Guid("57e468a0-ef0b-431e-9e55-88effd0a5acb") },
                    { new Guid("dc91f056-9be6-4ac6-b655-1d0a5b161015"), 100, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", new Guid("c569a646-fe5a-4628-99cb-ea5686a5788f") }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Comments", "DateOfAddition", "Description", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("00bb61a4-023b-4534-9336-981e4e779464"), "Initial Magda comment", new DateTime(2023, 1, 28, 19, 18, 24, 291, DateTimeKind.Local).AddTicks(7520), "Task description Magda", "Task title Magda", new Guid("57e468a0-ef0b-431e-9e55-88effd0a5acb") },
                    { new Guid("8647d49c-acde-4e92-a921-5b6a9fa2ad00"), "Initial Mateusz comment", new DateTime(2023, 1, 28, 19, 18, 24, 291, DateTimeKind.Local).AddTicks(7579), "Task description Mateusz", "Task title Mateusz", new Guid("938ad847-5da3-43c6-9bb5-16666f03e57b") },
                    { new Guid("f514554f-aaf6-40b4-b914-0a2dc63b11d3"), "Initial Michal comment", new DateTime(2023, 1, 28, 19, 18, 24, 291, DateTimeKind.Local).AddTicks(7584), "Task description Michal", "Task title Michal", new Guid("c569a646-fe5a-4628-99cb-ea5686a5788f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("5b4db6c0-227f-48a8-9c13-24a3a45afe54"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("727f2251-a664-4cf4-9cb2-526e0a23fd8a"));

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: new Guid("831d852c-652d-4611-a966-e03ac1612578"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b7fa0686-8f9a-4d74-8994-09d6f831be23"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c80323c0-997d-4105-ab88-7a989024facf"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("dc91f056-9be6-4ac6-b655-1d0a5b161015"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("00bb61a4-023b-4534-9336-981e4e779464"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("8647d49c-acde-4e92-a921-5b6a9fa2ad00"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f514554f-aaf6-40b4-b914-0a2dc63b11d3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57e468a0-ef0b-431e-9e55-88effd0a5acb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("938ad847-5da3-43c6-9bb5-16666f03e57b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c569a646-fe5a-4628-99cb-ea5686a5788f"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("1453d1eb-f3e7-4c80-9c4f-92446641dda5"));

            migrationBuilder.DeleteData(
                table: "Families",
                keyColumn: "Id",
                keyValue: new Guid("32203efb-43db-4e93-a9b7-68d727494c63"));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Tasks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 18, 18, 24, 291, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.AlterColumn<string>(
                name: "DebtorsMetadata",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Families",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAddition",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 18, 18, 24, 291, DateTimeKind.Utc).AddTicks(8601));

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
    }
}
