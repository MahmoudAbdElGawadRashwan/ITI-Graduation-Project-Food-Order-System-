using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public interface ICustomerManager
{
    public   Task< TokenDto> Register(CustomerToRegister RegisterdCustomer);
    public List<CustomerModel> GetAllCutomers();
    public List<CustomerToRead> ReadAllCutomerProperties();

    public CreditToRead UpdateCardCutomerData(int Customerid, CreditToUpdate creditCard);
    public  Task<CustomerModel> UpdateCustomerPersonalData(int Customerid, CustomerToUpdatPersonalData UpdatedCustomer);
    public CustomerToRead GetById(int CustomerID );
        public bool Delete( int CustomerID);
}
