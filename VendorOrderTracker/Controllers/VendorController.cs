using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers;


public class VendorController : Controller
{
  [HttpGet("/vendors")]
  public ActionResult Index()
  {
    List<Vendor> vendorList = Vendor.GetAll();
    return View(vendorList);
  }

  [HttpGet("/vendors/new")]
  public ActionResult New()
  {
    return View();
  }

  [HttpPost("/vendors")]
  public ActionResult Create(string vendorName, string vendorDesc)
  {
    Vendor greg = new Vendor(vendorName, vendorDesc);
    return RedirectToAction("Index");
  }


  [HttpGet("/vendors/{id}/orders")]
  public ActionResult Show(int id)
  {
    Dictionary<string, object> model = new Dictionary<string, object>();
    Vendor vendor = new Vendor();
    List<Order> orders = vendor.OrderList;
    model.Add("vendor", vendor);
    model.Add("orders", orders);

    return View(model);
  }

  [HttpPost("/vendors/{id}/orders/")]
   public ActionResult Create(int VendorId, string orderTitle, string orderDescription, double orderTotal)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor vendor = new Vendor();
      Order newOrder = new Order(orderTotal, orderTitle, orderDescription);
      
      vendor.AddOrder(newOrder);
      List<Order> orders = vendor.OrderList;
      model.Add("orders", orders);
      model.Add("vendor", vendor);
      return View("Show", model);
    }

  


}