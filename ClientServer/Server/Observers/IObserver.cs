using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Observers
{
    public interface IObserver
    {
        void notify(string message);
    }
}
