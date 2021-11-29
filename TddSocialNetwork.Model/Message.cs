using System;

namespace TddSocialNetwork.Model
{
    public class Message
    {
        public string Body { get; set; }
        public string From { get; set; }
        public DateTime SentDateTime { get; set; }

        public Message(string userName, string message)
        {
            Body = message;
            From = userName;
            SentDateTime = DateTime.Now;
        }
    }
}