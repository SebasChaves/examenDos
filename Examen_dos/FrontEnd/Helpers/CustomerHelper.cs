
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontEnd.Helpers
{
    public class CustomerHelper
    {
        private ServiceRepository ServiceRepository;


        public CustomerHelper()
        {
            ServiceRepository= new ServiceRepository();
        }



        public List<CustomerViewModel> GetAll()
        {
            List<CustomerViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Customer/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista= JsonConvert.DeserializeObject<List<CustomerViewModel>>(content);



            return lista;
        }

        public CustomerViewModel Get(int id)
        {
            CustomerViewModel customer;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Customer/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            customer = JsonConvert.DeserializeObject<CustomerViewModel>(content);



            return customer;
        }


        public CustomerViewModel Create(CustomerViewModel customer) {


            CustomerViewModel Customer;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Customer/", customer);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Customer = JsonConvert.DeserializeObject<CustomerViewModel>(content);



            return Customer;
        }




        public CustomerViewModel Edit(CustomerViewModel customer)
        {


            CustomerViewModel Customer;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Customer/", customer);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Customer = JsonConvert.DeserializeObject<CustomerViewModel>(content);



            return Customer;
        }



        public CustomerViewModel Delete(int id)
        {


            CustomerViewModel Customer;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Customer/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Customer = JsonConvert.DeserializeObject<CustomerViewModel>(content);



            return Customer;
        }

    } 




    }

