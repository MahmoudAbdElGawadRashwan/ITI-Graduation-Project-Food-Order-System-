namespace FoodOrderSystemAPI.BL;

public class RestaurantDetailsDto
{
    public int RestaurantId { get; set; } = 0;
    public string UserName { set; get; } = string.Empty;
    public string Email { set; get; } = string.Empty;
    public string NormalizedUserName { set; get; } = string.Empty;
    public string RestaurantName { set; get; } = string.Empty;
    public string Address { set; get; } = string.Empty;
    public string Logo { set; get; } = string.Empty;
    public string Phone { set; get; } = string.Empty;
    public PaymentType PaymentMethods { set; get; } = PaymentType.Cash;
}
