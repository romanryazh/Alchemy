using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alchemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCraftStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CraftSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraftSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CraftStepComponent",
                columns: table => new
                {
                    CraftStepId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraftStepComponent", x => new { x.CraftStepId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_CraftStepComponent_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CraftStepComponent_CraftSteps_CraftStepId",
                        column: x => x.CraftStepId,
                        principalTable: "CraftSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CraftStepComponent_ComponentId",
                table: "CraftStepComponent",
                column: "ComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CraftStepComponent");

            migrationBuilder.DropTable(
                name: "CraftSteps");
        }
    }
}
