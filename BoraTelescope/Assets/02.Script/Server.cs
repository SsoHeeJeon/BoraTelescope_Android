using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Server : MonoBehaviour
{
    NetworkStream stream;
    NetworkStream readstream;
    public Thread ReadThread;
    public static Thread staticReadThread;

    //tcp
    const string serverIP = "127.0.0.1";
    const int port = 8100;
    private Queue<byte[]> queue_bytes = new Queue<byte[]>();

    TcpClient Client;
    TcpClient ReadClient;

    // Start is called before the first frame update
    void Start()
    {
        SpinServer();
    }

    private void Update()
    {
        //gtgp("gt");
        //print(ReadStream("g"));
        //print(ReadStream("gt"));
        ReadData();
    }

    public void SpinServer()
    {
        var processList = System.Diagnostics.Process.GetProcessesByName("ControlServer");
        if(processList.Length ==0)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Awesomepia-Dev2\Desktop\BoraLocalServer-main\ControlServer\bin\x64\Debug\ControlServer.exe");
        }

        if (Client == null)
            Client = new TcpClient();
            Client.Connect(serverIP, port);

        if(ReadClient == null)
            ReadClient = new TcpClient();
            ReadClient.Connect(serverIP, port);

        //Client = new TcpClient(serverIP, port);

        stream = Client.GetStream();
        readstream = ReadClient.GetStream();
        //print(ReadStream("check"));
        //Invoke("msg", 1f);
    }

    void msg()
    {
        SendMessage("o");
    }

    public void GoZoomThread()
    {
        Thread thread = new Thread(
            () => {
                SendMessage("w300");
            }
            );
        thread.Start();
        //print("zoomFactor = " + zoomFactor);
    }

    public void SendMessage(string factor)
    {
        if (Client == null)
        {
            Client = new TcpClient(serverIP, port);
            stream = Client.GetStream();
        }
        //Debug.Log("sd: " + factor.ToString());
        byte[] data = System.Text.Encoding.ASCII.GetBytes(factor);
        stream.Write(data, 0, data.Length);
        Thread.Sleep(10);
    }

    public void gtgp(string factor)
    {
        if (Client == null)
        {
            Client = new TcpClient(serverIP, port);
            stream = Client.GetStream();
        }
        //Debug.Log("sd: " + factor.ToString());
        byte[] data = System.Text.Encoding.ASCII.GetBytes(factor);
        stream.Write(data, 0, data.Length);
        Thread.Sleep(10);
        byte[] Readdata = new byte[256];
        int bytes = stream.Read(Readdata, 0, Readdata.Length);
        print(System.Text.Encoding.ASCII.GetString(Readdata, 0, bytes));
    }

    public string ReadStream(string factor)
    {
        //Debug.Log("sd: " + factor.ToString());
        byte[] data = System.Text.Encoding.ASCII.GetBytes(factor);
        stream.Write(data, 0, data.Length);
        Thread.Sleep(10);

        byte[] Readdata = new byte[256];
        int bytes = stream.Read(Readdata, 0, Readdata.Length);
        return System.Text.Encoding.ASCII.GetString(Readdata, 0, bytes);
    }

    public void ReadData()
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes("g");
        stream.Write(data, 0, data.Length);

        stream = Client.GetStream();
        //recevBuffer = new byte[DataSize];
        byte[] Readdata = new byte[256];
        stream.Read(Readdata, 0, Readdata.Length); // stream에 있던 바이트배열 내려서 새로 선언한 바이트배열에 넣기
        if (Readdata == null) return;

        queue_bytes.Enqueue(Readdata);       // recevBuffer의 크기를 할당해놓으면 stream.Read를 통해 자동으로 저장
        string str = Encoding.Default.GetString(queue_bytes.Dequeue());
        print(str);
        
    }

    public void SendData(string factor)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(factor);
        stream.Write(data, 0, data.Length);
    }
}
