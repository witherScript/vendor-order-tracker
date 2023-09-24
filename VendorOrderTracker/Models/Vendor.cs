using System.Collections.Generic;
namespace VendorOrderTracker.Models;

public class Vendor 
{
  public string Name {get; set;}
  public string Description {get; set;}
  public List<Order> OrderList {get; set;}
  public int VendorId{get;}

  private static List<Vendor> _allVendors = new List<Vendor>();
  public Vendor()
  {

  }

  public Vendor(string name, string description)
  {
    this.Name = name;
    this.Description = description;
    OrderList = new List<Order>();
    _allVendors.Add(this);
    this.VendorId = _allVendors.Count;

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

  public static Vendor GetById(int vID)
  {
    return _allVendors[vID-1];
  }
  public static  List<Vendor> GetAll()
  {
    return _allVendors;
  }



}