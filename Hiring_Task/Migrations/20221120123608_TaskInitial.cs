using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiringTask.Migrations
{
    /// <inheritdoc />
    public partial class TaskInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TasksTaskeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TasksTaskeId",
                table: "Users",
                column: "TasksTaskeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tasks_TasksTaskeId",
                table: "Users",
                column: "TasksTaskeId",
                principalTable: "Tasks",
                principalColumn: "TaskeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Tasks_TasksTaskeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Users_TasksTaskeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TasksTaskeId",
                table: "Users");
        }
    }
}
