using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ParkingManagementSystem.Models
{
    public class UserContext : DbContext
    {
        public DbSet<UserInfo> users { get; set; }
    }
}