using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagementSystem.Models;
using System.Configuration;
using System.Data.SqlClient;


namespace ParkingManagementSystem.Controllers
{
    public class ParkingManagementSystemController : Controller
    {
        // GET: ParkingManagementSystem
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ParkingSpotForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ParkingSpotForm(UserInfo userInfo, int id)
        {
            if (ModelState.IsValid)
            {
                //string constr = ConfigurationManager.ConnectionStrings["DatabasePMSEntities"].ConnectionString;
                string connectionStringADO = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Final Projects\\ParkingManagementSystem\\ParkingManagementSystem\\App_Data\\DatabasePMS.mdf\";Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                using (SqlConnection con = new SqlConnection(connectionStringADO))
                {
                    string query = "INSERT INTO Customers_Table(ParkingSlotNumber, Name, Phone, VehicleNumber, UID, ParkingTime) VALUES(@ParkingSlotNumber, @Name, @Phone, @VehicleNumber, @UID, CURRENT_TIMESTAMP)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    userInfo.ParkingSlotNumber = id;
                    cmd.Parameters.AddWithValue("@ParkingSlotNumber", userInfo.ParkingSlotNumber);
                    cmd.Parameters.AddWithValue("@Name", userInfo.Name);
                    cmd.Parameters.AddWithValue("@Phone", userInfo.Phone);
                    cmd.Parameters.AddWithValue("@VehicleNumber", userInfo.VehicleNumber);
                    cmd.Parameters.AddWithValue("@UID", userInfo.UID);
                    cmd.Parameters.AddWithValue("@ParkingTIme", userInfo.Phone);

                    try
                    {
                        con.Open();
                        Int32 rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("RowsAffected: {0}", rowsAffected);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                return View("Thanks", userInfo);
            }            
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult CheckOutForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CheckOutForm(UserInfo userInfo)
        {
            if (userInfo.ParkingSlotNumber > 0)
            {
                //string constr = ConfigurationManager.ConnectionStrings["DatabasePMSEntities"].ConnectionString;
                string connectionStringADO = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Final Projects\\ParkingManagementSystem\\ParkingManagementSystem\\App_Data\\DatabasePMS.mdf\";Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                using (SqlConnection con = new SqlConnection(connectionStringADO))
                {

                    //string query = "INSERT INTO Customers_Table(ParkingSlotNumber, Name, Phone, VehicleNumber, UID, ParkingTime) VALUES(@ParkingSlotNumber, @Name, @Phone, @VehicleNumber, @UID, @ParkingTime)";
                    //string query = "SELECT ParkingTime FROM Customers_Table WHERE ParkingSlotNumber = @ParkingSlotNumber";

                    string query = "SELECT * FROM Customers_Table WHERE ParkingSlotNumber = " + userInfo.ParkingSlotNumber;
                    SqlCommand cmd = new SqlCommand(query, con);

                    string query2 = "UPDATE Customers_Table SET EndTime = CURRENT_TIMESTAMP WHERE ParkingSlotNumber = " + userInfo.ParkingSlotNumber;                    
                    SqlCommand cmd2 = new SqlCommand(query2, con);    


                    con.Open();
                    Int32 rowsAffected = cmd2.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();

                    //cmd.Parameters.AddWithValue("@ParkingSlotNumber", userInfo.ParkingSlotNumber);

                    while (reader.Read())
                    {                        
                        string name = reader["Name"].ToString();
                        userInfo.Name = name;                        

                        string start_time = reader["ParkingTime"].ToString();
                        string end_time = reader["EndTime"].ToString();


                        start_time = start_time.Replace(".", ":");
                        end_time = end_time.Replace(".", ":");

                        start_time = start_time.Split(' ')[1] + " " + start_time.Split(' ')[2];
                        end_time = end_time.Split(' ')[1] + " " + end_time.Split(' ')[2];

                        TimeSpan duration = DateTime.Parse(end_time).Subtract(DateTime.Parse(start_time));

                        int h = (int)duration.TotalHours;

                        double fare = 0.0;

                        if (userInfo.ParkingSlotNumber >= 1 && userInfo.ParkingSlotNumber <= 10)
                        {
                            fare = 20.0;
                            int x = 0;

                            if (h > 1)
                            {
                                while (h >= 0)
                                {
                                    fare = fare + x * 10;
                                    h--;
                                    x++;
                                }
                                
                                fare = 0.5 * fare;
                            }
                            else
                            {
                                
                                fare = 0.5 * fare;
                            }
                        }

                        else if (userInfo.ParkingSlotNumber >= 11 && userInfo.ParkingSlotNumber <= 20)
                        {
                            fare = 10.0;
                            int x = 0;

                            if (h > 1)
                            {
                                while (h >= 0)
                                {
                                    fare = fare + x * 5;
                                    h--;
                                    x++;
                                }
                            }
                            
                        }
                        else
                        {
                            fare = 20.0;
                            int x = 0;
                            if (h > 1)
                            {
                                while (h >= 0)
                                {
                                    fare = fare + x * 10;
                                    h--;
                                    x++;
                                }
                            }
                            
                        }

                        userInfo.fare = fare;

                    }

                    //delete the row here

                    string query3 = "DELETE FROM Customers_Table WHERE ParkingSlotNumber = " + userInfo.ParkingSlotNumber;
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    Int32 rowsAffected2 = cmd3.ExecuteNonQuery();

                }
              
                return View("Final", userInfo);
            }
            else
            {
                return View();
            }
            
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ViewResult MobileSearch()
        {
            return View();
        }

        [HttpPost]
        public ViewResult MobileSearch(UserInfo userInfo)
        {
            //if (ModelState.IsValid)
            //{
                //string constr = ConfigurationManager.ConnectionStrings["DatabasePMSEntities"].ConnectionString;
                string connectionStringADO = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Final Projects\\ParkingManagementSystem\\ParkingManagementSystem\\App_Data\\DatabasePMS.mdf\";Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
                using (SqlConnection con = new SqlConnection(connectionStringADO))
                {

                    //string query = "INSERT INTO Customers_Table(ParkingSlotNumber, Name, Phone, VehicleNumber, UID, ParkingTime) VALUES(@ParkingSlotNumber, @Name, @Phone, @VehicleNumber, @UID, @ParkingTime)";
                    //string query = "SELECT ParkingTime FROM Customers_Table WHERE ParkingSlotNumber = @ParkingSlotNumber";

                    string query = "SELECT * FROM Customers_Table WHERE Phone = " + userInfo.SearchMobile;
                    SqlCommand cmd = new SqlCommand(query, con);                


                    con.Open();
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    userInfo.Phone = reader["Phone"].ToString();
                    userInfo.Name = reader["Name"].ToString();
                    userInfo.ParkingSlotNumber = Convert.ToInt32(reader["ParkingSlotNumber"]);
                    userInfo.UID = reader["UID"].ToString();
                    userInfo.VehicleNumber = reader["VehicleNumber"].ToString();
                }



                    //cmd.Parameters.AddWithValue("@ParkingSlotNumber", userInfo.ParkingSlotNumber);

                }

                return View("MobileResult", userInfo);
            //}
            //else
            //{
                //return View();
            //}
        }

    }

}