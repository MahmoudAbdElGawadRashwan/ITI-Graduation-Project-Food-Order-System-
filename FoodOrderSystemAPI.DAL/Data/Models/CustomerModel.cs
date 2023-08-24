using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI
{
    [Table("CustomerModel")]

    public class CustomerModel : UserModel
    {



        public DateTime BirthDate { get; set; }

        public string CustomerAddress { get; set; }

        public CreditCard CustomerCreditCard { get; set; } 

     

        [InverseProperty("Customer")]
        public  ICollection<OrderModel> Orders { get; set; } = new HashSet<OrderModel>();
        [InverseProperty("Customer")]
        public  ICollection<ReviewModel> Reviews { get; set; } = new HashSet<ReviewModel>();






    }
}
