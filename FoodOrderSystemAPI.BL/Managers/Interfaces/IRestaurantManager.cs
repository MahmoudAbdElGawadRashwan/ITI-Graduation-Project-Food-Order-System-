using FoodOrderSystemAPI.BL.DTOs.Restaurants;

namespace FoodOrderSystemAPI.BL;

public interface IRestaurantManager
{
    List<RestaurantsReadDto> GetAllRestaurants();
    RestaurantDetailsDto? GetRestaurantDetailsById(int id);
    List<RestaurantsProductsReadDto> GetAllRestaurantsWithProducts();
    RestaurantPaymentMethodDto? GetRestaurantPaymentMethodsById(int id);
    RestaurantProductsDto? GetRestaurentWithProductsById(int id);
    Task<TokenDto> AddRestaurant(RestaurantAddDto restaurantDto);
    UpdateStatusEnum UpdateRestaurant(RestaurantUpdateDto restaurantDto);
    public List<OrderResturntReadDto> GetOrdersByResturantId(int ResturantId);

    DeleteStatusEnum DeleteRestaurant(int id);
}