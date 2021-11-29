using System.Collections.Generic;

namespace TddSocialNetwork.Model
{
    public class User
    {
        public string Name { get; set; }

        public List<Post> TimelinePosts { get; set; }

        public List<User> FollowerUsers { get; set; }

        public List<Message> PrivateMessages { get; set; }

        public User(string name)
        {
            Name = name;
            TimelinePosts = new List<Post>();
            FollowerUsers = new List<User>();
            PrivateMessages = new List<Message>();
        }
    }
}