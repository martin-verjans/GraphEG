using System;

namespace GraphEG.EscapeGame.GameSession
{
    public class SessionActionHistory : IComparable<SessionActionHistory>, IEquatable<SessionActionHistory>
    {
        private static int nextOrderNumber = 0;
        public static SessionActionHistory BuildActionHistoryLine(string logLine)
        {
            if (logLine.Length == 0) 
                return null;
            int index = logLine.IndexOf(' ');
            string id = logLine.Substring(0, index);
            string message = logLine.Substring(index + 1);
            if (message.StartsWith("(")) //To remove branch information
                message = message.Substring(message.IndexOf(")") + 2);
            return new SessionActionHistory(id, message, nextOrderNumber++);
        }

        public string Id { get; }
        public int Order { get; }
        public string Content { get; }

        public SessionActionHistory(string id, string content, int order)
        {
            Id = id;
            Content = content;
            Order = order;
        }

        public int CompareTo(SessionActionHistory other)
        {
            return Order.CompareTo(other.Order);
        }

        public bool Equals(SessionActionHistory other)
        {
            return Id.Equals(other.Id);
        }
    }
}
