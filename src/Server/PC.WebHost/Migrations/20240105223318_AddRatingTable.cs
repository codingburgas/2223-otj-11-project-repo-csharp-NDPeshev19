using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.WebHost.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePlacementStudentConfigurations_Articles_ArticleId",
                table: "ArticlePlacementStudentConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePlacementStudentConfigurations_BaseAzureAccount_StudentId",
                table: "ArticlePlacementStudentConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePlacementStudentConfigurations_Placements_PlacementId",
                table: "ArticlePlacementStudentConfigurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticlePlacementStudentConfigurations",
                table: "ArticlePlacementStudentConfigurations");

            migrationBuilder.RenameTable(
                name: "ArticlePlacementStudentConfigurations",
                newName: "ArticlePlacementStudent");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlePlacementStudentConfigurations_StudentId",
                table: "ArticlePlacementStudent",
                newName: "IX_ArticlePlacementStudent_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlePlacementStudentConfigurations_PlacementId",
                table: "ArticlePlacementStudent",
                newName: "IX_ArticlePlacementStudent_PlacementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticlePlacementStudent",
                table: "ArticlePlacementStudent",
                columns: new[] { "ArticleId", "PlacementId", "StudentId" });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_BaseAzureAccount_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseAzureAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ArticleId",
                table: "Ratings",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePlacementStudent_Articles_ArticleId",
                table: "ArticlePlacementStudent",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePlacementStudent_BaseAzureAccount_StudentId",
                table: "ArticlePlacementStudent",
                column: "StudentId",
                principalTable: "BaseAzureAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePlacementStudent_Placements_PlacementId",
                table: "ArticlePlacementStudent",
                column: "PlacementId",
                principalTable: "Placements",
                principalColumn: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePlacementStudent_Articles_ArticleId",
                table: "ArticlePlacementStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePlacementStudent_BaseAzureAccount_StudentId",
                table: "ArticlePlacementStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticlePlacementStudent_Placements_PlacementId",
                table: "ArticlePlacementStudent");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticlePlacementStudent",
                table: "ArticlePlacementStudent");

            migrationBuilder.RenameTable(
                name: "ArticlePlacementStudent",
                newName: "ArticlePlacementStudentConfigurations");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlePlacementStudent_StudentId",
                table: "ArticlePlacementStudentConfigurations",
                newName: "IX_ArticlePlacementStudentConfigurations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticlePlacementStudent_PlacementId",
                table: "ArticlePlacementStudentConfigurations",
                newName: "IX_ArticlePlacementStudentConfigurations_PlacementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticlePlacementStudentConfigurations",
                table: "ArticlePlacementStudentConfigurations",
                columns: new[] { "ArticleId", "PlacementId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePlacementStudentConfigurations_Articles_ArticleId",
                table: "ArticlePlacementStudentConfigurations",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePlacementStudentConfigurations_BaseAzureAccount_StudentId",
                table: "ArticlePlacementStudentConfigurations",
                column: "StudentId",
                principalTable: "BaseAzureAccount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticlePlacementStudentConfigurations_Placements_PlacementId",
                table: "ArticlePlacementStudentConfigurations",
                column: "PlacementId",
                principalTable: "Placements",
                principalColumn: "Title");
        }
    }
}
