using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.AdvCs.EventsDelegateSample
{
    public class MailSystemMain
    {
        public static void Execute()
        {
            var _mail = new MailManager();
            _mail.MailArrived += _mail_MailArrived;
            _mail.SimulateMailArrived();
        }

        static void _mail_MailArrived(object sender, MailArrivedEventArgs e)
        {

            System.Threading.Timer t = new Timer(state => { 
                Console.WriteLine("New Mail Title:{0} Body{1}",e.Title,e.Body);
            });
        }
    }
}
