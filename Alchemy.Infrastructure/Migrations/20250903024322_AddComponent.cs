using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alchemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentEffect",
                columns: table => new
                {
                    ComponentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    EffectsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentEffect", x => new { x.ComponentsId, x.EffectsId });
                    table.ForeignKey(
                        name: "FK_ComponentEffect_Components_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentEffect_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentLocation",
                columns: table => new
                {
                    ComponentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentLocation", x => new { x.ComponentsId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_ComponentLocation_Components_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentLocation_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentEffect_EffectsId",
                table: "ComponentEffect",
                column: "EffectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentLocation_LocationsId",
                table: "ComponentLocation",
                column: "LocationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentEffect");

            migrationBuilder.DropTable(
                name: "ComponentLocation");

            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
