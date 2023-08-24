using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodOrderSystemAPI;

public class SystemContext : IdentityDbContext<UserModel, IdentityRole <int>, int>
{
    #region models
    // !!!!!!! UNCOMMENT DBSET ONLY WHEN MODEL IS READY !!!!!!!!!!!!!!

    internal DbSet<AdminModel> Admins => Set<AdminModel>();
    internal DbSet<CustomerModel> Customers => Set<CustomerModel>();
    internal DbSet<OrderModel> Orders => Set<OrderModel>();
    internal DbSet<OrderProductModel> OrdersProducts => Set<OrderProductModel>();
    internal DbSet<ProductModel> Products => Set<ProductModel>();
    internal DbSet<ProductTag> ProductTags => Set<ProductTag>();
    internal DbSet<RestaurantModel> Restaurants => Set<RestaurantModel>();
    internal DbSet<ReviewModel> Reviews => Set<ReviewModel>();
    internal DbSet<CreditCard> CreditCards => Set<CreditCard>();
    internal DbSet<ReviewModel> Loacntions => Set<ReviewModel>();
    #endregion

    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    { }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProductModel>()
            .HasKey(e => new {e.OrderId, e.ProductId });
        
        modelBuilder.Entity<ReviewModel>()
            .HasKey(e => new {e.CustomerId, e.ProductId });

        modelBuilder.Entity<ProductTag>()
            .HasKey(e => new { e.ProductId, e.tag });

        modelBuilder.Entity<OrderProductModel>()
                .HasOne(a => a.Product).WithMany(b => b.orderProducts)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<OrderProductModel>()
                .HasOne(a => a.Order).WithMany(b => b.OrderProducts)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ReviewModel>()
                .HasOne(a => a.Product).WithMany(b => b.reviews)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ReviewModel>()
                .HasOne(a => a.Customer).WithMany(b => b.Reviews)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<CustomerModel>().ToTable("CustomerModel");
        modelBuilder.Entity<RestaurantModel>().ToTable("RestaurantModel");


        #region product seed
        modelBuilder.Entity<ProductModel>().HasData(
            new ProductModel { ProductId = 1, Productname = "Flafel", price = 3, describtion = "flafel so5na", img = "https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg", offer = 0.45555f, rate = 4, RestaurantID = 100 },
            new ProductModel { ProductId = 2, Productname = "fool", price = 5, describtion = "fool so5n", img = "https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg", offer = 0, rate = 2, RestaurantID = 100 },
            new ProductModel { ProductId = 3, Productname = "Koshary", price = 20, describtion = "Koshary so5n", img = "https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg", offer = 0.5f, rate = 4, RestaurantID = 100 },
            new ProductModel { ProductId = 4, Productname = "kebda", price = 30, describtion = "kebda so5na", img = "https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg", offer = 0.1f, rate = 3 , RestaurantID = 102 },
            new ProductModel { ProductId = 5, Productname = "Eggs With Pastrami Sandwich", price = 17, describtion = "Served in Shami bread", img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRi8s-5oiHaDOOhdsh1Q8aylMWvDZKeUFMVpmnm2ottNGiHscgP", offer = 0.0f, rate = 5 , RestaurantID = 100 },
            new ProductModel { ProductId = 6, Productname = "Rizo Spicy", price = 45, describtion = "Fried chicken and Rice", img = "https://images.deliveryhero.io/image/talabat/MenuItems/F0F5ED9174479F606B0221B326F9E866", offer = 0.1f, rate = 3.5f , RestaurantID = 101 },
            new ProductModel { ProductId = 7, Productname = "Twister Chilla Box", price = 120, describtion = "Fried chicken,3 Sandwiches", img = "https://images.deliveryhero.io/image/talabat/MenuItems/3283E7BD37DFE8FEF2DE4E0151391E64", offer = 0.1f, rate = 2f , RestaurantID = 101 },
            new ProductModel { ProductId = 8, Productname = "Classic Bucket", price = 90, describtion = "(9 pcs)", img = "https://images.deliveryhero.io/image/talabat/MenuItems/4CB1034B30EB60005948C7079C75BD3A", offer = 0.09f, rate = 4f , RestaurantID = 101 },
            new ProductModel { ProductId = 9, Productname = "Family Koshary Meal", price = 150, describtion = "for 5 Persons", img = "https://images.deliveryhero.io/image/talabat/Menuitems/%D9%81%D8%A7%D9%85%D9%8A%D9%84%D9%89_%D9%81%D9%88%D9%8A%D9%84637879013422961404.jpg?width=172&amp", offer = 0.09f, rate = 1f , RestaurantID = 102 },
            new ProductModel { ProductId = 10, Productname = "Small Mineral", price = 15, describtion = "Water Bottle", img = "https://t0.gstatic.com/images?q=tbn:ANd9GcRDvWTfXzH-61_ZP_fCAzjo6YPcd-CAKoL3dxAcKYe1tgjQ5yYO", offer = 0.09f, rate = 3f , RestaurantID = 102 },
            new ProductModel { ProductId = 11, Productname = "Tuna Salad", price = 55, describtion = "tuna and mayonnaise", img = "https://littlesunnykitchen.com/wp-content/uploads/2022/12/Tuna-Salad-1.jpg", offer = 0.0f, rate = 4f , RestaurantID = 103 },
            new ProductModel { ProductId = 12, Productname = "Greek Salad", price = 40, describtion = "pieces of tomatoes, cucumbers, onion, feta cheese, and olives and dressed with salt, Greek oregano, and olive oil", img = "https://hips.hearstapps.com/hmg-prod/images/greek-salad-index-642f292397bbf.jpg", offer = 0.0f, rate = 4f , RestaurantID = 103 },
            new ProductModel { ProductId = 13, Productname = "Chef", price = 70, describtion = "hard-boiled eggs, a variety of julienned meats", img = "https://www.allrecipes.com/thmb/Q84xeMgnOJPZAUOdNyrb9dbFZr4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/285625-ChefsSalad_MFS_006-2550ecee70ae46dbaec530a58314c99c.jpg", offer = 0.09f, rate = 5f , RestaurantID = 103 },
            new ProductModel { ProductId = 14, Productname = "Turkey With Emmental Cheese", price = 50, describtion = "Freshly made half baguette filled with turkey and Emmental cheese mixed with greens making it the perfect grab-and-go meal", img = "https://gourmetegypt.com/media/catalog/product/t/u/turkey-_-cheese-photo_nk70qlcuxsoq2rfw.jpg", offer = 0.0f, rate = 4f , RestaurantID = 104 },
            new ProductModel { ProductId = 15, Productname = "Roast Beef With Emmental", price = 70, describtion = "Combine the white cheese with the mustard", img = "http://gourmetpedia.net/media/upload/recipe/3398.jpg", offer = 0.0f, rate = 5f , RestaurantID = 104 },
            new ProductModel { ProductId = 16, Productname = "italian sub sandwich", price = 60, describtion = "tuna and mayonnaise", img = "https://static01.nyt.com/images/2022/02/07/dining/as-italian-sub/merlin_201238275_040c2bf1-9f7d-4653-9f83-9b262dd03a05-articleLarge.jpg", offer = 0.0f, rate = 3f , RestaurantID = 104 },
            new ProductModel { ProductId = 17, Productname = "Cabrito", price = 150, describtion = "Mexico meal", img = "https://lh3.googleusercontent.com/WXWvHOubytJUkjYKXTTAi_WIsosuxjsgecB4XKCat1fyy1f60ELPn3p-NPXgzJcf5FixXd_k657H_4aOFPWjdviq6v6495vCKXJl37w", offer = 0.0f, rate = 4f , RestaurantID = 104 },
            new ProductModel { ProductId = 18, Productname = "Onion Rings", price = 80, describtion = "A famous \"Shack Snack\", our onion rings are served with delicious whale sauce", img = "https://www.seafoodshack.com/wp-content/uploads/2015/04/Onion-Rings-Website-FI-500x375.jpg", offer = 0.7f, rate = 5f , RestaurantID = 105 },
            new ProductModel { ProductId = 19, Productname = "Almond stuffed rainbow trout", price = 220, describtion = "A delicious frozen cocktail made with Tres Agaves Tequila, Triple Sec, Tres Agaves Organic Margarita Mix, fresh lime and a splash of orange juice", img = "https://www.seafoodshack.com/wp-content/uploads/2015/04/Mango-Margarita-Website-FI-500x375.jpg", offer = 0.2f, rate = 4f , RestaurantID = 101 },
            new ProductModel { ProductId = 20, Productname = "Fish Tacos", price = 130, describtion = "Seasoned fresh local catch, colby jack cheese, napa cabbage and baja sauce served in crispy corn tortillas", img = "https://www.seafoodshack.com/wp-content/uploads/2015/04/FishTacos-Website-FI-500x375.jpg", offer = 0.5f, rate = 5f , RestaurantID = 106 }
        );
        #endregion //comminted

        #region product Tags seed
        modelBuilder.Entity<ProductTag>().HasData(
            new ProductTag { ProductId = 1, tag = "vegetarian" },
            new ProductTag { ProductId = 1, tag = "local" },
            new ProductTag { ProductId = 2, tag = "vegetarian" },
            new ProductTag { ProductId = 2, tag = "local" },
            new ProductTag { ProductId = 3, tag = "vegetarian" },
            new ProductTag { ProductId = 3, tag = "local" },
            new ProductTag { ProductId = 4, tag = "local" },
            new ProductTag { ProductId = 5, tag = "local" },
            new ProductTag { ProductId = 6, tag = "local" },
            new ProductTag { ProductId = 7, tag = "local" },
            new ProductTag { ProductId = 8, tag = "local" },
            new ProductTag { ProductId = 9, tag = "local" },
            new ProductTag { ProductId = 10, tag = "local" },
            new ProductTag { ProductId = 11, tag = "local" },
            new ProductTag { ProductId = 11, tag = "healthy" },
            new ProductTag { ProductId = 12, tag = "healthy" },
            new ProductTag { ProductId = 13, tag = "healthy" },
            new ProductTag { ProductId = 14, tag = "healthy" },
            new ProductTag { ProductId = 15, tag = "healthy" },
            new ProductTag { ProductId = 16, tag = "healthy" },
            new ProductTag { ProductId = 17, tag = "healthy" },
            new ProductTag { ProductId = 18, tag = "healthy" },
            new ProductTag { ProductId = 19, tag = "healthy" },
            new ProductTag { ProductId = 20, tag = "healthy" },
            new ProductTag { ProductId = 20, tag = "vegetarian" }
            );
        #endregion

        #region Restaurant seed
        modelBuilder.Entity<RestaurantModel>().HasData(
            new RestaurantModel { Id = 100, RestaurantName = "Mohamed Ahmed", UserName = "MohamedAhmed", NormalizedUserName = "MohamedAhmed", Address = "test", Email = "test", PaymentMethods = PaymentType.Cash, Logo = "https://images.deliveryhero.io/image/talabat/restaurants/21167986_13580950369_637438183491941065.jpg?width=180", Phone = "+20 111 111 1111" },
            new RestaurantModel { Id = 101, RestaurantName = "KFC", UserName = "KFC", NormalizedUserName = "KFC", Address = "test", Email = "test", PaymentMethods = PaymentType.Cash, Logo = "https://upload.wikimedia.org/wikipedia/sco/b/bf/KFC_logo.svg", Phone = "+20 111 111 1111" },
            new RestaurantModel { Id = 102, RestaurantName = "Koshary El Tahrir", UserName = "Central", NormalizedUserName = "Central", Address = "Av. Pedro de Osma 301, Barranco, Lima, Peru", Email = "test", PaymentMethods = PaymentType.Both, Logo = "https://centralrestaurante.com.pe/assets/images/facebook.jpg", Phone = "+51 1 242 8515" },
            new RestaurantModel { Id = 103, RestaurantName = "The Tasty Bistro", UserName = "TheTastyBistro", NormalizedUserName = "TheTastyBistro", Address = "123 Main Street", Email = "info@tastybistro.com", PaymentMethods = PaymentType.Cash, Logo = "https://img.freepik.com/free-vector/detailed-chef-logo-template_23-2148987940.jpg?size=626&ext=jpg&ga=GA1.1.118802800.1685470637&semt=ais", Phone = "+20 111 111 1111" },
            new RestaurantModel { Id = 104, RestaurantName = "Chez Gaby", UserName = "ChezGaby", NormalizedUserName = "ChezGaby", Address = "off of Fouad Street, close to the Alexandria Opera House", Email = "www.ChezGaby.com", PaymentMethods = PaymentType.Cash, Logo = "https://www.zumtaugwald.ch/uploads/8iADQWOr/chezgaby_farbig_gross_198.gif", Phone = "+20 111 111 1111" },
            new RestaurantModel { Id = 105, RestaurantName = "Negro", UserName = "Negro", NormalizedUserName = "Negro", Address = "test", Email = "www.Negro.com", PaymentMethods = PaymentType.Cash, Logo = "https://cerronegrorestaurant.com/wp-content/uploads/2022/06/logo-1.png", Phone = "+20 111 111 1111" },
            new RestaurantModel { Id = 106, RestaurantName = "The Seafood Shack", UserName = "seafoodshack", NormalizedUserName = "seafoodshack", Address = "test", Email = "567 Walnut Lane", PaymentMethods = PaymentType.Cash, Logo = "https://img.freepik.com/premium-vector/fresh-seafood-restaurant-premium-logo_187482-625.jpg?w=2000", Phone = "+20 111 111 1111" });

        #endregion

        #region Customer Seed
        modelBuilder.Entity<CustomerModel>().HasData(
   new CustomerModel
   {
       Id = 2,
       UserName = "testmohamed",
       NormalizedUserName = "testmohamed",
       Email = "hassan@gmail.com",
       BirthDate = new DateTime(1999, 3, 24),
       CustomerAddress = "Gleem",
       PhoneNumber = "1234567890",



   },
        new CustomerModel
        {
            Id = 3,
            UserName = "ramymohamed",
            NormalizedUserName = "ramymohamed",
            Email = "hamdy@gmail.com",
            BirthDate = new DateTime(2002, 3, 24),
            CustomerAddress = "Sanstifano",
            PhoneNumber = "1234237890",


        }
            );
        modelBuilder.Entity<CreditCard>().HasData(
new CreditCard { CreditId = 1, Card_Expiration_Date = new DateTime(2024, 3, 12), Card_Number = "1234123412341234", CVV = "333", CustomerId = 2 },
new CreditCard { CreditId = 2, Card_Expiration_Date = new DateTime(2026, 7, 22), Card_Number = "1212121212121212", CVV = "229", CustomerId = 3 });

        #endregion









        base.OnModelCreating(modelBuilder);


    }

}
