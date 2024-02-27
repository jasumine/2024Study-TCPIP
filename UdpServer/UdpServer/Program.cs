using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 포트 설정
            int port = 5000;

            // 소켓 생성
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Console.WriteLine("소켓바인드");
            // 소켓 바인딩
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            Console.WriteLine("데이터 수신 대기");
            // 데이터 수신 대기
            while (true)
            {
                // 데이터 수신
                byte[] data = new byte[1024];
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                int recvBytes = socket.ReceiveFrom(data, ref remoteEndPoint);

                // 수신된 데이터 출력
                Console.WriteLine("Received data from {0}: {1}", remoteEndPoint, Encoding.UTF8.GetString(data, 0, recvBytes));
            }
        }
    }
}