namespace FoodOrderSystemAPI.BL.DTOs.Restaurants
{
    public class RestaurantPaymentMethodDto
    {
        public string RestaurantName { set; get; } = string.Empty;
        public PaymentType PaymentMethods { set; get; } = PaymentType.Cash;
    }
}