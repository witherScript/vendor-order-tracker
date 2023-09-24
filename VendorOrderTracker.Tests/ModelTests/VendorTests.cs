using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorOrderTracker.Models;
using System;

namespace VendorOrderTracker.Test;
#nullable enable

[TestClass]
public class VendorTest
{
  [TestMethod]
  public void VendorConstructor_CreatesInstanceOfVendor_Void()
  {
    Vendor greg = new Vendor();
    Assert.AreEqual(typeof(Vendor), greg.GetType());
  }

  [TestMethod]
  public void SetGetName_SetandGetNameVendor_Void()
  {
    Vendor greg = new Vendor();
    string name = "greg!";
    greg.Name = name;
    Assert.AreEqual(name, greg.Name);
  }

  [TestMethod]
  public void SetDesc_SetsNameVendor_Void()
  {
    Vendor greg = new Vendor();
    string desc = "HE SELLS BREAD!";
    greg.Description = desc;
    Assert.AreEqual(desc, greg.Description);
  }

  //implementing Order class to make the OrderList compile
  [TestMethod]
  public void AddOrder_ShouldAddOrderToList_Void()
  {
    Vendor greg = new Vendor("greg", "bread seller");
    Order loaf = new Order(12.00, "Greg's Order", "1 Loaf from Greg");
    greg.AddOrder(loaf);

    Assert.AreEqual(greg.OrderList[0], loaf);
  } 

  [TestMethod]
  public void GetById_ShouldReturnOrderByID_Order()
  {

    Vendor greg = new Vendor("greg", "bread seller");
    Order loaf = new Order(12.00, "Greg's Order", "1 Loaf from Greg");
    greg.AddOrder(loaf);

    Order? actual = greg.GetOrderById(loaf.OrderId);
    
    Assert.AreEqual(loaf, actual);

  }




}