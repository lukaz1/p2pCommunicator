//Author: BartzK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communicator.Connection
{
    class Client
    {
        #region Properties
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }
        
        private static bool TerminateConnection { get; set; }
        #endregion

        #region Public Classes
        Client()
        {
            using (TcpClient client = new TcpClient())
            {
                //TcpHandler for client
            }
        }
        #endregion
    }
}
