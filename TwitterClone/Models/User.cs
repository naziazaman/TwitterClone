using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}