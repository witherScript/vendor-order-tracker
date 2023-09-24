using System.Collections.Generic;
namespace VendorOrderTracker.Models;

public class Vendor 
{
  public string Name {get; set;}
  public string Description {get; set;}
  public List<Order> OrderList {get; set;}

  private static List<Vendor> _allVendors = new List<Vendor>();
  public Vendor()
  {

  }

  public Vendor(string name, string description)
  {
    this.Name = name;
    this.Description = description;
    OrderList = new List<Order>();
  }

  public void AddOrder(Order toAdd)
  {
    OrderList.Add(toAdd);
    toAdd.OrderId = OrderList.Count;
  }

  public Order GetOrderById(int oID)
  {
    return OrderList[oID-1];
  }

  public static  List<Vendor> GetAll()
  {
    return _allVendors;
  }
  


}