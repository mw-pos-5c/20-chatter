using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockObserver
{
    public class MessageSubject : Subject
    {
        public List<string> Messages { get; } = new();

    }
}
