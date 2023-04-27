using System;
using Microsoft.AspNetCore.Mvc;
using stationary_shop.Repositories;
using stationary_shop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace stationary_shop.Controllers
{
    public class CustomersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(CustomersRepo.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var customer = new Customers();
            return View(customer);
        }


        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if(ModelState.IsValid)
            {
                CustomersRepo.Insert(customer);

                return RedirectToAction("Index");
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var customer = CustomersRepo.Find(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(string id, Customers customer)
        {
           // if(ModelState.IsValid)
           // {
                CustomersRepo.Update(customer);

                return RedirectToAction("Index");
            //}
            //return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var customer = CustomersRepo.Find(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(string id)
        {
            try
            {
                CustomersRepo.Delete(id);

                return RedirectToAction("Index");
            }
            catch( MySql.Data.MySqlClient.MySqlException)
            {
                ViewData["deletionNotPermitted"] = true;

                var customer = CustomersRepo.Find(id);       
                return View("Delete", customer);
            }
        }
    }
}