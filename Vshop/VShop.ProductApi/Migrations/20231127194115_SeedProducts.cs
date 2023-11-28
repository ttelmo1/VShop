using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId ) VALUES ('IPhone 12', 1000.00, 'IPhone 12', 10, 'https://cdn.tgdd.vn/Products/Images/42/213031/iphone-12-xanh-duong-new-600x600-200x200.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId ) VALUES ('IPhone 11', 900.00, 'IPhone 11', 20,'https://cdn.tgdd.vn/Products/Images/42/153856/iphone-11-pro-max-green-600x600-200x200.jpg', 1)");
            migrationBuilder.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId ) VALUES ('Pencil', 800.00, 'Super Pencil', 30, 'pencil.jpg', 2)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
