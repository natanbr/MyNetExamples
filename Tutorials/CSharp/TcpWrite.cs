using System.Net;
using System.Net.Sockets;

namespace CSharp
{
    public class TcpWrite
    {
        public static void Execute()
        {
            var port = 10000;
            IPAddress simulatorAddress = IPAddress.Parse("127.0.0.1");
            var theClient = new TcpClient();
            theClient.Connect(new IPEndPoint(simulatorAddress, port));
            theClient.NoDelay = true;
            NetworkStream theStream = theClient.GetStream();

            Write(theStream, new byte[] {0xfa, 0x05, 0x12});
        }

        /// <summary>
        /// Write exactly x[] bytes.
        /// </summary>
        /// <param name="x"></param>
        private static void Write(NetworkStream stream, byte[] x)
        {
            stream.Write(x, 0, x.Length);
            return;
        }


    }
}
