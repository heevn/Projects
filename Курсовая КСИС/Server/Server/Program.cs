using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static int port = 8005;
        static string ip = "127.0.0.1";
        static string[] messages = new string[100];
        public static void send_data(Socket socket)
        {
            Socket answer = socket.Accept();
            byte[] data = new byte[256];
            data = Encoding.Unicode.GetBytes(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.TimeOfDay);
            answer.Send(data);
            answer.Shutdown(SocketShutdown.Both);
            answer.Close();
        }

        public static string get_nick(Socket handler)
        {
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256];

            do
            {
                bytes = handler.Receive(data);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (handler.Available > 0);

            return builder.ToString();
        }
        public static void get_messege(Socket handler, Socket handler1)
        {
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256];

            do
            {
                bytes = handler.Receive(data);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (handler.Available > 0);

            Console.WriteLine(builder.ToString());
            data = Encoding.Unicode.GetBytes(DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes + "  " + builder.ToString());
            handler.Send(data);
            handler1.Send(data);
        }
    
        

        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            // создаем сокет
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                socket.Bind(ipPoint);

                // начинаем прослушивание
                socket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                Console.WriteLine("IP адрес - "+ ip + ", порт - " + port.ToString());
                Console.WriteLine("Подключились пользователи: ");
                Socket handler = socket.Accept();
                Console.WriteLine(get_nick(handler) + handler.RemoteEndPoint);
                Socket handler1 = socket.Accept();
                Console.WriteLine(get_nick(handler1) + handler1.RemoteEndPoint);

                while (true)
                {
                    if(handler.Available > 0)
                    {
                        get_messege(handler, handler1);
                    }
                    else if(handler1.Available > 0)
                    {
                        get_messege(handler1, handler);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}