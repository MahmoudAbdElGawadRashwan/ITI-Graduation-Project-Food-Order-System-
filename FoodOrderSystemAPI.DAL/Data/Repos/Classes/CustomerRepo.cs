using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FoodOrderSystemAPI.DAL;

public class CustomerRepo : EntityRepo<CustomerModel>, ICustomerRepo

{
    private readonly SystemContext _dbcontext;
    public CustomerRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbcontext = dbContext;
    }

    public void CancelOrder()
    {
        
    }

    public List<CustomerModel> GetAllWithNavProp()
    {
      return  _dbcontext.Customers.Include(s=>s.CustomerCreditCard).ToList();
    } 
    public CustomerModel GetCustomerByIdWithNavprop(int id)
    {
      return  _dbcontext.Customers.Include(s=>s.CustomerCreditCard).FirstOrDefault(c=>c.Id == id );
    }

    public void Login()
    {
        throw new NotImplementedException();
    }

    public int MakeOrder()
    {
        throw new NotImplementedException();
    }

    public void Pay()
    {
        throw new NotImplementedException();
    }

    public void RateProduct()
    {
        throw new NotImplementedException();
    }

    public void Register()
    {
      
    }
}

