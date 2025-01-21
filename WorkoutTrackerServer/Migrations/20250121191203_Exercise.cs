using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTrackerServer.Migrations
{
    /// <inheritdoc />
    public partial class CreateExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExerciseId",
                table: "WorkoutSet",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSet_ExerciseId",
                table: "WorkoutSet",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSet_Exercise_ExerciseId",
                table: "WorkoutSet",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSet_Exercise_ExerciseId",
                table: "WorkoutSet");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSet_ExerciseId",
                table: "WorkoutSet");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "WorkoutSet");
        }
    }
}
