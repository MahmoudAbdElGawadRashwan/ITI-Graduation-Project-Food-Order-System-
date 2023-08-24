namespace FoodOrderSystemAPI.BL.DTOs.Restaurants
{
    public class RestaurantsProductsReadDto
    {
        public string RestaurantName { set; get; } = string.Empty;
        public string Address { set; get; } = string.Empty;
        public string Logo { set; get; } = string.Empty;
        public string Phone { set; get; } = string.Empty;
        public PaymentType PaymentMethods { set; get; } = PaymentType.Cash;
        public ICollection<ProductModel> Products { set; get; } = new HashSet<ProductModel>();
    }
}