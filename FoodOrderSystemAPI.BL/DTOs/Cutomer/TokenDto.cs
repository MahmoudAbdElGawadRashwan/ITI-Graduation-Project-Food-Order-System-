using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class TokenDto
{
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
}
