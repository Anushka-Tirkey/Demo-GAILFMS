﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FILESMGMT.Migrations.FileDB
{
    public partial class GAILFMSFileCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileType = table.Column<string>(name: "File Type", type: "varchar(20)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Open_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Closed_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contract_No = table.Column<int>(type: "int", nullable: false),
                    Vendor_name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Vendor_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                });

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(@"
                UPDATE Files
                SET FileName = LEFT([File Type], 3) + ' - ' + 
                               CONVERT(varchar, Open_Date, 23) + ' - ' + 
                               Vendor_name + ' - ' + 
                               CAST(Contract_No AS varchar) + ' - ' + 
                               CAST(FileId AS varchar)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}

