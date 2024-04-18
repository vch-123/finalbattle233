using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBattle.Migrations
{
    /// <inheritdoc />
    public partial class NULLcatagory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_LikeMessages_LikeMessageId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "PostCategory",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LikeMessageId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_LikeMessages_LikeMessageId",
                table: "Posts",
                column: "LikeMessageId",
                principalTable: "LikeMessages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_LikeMessages_LikeMessageId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "PostCategory",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LikeMessageId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_LikeMessages_LikeMessageId",
                table: "Posts",
                column: "LikeMessageId",
                principalTable: "LikeMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
