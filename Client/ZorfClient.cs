using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Zorf;

namespace FiligreeClient
{
    internal class ZorfClient
    {
        ZorfService.ZorfServiceClient m_pZorfServer;

        public ZorfClient(ZorfService.ZorfServiceClient pClient)
        {
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
