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
        [RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your vehicle number")]
        [RegularExpression("^[A-Z]{2}[ -][0-9]{1,2}(?: [A-Z])?(?: [A-Z]*)? [0-9]{4}$", ErrorMessage ="Please enter a valid vehicle number")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Please enter your UID")]
        public string UID { get; set; }

        public int ParkingSlotNumber { get; set; }
        //public string ParkingTime { get; set; }

        public double fare { get; set; }
    }
}
