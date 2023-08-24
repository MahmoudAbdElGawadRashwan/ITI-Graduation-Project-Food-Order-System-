using FoodOrderSystemAPI.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOrderSystemAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        private readonly IAuthenticationManager _AuthenticationManager;
        public CustomerController(ICustomerManager customerManager, IAuthenticationManager authenticationManager)
        {
            _customerManager = customerManager;
            _AuthenticationManager = authenticationManager;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        //[Authorize("Customer")]
        public ActionResult<List<CustomerModel>> GetAllCustomers()
        {
         return Ok(_customerManager.ReadAllCutomerProperties());
        }

        // GET: api/<CustomerController>/{id}
        [HttpGet("{id}")]
        //[Authorize("Customer")]
        public ActionResult<CustomerToRead> Get(int id)
        {
            var customer = _customerManager.GetById(id);
            if (customer == null)
            {
                BadRequest();
            }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]

        public async Task <ActionResult<TokenDto>> Post(CustomerToRegister ResgiteredCustomer)
        {
            var result =  await _customerManager.Register(ResgiteredCustomer);
            if(result == null) {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer(int id, CustomerToUpdatPersonalData CustomerPersonalData )
        {
          var CustomerUpdated = await  _customerManager.UpdateCustomerPersonalData(id, CustomerPersonalData);
            if (CustomerUpdated is null)

                return NoContent();

            return Ok(CustomerUpdated);
            
        }

        [HttpPatch()]
        [Route("Credit/{CustomerId}")]
        public ActionResult UpdateCredit(int CustomerId, CreditToUpdate CustomerCreditCard)
        {
            var CustomerCreditCardUpdated = _customerManager.UpdateCardCutomerData(CustomerId, CustomerCreditCard);
            if (CustomerCreditCardUpdated is null)
                return NoContent();
            return Ok(CustomerCreditCardUpdated);

        }


        //[HttpPatch()]
        //[Route("Location/{CustomerId}")]

        //public ActionResult UpdateLocation(int CustomerId, LocationToUpadate CustomerAddress)
        //{
        //    var CustomerUpdated = _customerManager.UpdateAddressCutomer(CustomerId, CustomerAddress);
        //    if (CustomerUpdated is null)
        //        return NoContent();
        //    return Ok(CustomerUpdated);

        //}

      
        // Delete api/<CustomerController>/5

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var result = _customerManager.Delete(id);
            if (result)
                // Finded &Deleted
                return Ok();
            //not finded
            return
        BadRequest();
        }
    }
}
