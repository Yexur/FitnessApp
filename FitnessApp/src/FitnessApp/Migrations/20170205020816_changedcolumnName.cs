using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Migrations
{
    public partial class changedcolumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_Instructor_Instructors_Id",
                table: "FitnessClass");

            migrationBuilder.RenameColumn(
                name: "Instructors_Id",
                table: "FitnessClass",
                newName: "Instructor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClass_Instructors_Id",
                table: "FitnessClass",
                newName: "IX_FitnessClass_Instructor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_Instructor_Instructor_Id",
                table: "FitnessClass",
                column: "Instructor_Id",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_Instructor_Instructor_Id",
                table: "FitnessClass");

            migrationBuilder.RenameColumn(
                name: "Instructor_Id",
                table: "FitnessClass",
                newName: "Instructors_Id");

            migrationBuilder.RenameIndex(
                name: "IX_FitnessClass_Instructor_Id",
                table: "FitnessClass",
                newName: "IX_FitnessClass_Instructors_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_Instructor_Instructors_Id",
                table: "FitnessClass",
                column: "Instructors_Id",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
