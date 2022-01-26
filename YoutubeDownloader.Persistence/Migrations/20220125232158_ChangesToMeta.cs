using Microsoft.EntityFrameworkCore.Migrations;

namespace YoutubeDownloader.Persistence.Migrations
{
    public partial class ChangesToMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "format_id",
                table: "video_meta_format",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "format_id",
                table: "video_meta_format",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
