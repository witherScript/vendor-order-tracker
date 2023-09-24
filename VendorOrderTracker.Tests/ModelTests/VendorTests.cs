using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorOrderTracker.Models;
using System;

namespace VendorOrderTracker.Test;

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
  public void SetName_SetsNameVendor_Void()
  {
    Vendor greg = new Vendor();
    string name = "greg!";
    greg.Name = name;
    Assert.AreEqual(name, greg.Name);
  }
}