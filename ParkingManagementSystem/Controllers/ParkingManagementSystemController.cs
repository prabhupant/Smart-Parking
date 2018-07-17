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
        public ViewResult ParkingSpotForm(UserInfo userInfo)
        {

            //string constr = ConfigurationManager.ConnectionStrings["DatabasePMSEntities"].ConnectionString;
            string connectionStringADO = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Final Projects\\ParkingManagementSystem\\ParkingManagementSystem\\App_Data\\DatabasePMS.mdf\";Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            using (SqlConnection con = new SqlConnection(connectionStringADO))
            {
                string query = "INSERT INTO Customers_Table(ParkingSlotNumber, Name, Phone, VehicleNumber, UID, ParkingTime) VALUES(@ParkingSlotNumber, @Name, @Phone, @VehicleNumber, @UID, @ParkingTime)";

                SqlCommand cmd = new SqlCommand(query, con);
                                   
                cmd.Parameters.AddWithValue("@ParkingSlotNumber", userInfo.ParkingSlotNumber);
                cmd.Parameters.AddWithValue("@Name", userInfo.Name);                    
                cmd.Parameters.AddWithValue("@Phone", userInfo.Phone);
                cmd.Parameters.AddWithValue("@VehicleNumber", userInfo.Phone);
                cmd.Parameters.AddWithValue("@UID", userInfo.Phone);
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

            if (ModelState.IsValid)
            {
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

            return View("Thanks for coming!", userInfo);
        }
    }

    
}