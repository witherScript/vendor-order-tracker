using System.Collections.Generic;
using MySqlConnector;
namespace VendorOrderTracker.Models;

public class Vendor 
{
  public string Name {get; set;}
  public string Description {get; set;}
  public List<Order> OrderList {get; set;}
  public int VendorId{get; set;}

  
  public Vendor()
  {

  }

  public Vendor(string name, string description)
  {
    this.Name = name;
    this.Description = description;
    OrderList = new List<Order>();

  }

  public Vendor(string name, string desc, int id)
  {
    Name = name;
    Description = desc;
    VendorId = id;
  }

  public void Save()
  {
    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

    cmd.CommandText = "INSERT INTO vendors (title, description) VALUES (@VendorName, @VendorDescription);";
    cmd.Parameters.AddWithValue("@VendorName", this.Name);
    cmd.Parameters.AddWithValue("@VendorDescription", this.Description);
    cmd.ExecuteNonQuery();
    VendorId = (int) cmd.LastInsertedId;

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }

  public override bool Equals(System.Object otherVendor)
  {
    if (!(otherVendor is Vendor))
    {
      return false;
    }
    else
    {
      Vendor newVendor = (Vendor) otherVendor;
      bool idEquality = (this.VendorId == newVendor.VendorId);
      bool descriptionEquality = (this.Description == newVendor.Description);
      return (idEquality && descriptionEquality);
    }
  }

  public override int GetHashCode()
  {
      return VendorId.GetHashCode();
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

  public static List<Vendor> GetAll()
  {
    List<Vendor> allVendors = new List<Vendor>();
    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    MySqlCommand cmd = conn.CreateCommand();
    
    conn.Open();
    cmd.CommandText = "SELECT * FROM vendors";
    MySqlDataReader rdr = cmd.ExecuteReader();
    while (rdr.Read())
    {
      string vendorName = rdr.GetString(1);
      string vendorDesc = rdr.GetString(2);
      Vendor fromData = new Vendor(vendorName, vendorDesc);
      allVendors.Add(fromData);
    }

    return allVendors;    
  }

  public static Vendor Find(int id)
{
  // We open a connection.
  MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
  conn.Open();

  // We create MySqlCommand object and add a query to its CommandText property. 
  // We always need to do this to make a SQL query.
  MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = "SELECT * FROM vendors WHERE id = @ThisId;";

  // We have to use parameter placeholders @ThisId and a `MySqlParameter` object to 
  // prevent SQL injection attacks. 
  // This is only necessary when we are passing parameters into a query. 
  // We also did this with our Save() method.
  MySqlParameter param = new MySqlParameter();
  param.ParameterName = "@ThisId";
  param.Value = id;
  cmd.Parameters.Add(param);

  // We use the ExecuteReader() method because our query will be returning results and 
  // we need this method to read these results. 
  // This is in contrast to the ExecuteNonQuery() method, which 
  // we use for SQL commands that don't return results like our Save() method.
  MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
  int vendorId = 0;
  string vendorDescription = "";
  string vendorTitle="";
  while (rdr.Read())
  {
    vendorId = rdr.GetInt32(0);
    vendorTitle = rdr.GetString(1);
    vendorDescription = rdr.GetString(2);
  }
  Vendor foundVendor = new Vendor(vendorTitle, vendorDescription, vendorId);

  // We close the connection.
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
  return foundVendor;
}

  public static void ClearAll()
  {
    using (MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString))
    using (MySqlCommand cmd = conn.CreateCommand())
    {
      conn.Open();
      cmd.CommandText = "DELETE FROM vendors;";
      cmd.ExecuteNonQuery();
    }
  }
}
