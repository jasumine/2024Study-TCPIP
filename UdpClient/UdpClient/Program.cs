using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // 서버 IP 주소 및 포트 설정
        string serverIp = "127.0.0.1";
        int port = 5000;

        // 소켓 생성
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Console.WriteLine("소켓생성");
        // 데이터 전송
        string message = "Hello, world!";
        byte[] data = Encoding.UTF8.GetBytes(message);
        int size = data.Length;
        Console.WriteLine("데이터 전송");
        socket.SendTo(data, 0, size, SocketFlags.None, new IPEndPoint(IPAddress.Parse(serverIp), port));
        Console.WriteLine("Sent data to {0}:{1}", serverIp, port);
        Console.WriteLine("종료");
    }
}