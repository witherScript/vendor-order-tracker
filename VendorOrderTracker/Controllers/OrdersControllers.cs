using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;
using System.Collections.Generic;

namespace VendorOrderTracker.Controllers;

public class OrdersController:Controller
{
  [HttpGet("/vendors/{VendorId}/orders/new")]
    public ActionResult New(int VendorId)
    {
      //Vendor vendor = Vendor.GetById(VendorId);
      return View();
    }
}