using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectDetailsProjectId",
                table: "userDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectManager = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.ProjectId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_ProjectDetailsProjectId",
                table: "userDetails",
                column: "ProjectDetailsProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_userDetails_ProjectDetails_ProjectDetailsProjectId",
                table: "userDetails",
                column: "ProjectDetailsProjectId",
                principalTable: "ProjectDetails",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDetails_ProjectDetails_ProjectDetailsProjectId",
                table: "userDetails");

            migrationBuilder.DropTable(
                name: "ProjectDetails");

            migrationBuilder.DropIndex(
                name: "IX_userDetails_ProjectDetailsProjectId",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "ProjectDetailsProjectId",
                table: "userDetails");
        }
    }
}
