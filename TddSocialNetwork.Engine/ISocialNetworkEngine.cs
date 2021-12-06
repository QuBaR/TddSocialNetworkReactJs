using System.Collections.Generic;
using System.Threading.Tasks;
using TddSocialNetwork.Model;

namespace TddSocialNetwork.Engine
{
    public interface ISocialNetworkEngine
    {
        void Post(string name, string message);
        void Follow(string userName, string userNameToFollow);
        List<Post> Timeline(string userName);
        void SendMessage(string userName, string receiverName, string messageToSend);
        List<Message> ViewMessages(string receiverName);
        Task<List<Post>> Wall(string userName);
    }
}