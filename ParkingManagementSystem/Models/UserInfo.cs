using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace ParkingManagementSystem.Models
{
    public class UserInfo
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your vehicle number")]
        public string VehicleNumber { get; set; }
        [Required(ErrorMessage = "Please enter your UID")]
        public string UID { get; set; }

        public string ParkingSlotNumber { get; set; }
        public string ParkingTime { get; set; }
    }
}
