using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentBookingApp1.Migrations
{
    /// <inheritdoc />
    public partial class EnityBody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_LocalGovernments_LocalGovernmentId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_LocalGovernmentId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartmentType",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "LocalGovernmentId",
                table: "Apartments",
                newName: "NumberOfRooms");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Apartments",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AddColumn<string>(
                name: "LocalGovernment",
                table: "Apartments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalGovernment",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "NumberOfRooms",
                table: "Apartments",
                newName: "LocalGovernmentId");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Apartments",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentType",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LocalGovernmentId",
                table: "Apartments",
                column: "LocalGovernmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_LocalGovernments_LocalGovernmentId",
                table: "Apartments",
                column: "LocalGovernmentId",
                principalTable: "LocalGovernments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
