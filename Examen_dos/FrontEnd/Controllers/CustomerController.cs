using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CustomerController : Controller
    {
        CustomerHelper customerHelper= new CustomerHelper();


        // GET: EmpleadoController
        public ActionResult Index()
        {
            List<CustomerViewModel> lista = customerHelper.GetAll();
            return View(lista); ;
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            CustomerViewModel customer = customerHelper.Get(id);

            return View(customer);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customer)
        {
            try
            {
                customer = customerHelper.Create(customer);
                return RedirectToAction("Details", new { id = customer.CustomerId });
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerViewModel customer = customerHelper.Get(id);

            return View(customer);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel customer)
        {
            try
            {
                customer = customerHelper.Edit(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            CustomerViewModel customer = customerHelper.Get(id);

            return View(customer);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerViewModel customer)
        {
            try
            {
                customerHelper.Delete(customer.CustomerId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }
        }
    }
}
