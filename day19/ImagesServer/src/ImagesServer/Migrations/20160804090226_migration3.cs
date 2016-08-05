using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImagesServer.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "platform",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "platform",
                table: "Images",
                nullable: true);
        }
    }
}
