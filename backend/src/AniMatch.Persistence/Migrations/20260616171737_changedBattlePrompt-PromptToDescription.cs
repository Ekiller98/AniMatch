using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AniMatch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedBattlePromptPromptToDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prompt",
                table: "battle_prompts",
                newName: "description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "battle_prompts",
                newName: "prompt");
        }
    }
}
