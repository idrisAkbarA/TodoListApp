using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Data.Migrations
{
    public partial class addtodolistfieldinworkspacetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkspaceId",
                table: "ToDoLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_WorkspaceId",
                table: "ToDoLists",
                column: "WorkspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_Workspaces_WorkspaceId",
                table: "ToDoLists",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_Workspaces_WorkspaceId",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_WorkspaceId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "WorkspaceId",
                table: "ToDoLists");
        }
    }
}
