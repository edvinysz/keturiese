using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Observers;
using Server.Mediator;

namespace Server.Models
{
    public class Player : Position, IObserver
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public int DeathCount { get; set; }
        private Chatroom _chatroom;
        private string _name;

        public Player()
        {

        }

        public Player(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(
          string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
              from, Name, message);
        }

        public void notify(string message)
        {
            Console.WriteLine("Player " + Username + " notified: \"" + message + "\"");
        }
    }
}
