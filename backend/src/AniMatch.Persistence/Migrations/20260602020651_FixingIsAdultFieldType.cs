using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AniMatch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixingIsAdultFieldType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE anime
                ALTER COLUMN is_adult TYPE boolean
                USING CASE
                    WHEN is_adult = 1 THEN true
                    WHEN is_adult = 0 THEN false
                    ELSE false
                END;
            """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE anime
                ALTER COLUMN is_adult TYPE integer
                USING CASE
                    WHEN is_adult THEN 1
                    ELSE 0
                END;
            """);
        }
    }
}