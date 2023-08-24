using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class ProductOrder
{
    public String Productname { get; set; } = "";

    public float price { get; set; }
    public int Quantity { get; set; }
    public float QuantityPrice { get; set; }


    public String img { get; set; } = "";


}
