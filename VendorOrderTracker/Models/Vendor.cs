namespace VendorOrderTracker.Models;

public class Vendor 
{
  public string Name {get; set;}
  public string Description {get; set;}
  public List<Order> OrderList {get; set;}

  public Vendor()
  {

  }

  public Vendor(string name, string description)
  {
    this.Name = name;
    this.Description = description;
  }



}