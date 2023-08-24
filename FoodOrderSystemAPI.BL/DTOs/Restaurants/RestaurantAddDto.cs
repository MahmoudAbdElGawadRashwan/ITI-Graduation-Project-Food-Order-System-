using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystemAPI.BL;

public class RestaurantAddDto
{
    public string RestaurantName { set; get; } = string.Empty;
    public string Address { set; get; } = string.Empty;
    public string Logo { set; get; } = string.Empty;
    public string Phone { set; get; } = string.Empty;
    public PaymentType PaymentMethods { set; get; } = PaymentType.Cash;
    [EmailAddress]
    public string Email { get; set; }
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
      ErrorMessage = "The password must contain at least 8 characters, including one lowercase letter," +
        " one uppercase letter, one digit, and one special character.")]
    public string Password { get; set; }
    public string UserName { get; set; }
}
