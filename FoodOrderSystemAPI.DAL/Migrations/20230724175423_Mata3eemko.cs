using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mata3eemko : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerModel_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethods = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantModel_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Card_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card_Expiration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditId);
                    table.ForeignKey(
                        name: "FK_CreditCards_CustomerModel_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_CustomerModel_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer = table.Column<float>(type: "real", nullable: false),
                    rate = table.Column<float>(type: "real", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_RestaurantModel_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "RestaurantModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    tag = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.tag });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewModel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewModel", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ReviewModel_CustomerModel_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "de795340-7d97-406d-a47c-befeda1380a0", "hassan@gmail.com", false, false, null, "", "testmohamed", null, "1234567890", false, 0, null, false, "testmohamed" },
                    { 3, 0, "96cbb6bf-4c3c-4fc5-9c8e-e017204a9b91", "hamdy@gmail.com", false, false, null, "", "ramymohamed", null, "1234237890", false, 0, null, false, "ramymohamed" },
                    { 100, 0, "8ef57c14-7a79-425c-ab30-ffb25b024aaa", "test", false, false, null, "", "MohamedAhmed", null, null, false, 0, null, false, "MohamedAhmed" },
                    { 101, 0, "ad5b1bee-382c-4195-8289-3bad65fe66e4", "test", false, false, null, "", "KFC", null, null, false, 0, null, false, "KFC" },
                    { 102, 0, "05186964-d0cb-42e7-a7a5-d3a44647d1c4", "test", false, false, null, "", "Central", null, null, false, 0, null, false, "Central" },
                    { 103, 0, "42e33aff-2a2d-4c49-8b5a-a99c7c4f57e1", "info@tastybistro.com", false, false, null, "", "TheTastyBistro", null, null, false, 0, null, false, "TheTastyBistro" },
                    { 104, 0, "61a37a09-de46-4023-96bd-b75d9a318c2f", "www.ChezGaby.com", false, false, null, "", "ChezGaby", null, null, false, 0, null, false, "ChezGaby" },
                    { 105, 0, "855a8478-2202-443e-9318-a763ef5205de", "www.Negro.com", false, false, null, "", "Negro", null, null, false, 0, null, false, "Negro" },
                    { 106, 0, "4308e6a3-2abc-4648-9908-a52b2ef278cd", "567 Walnut Lane", false, false, null, "", "seafoodshack", null, null, false, 0, null, false, "seafoodshack" }
                });

            migrationBuilder.InsertData(
                table: "CustomerModel",
                columns: new[] { "Id", "BirthDate", "CustomerAddress" },
                values: new object[,]
                {
                    { 2, new DateTime(1999, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gleem" },
                    { 3, new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanstifano" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantModel",
                columns: new[] { "Id", "Address", "Logo", "PaymentMethods", "Phone", "RestaurantName" },
                values: new object[,]
                {
                    { 100, "test", "https://images.deliveryhero.io/image/talabat/restaurants/21167986_13580950369_637438183491941065.jpg?width=180", 1, "+20 111 111 1111", "Mohamed Ahmed" },
                    { 101, "test", "https://upload.wikimedia.org/wikipedia/sco/b/bf/KFC_logo.svg", 1, "+20 111 111 1111", "KFC" },
                    { 102, "Av. Pedro de Osma 301, Barranco, Lima, Peru", "https://centralrestaurante.com.pe/assets/images/facebook.jpg", 2, "+51 1 242 8515", "Koshary El Tahrir" },
                    { 103, "123 Main Street", "https://img.freepik.com/free-vector/detailed-chef-logo-template_23-2148987940.jpg?size=626&ext=jpg&ga=GA1.1.118802800.1685470637&semt=ais", 1, "+20 111 111 1111", "The Tasty Bistro" },
                    { 104, "off of Fouad Street, close to the Alexandria Opera House", "https://www.zumtaugwald.ch/uploads/8iADQWOr/chezgaby_farbig_gross_198.gif", 1, "+20 111 111 1111", "Chez Gaby" },
                    { 105, "test", "https://cerronegrorestaurant.com/wp-content/uploads/2022/06/logo-1.png", 1, "+20 111 111 1111", "Negro" },
                    { 106, "test", "https://img.freepik.com/premium-vector/fresh-seafood-restaurant-premium-logo_187482-625.jpg?w=2000", 1, "+20 111 111 1111", "The Seafood Shack" }
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CreditId", "CVV", "Card_Expiration_Date", "Card_Number", "CustomerId" },
                values: new object[,]
                {
                    { 1, "333", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234123412341234", 2 },
                    { 2, "229", new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1212121212121212", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Productname", "RestaurantID", "describtion", "img", "offer", "price", "rate" },
                values: new object[,]
                {
                    { 1, "Flafel", 100, "flafel so5na", "https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg", 0.45555f, 3f, 4f },
                    { 2, "fool", 100, "fool so5n", "https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg", 0f, 5f, 2f },
                    { 3, "Koshary", 100, "Koshary so5n", "https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg", 0.5f, 20f, 4f },
                    { 4, "kebda", 102, "kebda so5na", "https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg", 0.1f, 30f, 3f },
                    { 5, "Eggs With Pastrami Sandwich", 100, "Served in Shami bread", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi8s-5oiHaDOOhdsh1Q8aylMWvDZKeUFMVpmnm2ottNGiHscgP", 0f, 17f, 5f },
                    { 6, "Rizo Spicy", 101, "Fried chicken and Rice", "https://images.deliveryhero.io/image/talabat/MenuItems/F0F5ED9174479F606B0221B326F9E866", 0.1f, 45f, 3.5f },
                    { 7, "Twister Chilla Box", 101, "Fried chicken,3 Sandwiches", "https://images.deliveryhero.io/image/talabat/MenuItems/3283E7BD37DFE8FEF2DE4E0151391E64", 0.1f, 120f, 2f },
                    { 8, "Classic Bucket", 101, "(9 pcs)", "https://images.deliveryhero.io/image/talabat/MenuItems/4CB1034B30EB60005948C7079C75BD3A", 0.09f, 90f, 4f },
                    { 9, "Family Koshary Meal", 102, "for 5 Persons", "https://images.deliveryhero.io/image/talabat/Menuitems/%D9%81%D8%A7%D9%85%D9%8A%D9%84%D9%89_%D9%81%D9%88%D9%8A%D9%84637879013422961404.jpg?width=172&amp", 0.09f, 150f, 1f },
                    { 10, "Small Mineral", 102, "Water Bottle", "https://t0.gstatic.com/images?q=tbn:ANd9GcRDvWTfXzH-61_ZP_fCAzjo6YPcd-CAKoL3dxAcKYe1tgjQ5yYO", 0.09f, 15f, 3f },
                    { 11, "Tuna Salad", 103, "tuna and mayonnaise", "https://littlesunnykitchen.com/wp-content/uploads/2022/12/Tuna-Salad-1.jpg", 0f, 55f, 4f },
                    { 12, "Greek Salad", 103, "pieces of tomatoes, cucumbers, onion, feta cheese, and olives and dressed with salt, Greek oregano, and olive oil", "https://hips.hearstapps.com/hmg-prod/images/greek-salad-index-642f292397bbf.jpg", 0f, 40f, 4f },
                    { 13, "Chef", 103, "hard-boiled eggs, a variety of julienned meats", "https://www.allrecipes.com/thmb/Q84xeMgnOJPZAUOdNyrb9dbFZr4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/285625-ChefsSalad_MFS_006-2550ecee70ae46dbaec530a58314c99c.jpg", 0.09f, 70f, 5f },
                    { 14, "Turkey With Emmental Cheese", 104, "Freshly made half baguette filled with turkey and Emmental cheese mixed with greens making it the perfect grab-and-go meal", "https://gourmetegypt.com/media/catalog/product/t/u/turkey-_-cheese-photo_nk70qlcuxsoq2rfw.jpg", 0f, 50f, 4f },
                    { 15, "Roast Beef With Emmental", 104, "Combine the white cheese with the mustard", "http://gourmetpedia.net/media/upload/recipe/3398.jpg", 0f, 70f, 5f },
                    { 16, "italian sub sandwich", 104, "tuna and mayonnaise", "https://static01.nyt.com/images/2022/02/07/dining/as-italian-sub/merlin_201238275_040c2bf1-9f7d-4653-9f83-9b262dd03a05-articleLarge.jpg", 0f, 60f, 3f },
                    { 17, "Cabrito", 104, "Mexico meal", "https://lh3.googleusercontent.com/WXWvHOubytJUkjYKXTTAi_WIsosuxjsgecB4XKCat1fyy1f60ELPn3p-NPXgzJcf5FixXd_k657H_4aOFPWjdviq6v6495vCKXJl37w", 0f, 150f, 4f },
                    { 18, "Onion Rings", 105, "A famous \"Shack Snack\", our onion rings are served with delicious whale sauce", "https://www.seafoodshack.com/wp-content/uploads/2015/04/Onion-Rings-Website-FI-500x375.jpg", 0.7f, 80f, 5f },
                    { 19, "Almond stuffed rainbow trout", 101, "A delicious frozen cocktail made with Tres Agaves Tequila, Triple Sec, Tres Agaves Organic Margarita Mix, fresh lime and a splash of orange juice", "https://www.seafoodshack.com/wp-content/uploads/2015/04/Mango-Margarita-Website-FI-500x375.jpg", 0.2f, 220f, 4f },
                    { 20, "Fish Tacos", 106, "Seasoned fresh local catch, colby jack cheese, napa cabbage and baja sauce served in crispy corn tortillas", "https://www.seafoodshack.com/wp-content/uploads/2015/04/FishTacos-Website-FI-500x375.jpg", 0.5f, 130f, 5f }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ProductId", "tag" },
                values: new object[,]
                {
                    { 1, "local" },
                    { 1, "vegetarian" },
                    { 2, "local" },
                    { 2, "vegetarian" },
                    { 3, "local" },
                    { 3, "vegetarian" },
                    { 4, "local" },
                    { 5, "local" },
                    { 6, "local" },
                    { 7, "local" },
                    { 8, "local" },
                    { 9, "local" },
                    { 10, "local" },
                    { 11, "healthy" },
                    { 11, "local" },
                    { 12, "healthy" },
                    { 13, "healthy" },
                    { 14, "healthy" },
                    { 15, "healthy" },
                    { 16, "healthy" },
                    { 17, "healthy" },
                    { 18, "healthy" },
                    { 19, "healthy" },
                    { 20, "healthy" },
                    { 20, "vegetarian" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CustomerId",
                table: "CreditCards",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RestaurantID",
                table: "Products",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewModel_ProductId",
                table: "ReviewModel",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "ReviewModel");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerModel");

            migrationBuilder.DropTable(
                name: "RestaurantModel");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
