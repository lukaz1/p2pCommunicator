//Author: BartzK
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator.Connection
{
    [Obsolete("Class is deprecated, move code to appropiate classes. Handle threads outside of client/server.")]
    class TcpHandler
    {
        private TcpClient client;

        public TcpHandler(TcpClient client, bool IsServer)
        {
            this.client = client;

            Thread thread = IsServer ? new Thread(ServerSideConnection) : new Thread(ClientSideConnection);
            thread.IsBackground = true;
            thread.Start();
        }

        private void ServerSideConnection()
        {
            using (client)
            {
                using(BinaryReader reader = new BinaryReader(client.GetStream()))
                {
                    //here server waits for client to init conn, if ok, proceeds to comm until disconnected
                    //use enum class with all responses or smth
                    using(BinaryWriter writer = new BinaryWriter(client.GetStream()))
                    {

                    }
                }
            }
        }

        private void ClientSideConnection()
        {
            using (client)
            {
                using (BinaryWriter writer = new BinaryWriter(client.GetStream()))
                {
                    //connection init, then read response, if ok, then send ok to ok
                    using (BinaryReader reader = new BinaryReader(client.GetStream()))
                    {

                    }
                }
            }
        }

    }
}
