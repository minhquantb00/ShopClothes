using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopClothes.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountEvent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    DiscountEventStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodStatus = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankCustomer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingMethodStatus = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VoucherStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SoldeQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnQuantity = table.Column<int>(type: "int", nullable: false),
                    PriceAfterDiscount = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorQuantity = table.Column<int>(type: "int", nullable: false),
                    AverageRating = table.Column<double>(type: "float", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductStatus = table.Column<int>(type: "int", nullable: true),
                    InventoryNumber = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId1",
                        column: x => x.ProductTypeId1,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: true),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RankCustomerId = table.Column<int>(type: "int", nullable: true),
                    RankCustomerId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_RankCustomer_RankCustomerId1",
                        column: x => x.RankCustomerId1,
                        principalTable: "RankCustomer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true),
                    DiscountEventId = table.Column<int>(type: "int", nullable: false),
                    DiscountEventId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventProduct_DiscountEvent_DiscountEventId1",
                        column: x => x.DiscountEventId1,
                        principalTable: "DiscountEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventProduct_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryNumber = table.Column<int>(type: "int", nullable: false),
                    SoldQuantity = table.Column<int>(type: "int", nullable: false),
                    ReturnQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductDetailStatus = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ColorId1 = table.Column<long>(type: "bigint", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    SizeId1 = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Color_ColorId1",
                        column: x => x.ColorId1,
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductDetail_Size_SizeId1",
                        column: x => x.SizeId1,
                        principalTable: "Size",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    ConsigneeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMainAddress = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfirmEmail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfirmEmail_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    RoleId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserVoucher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    VoucherId1 = table.Column<long>(type: "bigint", nullable: true),
                    ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    UserVoucherStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVoucher_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserVoucher_Voucher_VoucherId1",
                        column: x => x.VoucherId1,
                        principalTable: "Voucher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailId1 = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_ProductDetail_ProductDetailId1",
                        column: x => x.ProductDetailId1,
                        principalTable: "ProductDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cart_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_ProductDetail_ProductDetailId1",
                        column: x => x.ProductDetailId1,
                        principalTable: "ProductDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    TradingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: false),
                    ShippingMethodId1 = table.Column<long>(type: "bigint", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPriceBeforeDiscount = table.Column<double>(type: "float", nullable: true),
                    BillStatus = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForRefusal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPriceAfterDiscount = table.Column<double>(type: "float", nullable: false),
                    UserVoucherId = table.Column<int>(type: "int", nullable: true),
                    UserVoucherId1 = table.Column<long>(type: "bigint", nullable: true),
                    EmployeeCreateBillId = table.Column<int>(type: "int", nullable: false),
                    ShippingFee = table.Column<double>(type: "float", nullable: false),
                    AddressId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_Address_AddressId1",
                        column: x => x.AddressId1,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bill_PaymentMethod_PaymentMethodId1",
                        column: x => x.PaymentMethodId1,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bill_ShippingMethod_ShippingMethodId1",
                        column: x => x.ShippingMethodId1,
                        principalTable: "ShippingMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bill_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bill_UserVoucher_UserVoucherId1",
                        column: x => x.UserVoucherId1,
                        principalTable: "UserVoucher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    BillId1 = table.Column<long>(type: "bigint", nullable: true),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailId1 = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaitingQuantity = table.Column<int>(type: "int", nullable: true),
                    ReturnQuantity = table.Column<int>(type: "int", nullable: true),
                    ErrorQuantity = table.Column<int>(type: "int", nullable: true),
                    BillDetailStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetail_Bill_BillId1",
                        column: x => x.BillId1,
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillDetail_ProductDetail_ProductDetailId1",
                        column: x => x.ProductDetailId1,
                        principalTable: "ProductDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true),
                    ProductDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductDetailId1 = table.Column<long>(type: "bigint", nullable: true),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfStars = table.Column<int>(type: "int", nullable: false),
                    ReviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Bill_BillId1",
                        column: x => x.BillId1,
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReview_ProductDetail_ProductDetailId1",
                        column: x => x.ProductDetailId1,
                        principalTable: "ProductDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReview_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId1",
                table: "Address",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_AddressId1",
                table: "Bill",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PaymentMethodId1",
                table: "Bill",
                column: "PaymentMethodId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ShippingMethodId1",
                table: "Bill",
                column: "ShippingMethodId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserId1",
                table: "Bill",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserVoucherId1",
                table: "Bill",
                column: "UserVoucherId1");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillId1",
                table: "BillDetail",
                column: "BillId1");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_ProductDetailId1",
                table: "BillDetail",
                column: "ProductDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductDetailId1",
                table: "Cart",
                column: "ProductDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId1",
                table: "Cart",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmEmail_UserId1",
                table: "ConfirmEmail",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventProduct_DiscountEventId1",
                table: "EventProduct",
                column: "DiscountEventId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventProduct_ProductId1",
                table: "EventProduct",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_ProductDetailId1",
                table: "FavoriteProduct",
                column: "ProductDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_UserId1",
                table: "FavoriteProduct",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId1",
                table: "Product",
                column: "ProductTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ColorId1",
                table: "ProductDetail",
                column: "ColorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductId1",
                table: "ProductDetail",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_SizeId1",
                table: "ProductDetail",
                column: "SizeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId1",
                table: "ProductImage",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_BillId1",
                table: "ProductReview",
                column: "BillId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductDetailId1",
                table: "ProductReview",
                column: "ProductDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_UserId1",
                table: "ProductReview",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId1",
                table: "RefreshToken",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_RankCustomerId1",
                table: "User",
                column: "RankCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId1",
                table: "UserRole",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId1",
                table: "UserRole",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserVoucher_UserId1",
                table: "UserVoucher",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserVoucher_VoucherId1",
                table: "UserVoucher",
                column: "VoucherId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ConfirmEmail");

            migrationBuilder.DropTable(
                name: "EventProduct");

            migrationBuilder.DropTable(
                name: "FavoriteProduct");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "DiscountEvent");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "ShippingMethod");

            migrationBuilder.DropTable(
                name: "UserVoucher");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "RankCustomer");
        }
    }
}
