using System.Collections.Generic;

namespace VendorOrderTracker.Models;

public class Order
{
  public double Total {get; set;}
  public string Title {get; set;}
  public string Description {get; set;}
  public int OrderId {get; set;}

  public Order()
  {


  }

  public Order(double total, string title, string desc)
  {
    this.Total = total;
    this.Title = title;
    this.Description = desc;
  }

}