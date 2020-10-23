using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorityManagement.Web.Migrations
{
    public partial class initializedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 256, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodsAttribute",
                columns: table => new
                {
                    GoodsAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsId = table.Column<int>(nullable: false),
                    GoodsAttributeName = table.Column<string>(maxLength: 64, nullable: true),
                    GoodsAttributeValue = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsAttribute", x => x.GoodsAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "GoodsType",
                columns: table => new
                {
                    GoodsTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HigherLevelId = table.Column<int>(nullable: false),
                    GoodsTypeName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsType", x => x.GoodsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MyAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Receiver = table.Column<string>(maxLength: 128, nullable: true),
                    Phone = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 128, nullable: true),
                    AddressInfo = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    OrderNo = table.Column<string>(maxLength: 256, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OrderStatus = table.Column<short>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Integral = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DisPlayName = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: true),
                    PermissionName = table.Column<string>(maxLength: 256, nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsGrant = table.Column<bool>(nullable: false),
                    RolePermissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_RolePermission_RolePermissionId",
                        column: x => x.RolePermissionId,
                        principalTable: "RolePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remark = table.Column<string>(nullable: true),
                    No = table.Column<string>(maxLength: 128, nullable: true),
                    TradeStatus = table.Column<int>(nullable: false),
                    TradeType = table.Column<int>(nullable: false),
                    RelationId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Avator = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<int>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsName = table.Column<string>(maxLength: 256, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GoodsTypeId = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(maxLength: 1024, nullable: true),
                    inventory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_Goods_GoodsType_GoodsTypeId",
                        column: x => x.GoodsTypeId,
                        principalTable: "GoodsType",
                        principalColumn: "GoodsTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    Consignee = table.Column<string>(maxLength: 128, nullable: true),
                    DeliveryAddress = table.Column<string>(maxLength: 512, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 512, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsImgae",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsId = table.Column<int>(nullable: false),
                    GoodsImgaeName = table.Column<string>(maxLength: 256, nullable: true),
                    Size = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsImgae", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsImgae_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_OrderId",
                table: "Addresses",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodsTypeId",
                table: "Goods",
                column: "GoodsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsImgae_GoodsId",
                table: "GoodsImgae",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RolePermissionId",
                table: "RolePermission",
                column: "RolePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "GoodsAttribute");

            migrationBuilder.DropTable(
                name: "GoodsImgae");

            migrationBuilder.DropTable(
                name: "MyAddresses");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Purses");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GoodsType");
        }
    }
}
