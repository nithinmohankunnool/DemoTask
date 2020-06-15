using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoTaskProject.Migrations
{
    public partial class initialmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "SubTaskItems",
                columns: table => new
                {
                    SubTaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTaskName = table.Column<string>(nullable: false),
                    SubDescription = table.Column<string>(maxLength: 500, nullable: false),
                    SubStartDate = table.Column<DateTime>(nullable: false),
                    SubFinishDate = table.Column<DateTime>(nullable: false),
                    SubState = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false),
                    TaskItemTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTaskItems", x => x.SubTaskId);
                    table.ForeignKey(
                        name: "FK_SubTaskItems_TaskItems_TaskItemTaskId",
                        column: x => x.TaskItemTaskId,
                        principalTable: "TaskItems",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTaskItems_TaskItemTaskId",
                table: "SubTaskItems",
                column: "TaskItemTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTaskItems");

            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
