using System;
using Microsoft.AspNetCore.Mvc;
using stationary_shop.Repositories;
using stationary_shop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Autonuoma.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(OrdersRepo.List());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var order = new Orders();
            //PopulateSelections(narys);
            return View(order);
        }


        [HttpPost]
        public ActionResult Create(Orders order)
        {
           

            if(ModelState.IsValid)
            {
                OrdersRepo.Insert(order);

                return RedirectToAction("Index");
            }
            //PopulateSelections(narys);
            return View(order);
        }

        // [HttpPost]
        // public ActionResult Edit(string id, Narys narys)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         OrdersRepo.Update(narys);

        //         return RedirectToAction("Index");
        //     }
        //     PopulateSelections(narys);
        //     return View(narys);
        // }

        // [HttpGet]
        // public ActionResult Edit(string id)
        // {
        //     var narys = OrdersRepo.Find(id);
        //     PopulateSelections(narys);

        //     return View(narys);
        // }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var order = OrdersRepo.Find(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult DeleteConfirm(string id)
        {
            try
            {
                OrdersRepo.Delete(id);

                return RedirectToAction("Index");
            }
            catch( MySql.Data.MySqlClient.MySqlException)
            {
                ViewData["deletionNotPermitted"] = true;

                var order = OrdersRepo.Find(id);
                //PopulateSelections(narys);
                
                return View("Delete", order);
            }
        }

        // public void PopulateSelections(Narys narys)
        // {
        //     var lytys = OrdersRepo.ListLytis();

        //     narys.Lists.Lytys =
        //         lytys.Select(it => {
        //             return
        //                 new SelectListItem(){
        //                     Value = Convert.ToString(it.ID),
        //                     Text = it.Name
        //                 };
        //         }).ToList();
        // }
    }
}