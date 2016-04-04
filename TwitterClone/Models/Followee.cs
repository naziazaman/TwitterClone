using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Followee
    {
        public User User { get; set; }
        public bool IsMuted { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsNotificationTurnedOn { get; set; }
        public bool IsRetweetTrunedOn { get; set; }
    }

    public class FolloweeDBContext : DbContext
    {
        public DbSet<Followee> Followees { get; set; }
    }
}