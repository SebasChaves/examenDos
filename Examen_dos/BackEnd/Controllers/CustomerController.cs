using DAL.Implementations;
using DAL.Interfaces;
using BackEnd.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private ICustomerDAL customerDAL;
        public CustomerController(ILogger<CustomerController> logger)
        {
            customerDAL = new CustomerDALImpl(new Entities.AdventureWorks2016Context());
            this.logger = logger;
        }


 
        private CustomerModel Convertir(Customer entity)
        {
            return new CustomerModel
            {
                AccountNumber = entity.AccountNumber,
                CustomerId = entity.CustomerId,
                ModifiedDate = entity.ModifiedDate,
                PersonId = entity.PersonId,
                Rowguid = entity.Rowguid,
                StoreId = entity.StoreId,
                TerritoryId = entity.TerritoryId
            };
        }


        private Customer Convertir(CustomerModel entity)
        {
            return new Customer
            {
                AccountNumber = entity.AccountNumber,
                CustomerId = entity.CustomerId,
                ModifiedDate = entity.ModifiedDate,
                PersonId = entity.PersonId,
                Rowguid = entity.Rowguid,
                StoreId = entity.StoreId,
                TerritoryId = entity.TerritoryId
            };
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Customer> customers = customerDAL.GetAll();

                List<CustomerModel> lista = new List<CustomerModel>();

                foreach (var customer in customers)
                {
                    lista.Add(Convertir(customer)

                        );
                }
                return new JsonResult(lista);
            }
            catch (Exception e)
            {
                return new JsonResult(null);
            }


        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Customer customer = customerDAL.Get(id);
            return new JsonResult(customer);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public JsonResult Post([FromBody] CustomerModel value)
        {
            Customer entity = Convertir(value);
            customerDAL.Add(entity);
            return new JsonResult(Convertir(entity));
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CustomerModel value)
        {

            customerDAL.Update(Convertir(value));
            return new JsonResult(Convertir(value));
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Customer customer = new Customer { CustomerId= id };
            customerDAL.Remove(customer);

            return new JsonResult(Convertir(customer));
        }
    }
}