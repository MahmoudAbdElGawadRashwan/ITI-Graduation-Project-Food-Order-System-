using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class ProductAddDto
{

    public String Productname { get; set; } = "";

    public float price { get; set; }

    public String describtion { get; set; } = "";

    public String img { get; set; } = "";

    public float offer { get; set; }

    public float rate { get; set; }

    public List<string> tags { get; set; } = new List<string>();
    public int restaurantID { get; set; }

}
