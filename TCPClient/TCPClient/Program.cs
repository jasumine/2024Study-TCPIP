using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 클라이언트 소켓 생성
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 서버 IP 주소 및 포트 번호 설정
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            // 서버에 연결
            clientSocket.Connect(ipEndPoint);

            // 서버에게 데이터 전송
            string sendData = "Hello, Server!";
            byte[] sendBuffer = Encoding.UTF8.GetBytes(sendData);
            clientSocket.Send(sendBuffer);

            // 서버로부터 데이터 수신
            byte[] receiveBuffer = new byte[1024];
            int receiveBytes = clientSocket.Receive(receiveBuffer);

            // 수신된 데이터 문자열로 변환
            string receiveData = Encoding.UTF8.GetString(receiveBuffer, 0, receiveBytes);

            Console.WriteLine("서버로부터 받은 데이터: " + receiveData);

            // 소켓 닫기
            clientSocket.Close();

            Console.WriteLine("클라이언트가 종료되었습니다.");
        }
    }
}