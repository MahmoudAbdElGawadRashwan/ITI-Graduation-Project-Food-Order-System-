using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CreditToRead
{

    public int CustomerId { get; set; }


    public string? Card_Number { get; set; } = string.Empty;
    public DateTime Card_Expiration_Date { get; set; }
    public string CVV { get; set; }
}


