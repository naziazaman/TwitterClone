using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Follower
    {
        public User User { get; set; }
        public bool IsMuted { get; set; }
        public bool IsBlocked { get; set; }
    }

    public class FollowerDBContext : DbContext
    {
        public DbSet<Follower> Followers { get; set; }
    }
}