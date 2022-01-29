using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public class Message
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"[{Date.ToLongTimeString()}] {Name}: {Content}";
        }
    }
}
