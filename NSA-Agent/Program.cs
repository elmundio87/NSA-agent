using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace NSA_Agent
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8151;
            TcpListener tcpListener = new TcpListener(port);
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}", port);

            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();
                Instance request = new Instance(socket);
                Thread t = new Thread(request.run);
                t.Start();
            }

        }
    }
}
