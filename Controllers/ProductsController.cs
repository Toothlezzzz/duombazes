using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stationary_shop.Repositories;
using Microsoft.AspNetCore.Mvc;
using stationary_shop.Models;

namespace stationary_shop.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(ProductsRepo.List());
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var product = ProductsRepo.Find(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(string id, Products product)
        {
           if(ModelState.IsValid)
           {
                ProductsRepo.Update(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var product = new Products();
            return View(product);
        }


        [HttpPost]
        public ActionResult Create(Products product)
        {
            if(ModelState.IsValid)
            {
                ProductsRepo.Insert(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(string id)
        {
            try
            {
                ProductsRepo.Delete(id);

                return RedirectToAction("Index");
            }
            catch( MySql.Data.MySqlClient.MySqlException)
            {
                ViewData["deletionNotPermitted"] = true;

                var customer = ProductsRepo.Find(id);       
                return View("Delete", customer);
            }
        }
        
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var customer = ProductsRepo.Find(id);
            return View(customer);
        }
    }
}