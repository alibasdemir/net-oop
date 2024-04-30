using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserOperationsClaims_OperationClaimId",
                table: "UserOperationsClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationsClaims_UserId",
                table: "UserOperationsClaims",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationsClaims_OperationClaims_OperationClaimId",
                table: "UserOperationsClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationsClaims_Users_UserId",
                table: "UserOperationsClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationsClaims_OperationClaims_OperationClaimId",
                table: "UserOperationsClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationsClaims_Users_UserId",
                table: "UserOperationsClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationsClaims_OperationClaimId",
                table: "UserOperationsClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationsClaims_UserId",
                table: "UserOperationsClaims");
        }
    }
}
