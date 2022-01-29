using Chatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockObserver
{
    public class Subject
    {
        protected List<IObserver> observers = new List<IObserver>();
        public int NrObservers { get
            {
                return observers.Count; 
            }
        }

        public virtual void Attach(IObserver observer)
        {
            lock (observers)
            {
                observers.Add(observer);
                foreach (IObserver i in observers)
                {
                    i.ClientAttached(observer.ClientName);
                }
            }
        }

        public virtual void Detach(IObserver observer)
        {
            lock (observers)
            {
                observers.Remove(observer);
                foreach (IObserver i in observers)
                {
                    i.ClientDetached(observer.ClientName);
                }
            }
        }

        public virtual void Notify(Message msg)
        {
            lock (observers)
            {
                foreach (IObserver observer in observers)
                {
                    observer.Update(msg);
                }
            }
        }

    }
}
