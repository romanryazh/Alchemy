using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alchemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Potions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EffectPotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EffectsId = table.Column<Guid>(type: "uuid", nullable: false),
                    PotionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectPotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EffectPotion_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EffectPotion_Potions_PotionsId",
                        column: x => x.PotionsId,
                        principalTable: "Potions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EffectPotion_EffectsId",
                table: "EffectPotion",
                column: "EffectsId");

            migrationBuilder.CreateIndex(
                name: "IX_EffectPotion_PotionsId",
                table: "EffectPotion",
                column: "PotionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EffectPotion");

            migrationBuilder.DropTable(
                name: "Potions");
        }
    }
}
