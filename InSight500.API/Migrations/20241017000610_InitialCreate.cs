using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InSight500.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeStatements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    FiscalDateEnding = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReportedCurrency = table.Column<string>(type: "text", nullable: false),
                    GrossProfit = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalRevenue = table.Column<decimal>(type: "numeric", nullable: false),
                    OperatingIncome = table.Column<decimal>(type: "numeric", nullable: false),
                    NetIncome = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeStatements");
        }
    }
}
