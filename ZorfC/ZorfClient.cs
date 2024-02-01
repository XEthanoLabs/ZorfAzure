using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Zorf;

namespace FiligreeClient
{
    internal class ZorfClient
    {
        ZorfService.ZorfServiceClient m_pZorfServer;
        GrpcChannel m_pChannel;

        public ZorfClient(GrpcChannel channel, ZorfService.ZorfServiceClient pClient)
        {
            m_pChannel = channel;
            m_pZorfServer = pClient;
            Console.WriteLine("Welcome to ZorfOnline (c) 2024");
        }

        public void MainLoop()
        {
            while (true)
            {
                Console.Write("> ");
                string? szCommand = Console.ReadLine();
                if (szCommand == null) continue;
                if( szCommand == "Q")
                {
                    break;
                }

                if( m_pChannel.State == Grpc.Core.ConnectivityState.Shutdown )
                {
                    Console.WriteLine("Lost communication with the server.");
                    break;
                }

                ZorfReply hr = m_pZorfServer.DoCommand(new ZorfCommand() { Command = szCommand });
                Console.WriteLine( hr.Message );
                Console.WriteLine();
            }
        }

        void ProcessCommand()
        {
        }

    }
}
