namespace FoodOrderSystemAPI.BL.DTOs.Restaurants
{
    public class RestaurantProductsDto
    {
        public ICollection<ProductCardDto> Products { set; get; } = new HashSet<ProductCardDto>();
    }
}