using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AniMatch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anime",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ani_list_id = table.Column<int>(type: "integer", nullable: false),
                    title_english = table.Column<string>(type: "text", nullable: true),
                    title_romaji = table.Column<string>(type: "text", nullable: true),
                    title_native = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    cover_image_url = table.Column<string>(type: "text", nullable: true),
                    banner_image_url = table.Column<string>(type: "text", nullable: true),
                    format = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: true),
                    season_year = table.Column<int>(type: "integer", nullable: true),
                    episodes = table.Column<int>(type: "integer", nullable: true),
                    average_score = table.Column<int>(type: "integer", nullable: true),
                    popularity = table.Column<int>(type: "integer", nullable: true),
                    is_adult = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_synced_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_anime", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anime");
        }
    }
}
