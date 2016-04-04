using System;
using System.Collections.Generic;
using TwitterClone.Models;

namespace TwitterClone.DataService
{
    public interface IDataProvider
    {
        User GetUser(string userName);

        List<Tweet> GetPublicTimeLine();
        List<Tweet> GetTimeLine(string userName);
        List<Followee> GetFollowee(string userName);
        List<Follower> GetFollowers(string userName);

        bool Follow(string follower, string followee);
        bool UnFollow(string follower, string followee);
        bool Mute(string follower, string followee);
        bool UnMute(string follower, string followee);
        bool Block(string follower, string followee);
        bool UnBlock(string follower, string followee);
        bool AddUser(User user);
        bool UpdateUser(User user);

        Tweet GetTweet(string id);

        void AddTweet(Tweet tweet);

        
    }
}