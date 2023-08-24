using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;


public class CreditCard
{
  
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CreditId { get; set; }
    [ForeignKey(nameof(Customer))]
    public  int CustomerId { get; set; }
    public  CustomerModel Customer { get; set; }

    // Maintainance (1) => Remove Validation on Credit Card 

    public string? Card_Number { get; set; } = string.Empty;
    public DateTime Card_Expiration_Date { get; set; }
    public string CVV  { get; set; }
}
