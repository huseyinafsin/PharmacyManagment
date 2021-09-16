using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyManagmentV2.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountPharmacy");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "Pharmacies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_BankAccountId",
                table: "Pharmacies",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_BankAccount_BankAccountId",
                table: "Pharmacies",
                column: "BankAccountId",
                principalTable: "BankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_BankAccount_BankAccountId",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_BankAccountId",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Pharmacies");

            migrationBuilder.CreateTable(
                name: "BankAccountPharmacy",
                columns: table => new
                {
                    BankAccountsId = table.Column<int>(type: "int", nullable: false),
                    PharmaciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountPharmacy", x => new { x.BankAccountsId, x.PharmaciesId });
                    table.ForeignKey(
                        name: "FK_BankAccountPharmacy_BankAccount_BankAccountsId",
                        column: x => x.BankAccountsId,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccountPharmacy_Pharmacies_PharmaciesId",
                        column: x => x.PharmaciesId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountPharmacy_PharmaciesId",
                table: "BankAccountPharmacy",
                column: "PharmaciesId");
        }
    }
}
