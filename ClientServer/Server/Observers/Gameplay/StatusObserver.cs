using System;
using System.Collections.Generic;
using System.Text;
using Server.Observers;

namespace Server.Observers.Gameplay
{
    public class StatusObserver
    {
        private List<IObserver> subscribers = new List<IObserver>();

        public StatusObserver() { }

        public void add(IObserver subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void remove(IObserver subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void notifyAll(string message)
        {
            foreach (IObserver subscriber in subscribers)
            {
                subscriber.notify(message);
            }
        }
    }
}
