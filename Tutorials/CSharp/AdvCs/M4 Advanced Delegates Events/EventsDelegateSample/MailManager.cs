using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AdvCs.EventsDelegateSample
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(Object sender, MailArrivedEventArgs e)
        {
            if (MailArrived != null)
                MailArrived.Invoke(sender,e);
        }

        public void SimulateMailArrived()
        {
            OnMailArrived(this, new MailArrivedEventArgs("aaa", "bbb"));
        }
    }
}
