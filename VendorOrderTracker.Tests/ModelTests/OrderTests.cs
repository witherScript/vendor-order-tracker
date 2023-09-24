using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorOrderTracker.Models;
using System;

namespace VendorOrderTracker.Test;

[TestClass]
public class OrderTest
{
  [TestMethod]
  public void OrderConstructor_CreatesInstanceOfOrder_Void()
  {
    Order loaf = new Order();
    Assert.AreEqual(typeof(Order), loaf.GetType());
  }
}