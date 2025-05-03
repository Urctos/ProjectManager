using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameProjectsTasksToProjectTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectsTasks_Projects_ProjectId",
                table: "ProjectsTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsTasks",
                table: "ProjectsTasks");

            migrationBuilder.RenameTable(
                name: "ProjectsTasks",
                newName: "ProjectTasks");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectsTasks_ProjectId",
                table: "ProjectTasks",
                newName: "IX_ProjectTasks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Projects_ProjectId",
                table: "ProjectTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTasks",
                table: "ProjectTasks");

            migrationBuilder.RenameTable(
                name: "ProjectTasks",
                newName: "ProjectsTasks");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTasks_ProjectId",
                table: "ProjectsTasks",
                newName: "IX_ProjectsTasks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsTasks",
                table: "ProjectsTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsTasks_Projects_ProjectId",
                table: "ProjectsTasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
