using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0b9551b9-c145-4976-9c97-b3bd542953d1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("447f468e-44a2-4f00-bd08-aa02a8841d76"));

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brands.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("52a35c46-4dda-40c4-bd9e-8c55047605da"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 49, 70, 250, 188, 202, 187, 231, 81, 32, 161, 15, 140, 209, 48, 218, 247, 34, 214, 99, 199, 234, 104, 106, 247, 239, 167, 216, 83, 160, 24, 223, 16, 143, 185, 144, 219, 255, 179, 141, 246, 202, 132, 219, 95, 46, 219, 64, 220, 159, 220, 66, 219, 64, 43, 84, 89, 244, 107, 188, 157, 0, 241, 219, 99 }, new byte[] { 151, 228, 101, 122, 24, 141, 202, 69, 172, 184, 93, 188, 190, 246, 56, 22, 76, 112, 82, 137, 202, 209, 46, 230, 181, 231, 164, 213, 207, 244, 48, 0, 5, 223, 228, 197, 24, 216, 196, 115, 182, 53, 144, 180, 19, 85, 71, 225, 233, 97, 91, 118, 6, 45, 125, 216, 95, 71, 178, 88, 54, 71, 10, 155, 79, 176, 66, 235, 52, 183, 4, 117, 122, 26, 255, 138, 132, 130, 221, 45, 15, 92, 79, 167, 207, 252, 199, 19, 139, 158, 60, 81, 197, 158, 30, 206, 38, 162, 158, 189, 252, 155, 181, 232, 158, 120, 41, 220, 39, 93, 211, 127, 76, 120, 38, 174, 199, 199, 54, 209, 35, 244, 125, 240, 220, 203, 117, 103 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3e30e4a2-75e7-4150-8b45-19cc6dd443fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("52a35c46-4dda-40c4-bd9e-8c55047605da") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3e30e4a2-75e7-4150-8b45-19cc6dd443fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52a35c46-4dda-40c4-bd9e-8c55047605da"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("447f468e-44a2-4f00-bd08-aa02a8841d76"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 81, 101, 196, 44, 127, 50, 211, 71, 26, 124, 194, 101, 206, 244, 108, 111, 150, 66, 143, 139, 167, 84, 236, 210, 11, 213, 24, 16, 213, 125, 104, 46, 52, 218, 236, 100, 207, 225, 18, 181, 236, 102, 164, 23, 180, 121, 14, 134, 113, 142, 34, 68, 214, 44, 14, 216, 67, 27, 200, 88, 59, 96, 76, 30 }, new byte[] { 107, 37, 127, 141, 20, 48, 132, 81, 131, 236, 130, 61, 210, 241, 148, 39, 32, 171, 223, 118, 226, 189, 118, 71, 70, 110, 141, 81, 158, 91, 50, 153, 156, 18, 93, 164, 75, 235, 3, 156, 150, 112, 156, 22, 102, 237, 238, 138, 49, 172, 184, 138, 246, 132, 233, 133, 64, 69, 59, 40, 188, 52, 26, 79, 196, 152, 189, 249, 71, 101, 147, 168, 17, 124, 56, 222, 223, 195, 1, 52, 184, 162, 228, 244, 113, 209, 55, 4, 175, 138, 234, 92, 141, 219, 195, 49, 92, 142, 206, 47, 135, 247, 123, 244, 199, 8, 109, 212, 62, 209, 5, 107, 159, 174, 10, 168, 122, 34, 134, 9, 21, 15, 27, 46, 191, 112, 157, 118 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0b9551b9-c145-4976-9c97-b3bd542953d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("447f468e-44a2-4f00-bd08-aa02a8841d76") });
        }
    }
}
