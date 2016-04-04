using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Tweet
    {
        public string Id { get; set; }

        public string User { get; set; }

        public string TweetMessage { get; set; }

        public string Location { get; set; }

        public DateTime Time { get; set; }

        public string ReplyToUser { get; set; }

        public string ReplyToTweet { get; set; }
    }

    public class TweetDBContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
    }
}