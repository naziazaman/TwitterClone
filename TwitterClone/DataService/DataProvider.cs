using System;
using System.Collections.Generic;
using TwitterClone.Models;

namespace TwitterClone.DataService
{
    public class DataProvider : IDataProvider
    {
        public DataProvider()
        {
            
        }        

        public List<Tweet> GetPublicTimeLine()
        {
            return GetTimeLine(null);
        }

        public List<Tweet> GetTimeLine(string userName)
        {
            return GetTimeLine(userName);
        }

        public List<Followee> GetFollowee(string userName)
        {
            return new List<Followee>();
        }

        public List<Follower> GetFollowers(string userName)
        {
            return new List<Follower>();
        }

        public bool Follow(string follower, string following)
        {
            throw new NotImplementedException();
        }

        public bool UnFollow(string follower, string following)
        {
            throw new NotImplementedException();
        }

        public bool Mute(string follower, string following)
        {
            throw new NotImplementedException();
        }

        public bool UnMute(string follower, string following)
        {
            throw new NotImplementedException();
        }

        public bool Block(string follower, string following)
        {
            throw new NotImplementedException();
        }

        public bool UnBlock(string follower, string following)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public Tweet GetTweet(string id)
        {
            return new Tweet();
        }

        public void AddTweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}