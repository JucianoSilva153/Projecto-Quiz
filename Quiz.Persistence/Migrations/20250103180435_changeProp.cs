using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Kwizzes_KwizId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_KwizId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "KwizId",
                table: "Points");

            migrationBuilder.CreateIndex(
                name: "IX_Points_QuizId",
                table: "Points",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Kwizzes_QuizId",
                table: "Points",
                column: "QuizId",
                principalTable: "Kwizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Kwizzes_QuizId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_QuizId",
                table: "Points");

            migrationBuilder.AddColumn<Guid>(
                name: "KwizId",
                table: "Points",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Points_KwizId",
                table: "Points",
                column: "KwizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Kwizzes_KwizId",
                table: "Points",
                column: "KwizId",
                principalTable: "Kwizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
