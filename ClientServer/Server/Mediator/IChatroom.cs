using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Mediator
{
    public interface IChatroom
    {
    }

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    public abstract class AbstractChatroom
    {
        public abstract void Register(Player participant);
        public abstract void Send(string from, string to, string message);
    }

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    public class Chatroom : AbstractChatroom
    {
        private Dictionary<string, Player> _participants = new Dictionary<string, Player>();

        public override void Register(Player participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(
          string from, string to, string message)
        {
            Player participant = _participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    public class Beatle : Player
    {
        // Constructor
        public Beatle(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    public class NonBeatle : Player
    {
        // Constructor
        public NonBeatle(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
