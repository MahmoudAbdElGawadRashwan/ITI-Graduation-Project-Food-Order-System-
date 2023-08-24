using FoodOrderSystemAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class ProductModel
{
    [Key]
    public int ProductId { set; get; }

    public String Productname { set; get; }  = "";

    [Range(0f, float.MaxValue)]     //only +ve values
    public float price { set; get; }

    public String describtion { set; get; } = "";

    public String img { set; get; } = "";

    [Range(0f,1f)]
    public float offer { set; get; }

    [Range(0f,5f)]
    public float rate { set; get; }

    [ForeignKey("restaurant")]
    public int RestaurantID { set; get; }
    public RestaurantModel restaurant { set; get; }

    public ICollection<ProductTag> productTags = new HashSet<ProductTag>();

    public ICollection<OrderProductModel> orderProducts = new HashSet<OrderProductModel>();

   
    public ICollection<ReviewModel> reviews = new HashSet<ReviewModel>();
}
