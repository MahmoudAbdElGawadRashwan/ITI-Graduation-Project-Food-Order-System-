using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.DAL;

public class DateInPast: ValidationAttribute
{
  
    public override bool IsValid(object value)
    {
        if (value is DateTime dateValue)
        {
            return dateValue < DateTime.Now;
        }

        return false;
    }


}

public class DateInFuture : ValidationAttribute
{

    public override bool IsValid(object value)
    {
        if (value is DateTime dateValue)
        {
            return dateValue > DateTime.Now;
        }

        return false;
    }


}
