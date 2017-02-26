//Author: BartzK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Connection
{
    class Server
    {
        #region Properties
        public string ClientIp { get; set; }
        public int ClientPort { get; set; }

        private static bool TerminateConnection { get; set; }
        #endregion

        #region Variables
        private static TcpClient client;
        private static TcpListener server;
        #endregion

        #region Public Classes
        Server(string ip, int port)
        {
            this.ClientIp = ip;
            this.ClientPort = port;

            Connect();
        }
        #endregion

        #region Private Classes
        private void Connect()
        {
            try
            {
                Console.WriteLine("Connecting to {0}:{1}", ClientIp, ClientPort.ToString());
                server = new TcpListener(IPAddress.Parse(ClientIp), ClientPort);
                TerminateConnection = false;
                server.Start();
                ConnectionHandler();
            }
            catch (SocketException e)
            {
                Console.WriteLine("Socket Exception: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown Exception: {0}", e);
            }
            finally
            {
                server.Stop();
            }
        }

        private static void ConnectionHandler()
        {
            while(true)
            {
                client = server.AcceptTcpClient();
                //Connected

                //init
                new TcpHandler(client, false); //obsolete

                //while true - keep communicating
                //while endofstream, read

                client.Close();
            }
        }
        #endregion

    }
}
