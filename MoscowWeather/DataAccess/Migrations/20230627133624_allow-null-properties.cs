using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistense.Migrations
{
    /// <inheritdoc />
    public partial class allownullproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoscowWeatherForecasts",
                table: "MoscowWeatherForecasts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MoscowWeatherForecasts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoscowWeatherForecasts",
                table: "MoscowWeatherForecasts",
                column: "DateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MoscowWeatherForecasts",
                table: "MoscowWeatherForecasts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MoscowWeatherForecasts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoscowWeatherForecasts",
                table: "MoscowWeatherForecasts",
                column: "Id");
        }
    }
}
