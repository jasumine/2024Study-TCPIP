using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 서버 소켓 생성
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // IP 주소 및 포트 번호 설정
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 5000);

            // 서버 소켓 바인딩
            serverSocket.Bind(ipEndPoint);

            // 클라이언트 연결 대기
            serverSocket.Listen(10);

            Console.WriteLine("서버가 시작되었습니다. 클라이언트 연결을 기다리고 있습니다.");

            // 클라이언트 연결 수락
            Socket clientSocket = serverSocket.Accept();

            // 클라이언트로부터 데이터 수신
            byte[] receiveBuffer = new byte[1024];
            int receiveBytes = clientSocket.Receive(receiveBuffer);

            // 수신된 데이터 문자열로 변환
            string receiveData = Encoding.UTF8.GetString(receiveBuffer, 0, receiveBytes);

            Console.WriteLine("클라이언트로부터 받은 데이터: " + receiveData);

            // 클라이언트에게 데이터 전송
            string sendData = "Hello, Client!";
            byte[] sendBuffer = Encoding.UTF8.GetBytes(sendData);
            clientSocket.Send(sendBuffer);

            // 소켓 닫기
            clientSocket.Close();
            serverSocket.Close();

            Console.WriteLine("서버가 종료되었습니다.");
        }
    }
}