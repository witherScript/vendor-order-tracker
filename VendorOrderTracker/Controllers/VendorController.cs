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
}