using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BagarBasse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductVariations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Styck" },
                    { 2, "2-pack" },
                    { 3, "4-pack" },
                    { 4, "6-pack" },
                    { 5, "12-pack" },
                    { 6, "24-pack" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "IsNew",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsNew",
                value: false);

            migrationBuilder.InsertData(
                table: "ProductVariant",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 4, 149.9m, 129.9m },
                    { 2, 5, 120.0m, 120.0m },
                    { 3, 5, 120.0m, 120.0m },
                    { 4, 4, 149.9m, 120.0m },
                    { 5, 4, 149.9m, 120.0m },
                    { 6, 4, 149.9m, 120.0m },
                    { 7, 4, 480.0m, 480.0m },
                    { 8, 4, 149.9m, 120.0m },
                    { 9, 4, 80.0m, 80.0m },
                    { 10, 6, 300.0m, 249.0m },
                    { 11, 1, 450.0m, 450.0m },
                    { 12, 4, 259.0m, 259.0m },
                    { 13, 4, 150m, 150m },
                    { 14, 4, 150m, 150m },
                    { 15, 4, 100m, 100m },
                    { 16, 6, 300m, 300m },
                    { 17, 1, 380.0m, 380.0m },
                    { 18, 1, 360.0m, 360.0m },
                    { 19, 1, 340.0m, 340.0m },
                    { 20, 1, 310.0m, 310.0m },
                    { 21, 1, 65m, 65m },
                    { 22, 1, 65m, 65m },
                    { 23, 1, 65m, 65m },
                    { 24, 1, 65m, 65m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariant",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Products");
        }
    }
}
