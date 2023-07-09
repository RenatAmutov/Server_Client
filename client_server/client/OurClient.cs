using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
        private TcpClient _client;
        private StreamWriter _sWriter;
        private StreamReader _sRader;

        public OurClient()
        {
            _client = new TcpClient("127.0.0.1", 5555);
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.UTF8); 
            _sRader = new StreamReader(_client.GetStream(), Encoding.UTF8); 

            HandleComunication();
        }

        void HandleComunication()
        {
            while (true)
            {
                Console.WriteLine("> ");
                string message = Console.ReadLine();
                _sWriter.WriteLine(message);
                _sWriter.Flush();  

                string answerServer = _sRader.ReadLine();
                Console.WriteLine($"Сервер ответил => {answerServer}");
            }
        } 
    }
}