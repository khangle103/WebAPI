using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreatedByToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "news",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "news",
                newName: "news_title");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "news",
                newName: "news_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "news",
                newName: "created_date");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "news",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date_publish",
                table: "news",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                table: "news",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "news",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "news",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "meta_keyword",
                table: "news",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "meta_title",
                table: "news",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "modified_by",
                table: "news",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "news",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "news_desc",
                table: "news",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "news_list_id",
                table: "news",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "news_status",
                table: "news",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "news_type",
                table: "news",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "news",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "views",
                table: "news",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "news");

            migrationBuilder.DropColumn(
                name: "date_publish",
                table: "news");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "news");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "news");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "news");

            migrationBuilder.DropColumn(
                name: "meta_keyword",
                table: "news");

            migrationBuilder.DropColumn(
                name: "meta_title",
                table: "news");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "news");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "news");

            migrationBuilder.DropColumn(
                name: "news_desc",
                table: "news");

            migrationBuilder.DropColumn(
                name: "news_list_id",
                table: "news");

            migrationBuilder.DropColumn(
                name: "news_status",
                table: "news");

            migrationBuilder.DropColumn(
                name: "news_type",
                table: "news");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "news");

            migrationBuilder.DropColumn(
                name: "views",
                table: "news");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "news",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "news_title",
                table: "news",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "news_id",
                table: "news",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "news",
                newName: "CreatedAt");
        }
    }
}
