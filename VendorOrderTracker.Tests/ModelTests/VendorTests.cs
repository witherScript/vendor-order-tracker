using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorOrderTracker.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace VendorOrderTracker.Test;
#nullable enable

[TestClass]
public class VendorTest:IDisposable
{ 
  public IConfiguration Configuration {get; set;}

  public void Dispose()
  {
    Vendor.ClearAll();
  }

  public VendorTest()
  {
    IConfigurationBuilder builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");
    Configuration = builder.Build();
    DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
  }

  [TestMethod]
  public void GetAll_ReturnsVendors_VendorList()
  {
    //Arrange
    string name01 = "breg";
    string name02 = "node";
    string description01 = "Bread Retailer";
    string description02 = "Beef retailer";

    Vendor newVendor = new Vendor(name01, description01);
    Vendor newVendor2 = new Vendor(name02, description02);

    List<Vendor> newList = new List<Vendor>() { newVendor, newVendor2 };

    Console.WriteLine(newList[0].Name);
    Console.WriteLine(newList[1].Name);

    newVendor.Save();
    newVendor2.Save();

    Console.WriteLine(Vendor.GetAll()[0].Name);
    Console.WriteLine(Vendor.GetAll()[1].Name);
    //Assert
    CollectionAssert.AreEqual(newList, Vendor.GetAll());

    //Cleanup
    Dispose();
  }


  // [TestMethod]
  // public void VendorConstructor_CreatesInstanceOfVendor_Void()
  // {
  //   Vendor greg = new Vendor();
  //   Assert.AreEqual(typeof(Vendor), greg.GetType());
  // }

  // [TestMethod]
  // public void SetGetName_SetandGetNameVendor_Void()
  // {
  //   Vendor greg = new Vendor();
  //   string name = "greg!";
  //   greg.Name = name;
  //   Assert.AreEqual(name, greg.Name);
  // }

  // [TestMethod]
  // public void SetDesc_SetsNameVendor_Void()
  // {
  //   Vendor greg = new Vendor();
  //   string desc = "HE SELLS BREAD!";
  //   greg.Description = desc;
  //   Assert.AreEqual(desc, greg.Description);
  // }

  // //implementing Order class to make the OrderList compile
  // [TestMethod]
  // public void AddOrder_ShouldAddOrderToList_Void()
  // {
  //   Vendor greg = new Vendor("greg", "bread seller");
  //   Order loaf = new Order(12.00, "Greg's Order", "1 Loaf from Greg");
  //   greg.AddOrder(loaf);

  //   Assert.AreEqual(greg.OrderList[0], loaf);
  // } 

  // [TestMethod]
  // public void GetById_ShouldReturnOrderByID_Order()
  // {

  //   Vendor greg = new Vendor("greg", "bread seller");
  //   Order loaf = new Order(12.00, "Greg's Order", "1 Loaf from Greg");
  //   greg.AddOrder(loaf);

  //   Order? actual = greg.GetOrderById(loaf.OrderId);
    
  //   Assert.AreEqual(loaf, actual);

  // }
}