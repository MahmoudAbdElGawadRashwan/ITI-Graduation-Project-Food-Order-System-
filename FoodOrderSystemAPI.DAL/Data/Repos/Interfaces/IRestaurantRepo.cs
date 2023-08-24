namespace FoodOrderSystemAPI.DAL
{
    public interface IRestaurantRepo : IEntityRepo<RestaurantModel>
    {
        public IEnumerable<RestaurantModel?> GetRestaurantsWithProducts();
        //public string? GetPaymentMethodById(int id);
        public IEnumerable<ProductModel>? GetRestaurantProductsById(int id);
    }
}
