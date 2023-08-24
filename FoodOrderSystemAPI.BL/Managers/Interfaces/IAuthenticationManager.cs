using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public interface IAuthenticationManager
{
    public  Task<TokenDto> LoginAsUser(UserLogin _UserLogin);
    public  Task<TokenDto> LoginAsResturant(UserLogin ResturantLogin);
    public  Task<TokenDto> LoginAsCustomer(UserLogin NewLoginCustomer);

}
