using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistense.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoscowWeatherForecasts",
                columns: table => new
                {
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    T = table.Column<double>(type: "double precision", nullable: false),
                    Humidity = table.Column<short>(type: "smallint", nullable: false),
                    Td = table.Column<double>(type: "double precision", nullable: false),
                    AirPressure = table.Column<int>(type: "integer", nullable: false),
                    WindDirection = table.Column<string>(type: "text", nullable: false),
                    WindSpeed = table.Column<int>(type: "integer", nullable: false),
                    Cloudiness = table.Column<short>(type: "smallint", nullable: false),
                    H = table.Column<int>(type: "integer", nullable: false),
                    VV = table.Column<int>(type: "integer", nullable: false),
                    WeatherState = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoscowWeatherForecasts", x => x.DateTime);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoscowWeatherForecasts");
        }
    }
}
