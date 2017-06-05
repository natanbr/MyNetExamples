using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AdvCs.EventsDelegateSample
{
    class MailArrivedEventArgs
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
