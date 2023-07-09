using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener _server;

        public OurServer()
        {
            _server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            _server.Start();

            LoopClients();
        }
            
        void LoopClients()
        {
            while(true)
            {
                TcpClient _client = _server.AcceptTcpClient();

                Thread thread = new Thread(() => HandleClient(_client));
                thread.Start();
            }
        }

        void HandleClient(TcpClient _client)
        {
            StreamReader _sReader = new StreamReader(_client.GetStream(), Encoding.UTF8);
            StreamWriter _sWriter = new StreamWriter(_client.GetStream(), Encoding.UTF8);

            while(true)
            {
                string message = _sReader.ReadLine();
                Console.WriteLine($"Клиент написал - {message}");

                string answer = Console.ReadLine();
                _sWriter.WriteLine(answer);
                _sWriter.Flush();
            }
        }
    }
}
