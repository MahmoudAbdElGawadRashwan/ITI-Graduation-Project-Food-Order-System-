namespace FoodOrderSystemAPI.BL;

public class RestaurantUpdateDto
{
    public int Id { get; set; }
    public string RestaurantName { set; get; } = string.Empty;
    public string Address { set; get; } = string.Empty;
    public string Logo { set; get; } = string.Empty;
    public string Phone { set; get; } = string.Empty;
    public PaymentType PaymentMethods { set; get; } = PaymentType.Cash;

}
