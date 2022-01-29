using Chatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockObserver
{
    public interface IObserver
    {
        public string ClientName { get; }
        public string TopicsOfInterest { get; }

        public void ClientAttached(string name);


        public void ClientDetached(string name);
 
        public void Update(Message msg);
    }
}
