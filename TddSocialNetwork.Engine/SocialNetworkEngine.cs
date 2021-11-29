using System.Collections.Generic;
using System.Linq;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Engine
{
    public class SocialNetworkEngine
    {
        private string userName;
        public List<User> Users { get; set; }

        public SocialNetworkEngine()
        {
            Users = new List<User>();
        }

    
        public void Post(string name, string message)
        {
            var existingUser = Users.FirstOrDefault(x => x.Name == name);
            
            if (existingUser != null)
            {
                existingUser.TimelinePosts.Add(new Post(message));
            }
            else
            {
                var newUser = new User(name);
                var post = new Post(message);
                newUser.TimelinePosts.Add(post);
                Users.Add(newUser);
            }

            if (message.Contains("@"))
            {
                var messageArray = message.Split(' ');
                var newUserName = messageArray[0].Split('@')[1];

                var userToReceiveMessage = Users.FirstOrDefault(x => x.Name == newUserName);
                if (userToReceiveMessage == null)
                {
                    var newUser = new User(newUserName);
                    newUser.TimelinePosts.Add(new Post(message));

                    Users.Add(newUser);
                }
                else
                {
                    userToReceiveMessage?.TimelinePosts.Add(new Post(message));
                }

            }
        }

       

        public void Follow(string userName, string userNameToFollow)
        {
            var user = Users.FirstOrDefault(x => x.Name == userName);
            
            var userToFollow = Users.FirstOrDefault(x => x.Name == userNameToFollow);

            if (user != null && userToFollow != null)
            {
                user.FollowerUsers.Add(userToFollow);
            }

        }

        public List<Post> Timeline(string userName)
        {
            return Users.FirstOrDefault(x => x.Name == userName)?.TimelinePosts;
        }

        public void SendMessage(string userName, string receiverName, string messageToSend)
        {
            var message = new Message(userName, messageToSend);
            var user = Users.FirstOrDefault(x => x.Name == userName);
            if (user == null)
            {
                user = new User(userName);
                Users.Add(user);
            }

            var receiverUser = Users.FirstOrDefault(x => x.Name == receiverName);
            if (receiverUser == null)
            {
                receiverUser = new User(receiverName);
                Users.Add(receiverUser);
            }

            receiverUser = Users.FirstOrDefault(x => x.Name == receiverName);
            receiverUser?.PrivateMessages.Add(message);
            Users.Remove(receiverUser);
            Users.Add(receiverUser);
        }

        public List<Message> ViewMessages(string receiverName)
        {
            return Users.FirstOrDefault(x => x.Name == receiverName)?.PrivateMessages;
        }

        public List<Post> Wall(string userName)
        {
            var allPosts = new List<Post>();
            var user = Users.FirstOrDefault(x => x.Name == userName);

            if (user != null)
            {

                var users = user?.FollowerUsers;

                foreach (var followerUser in users)
                {
                    var timelinePosts = Users.FirstOrDefault(x => x.Name == followerUser.Name)?.TimelinePosts;

                    if (timelinePosts != null)
                        allPosts.AddRange(timelinePosts);
                }
            }

            return allPosts.OrderByDescending(x => x.Created).ToList();
        }
    }
}
