using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraSpincam : MonoBehaviour
{
    public RawImage Main;
    Texture2D pickedImage;
    NetworkStream stream;
    public Thread ReadThread;
    public static Thread staticReadThread;
    private Queue<byte[]> queue_bytes = new Queue<byte[]>();

    //tcp
    const string serverIP = "127.0.0.1";
    const int port = 8002;
    const int orderport = 8003;
    TcpClient orderClient;
    TcpClient Client;
    byte[] recevBuffer;

    public static int camWidth = 0;
    public static int camHeight = 0;
    static int DataSize = 0;

    GameManager gamemanager;

    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (queue_bytes.Count > 0)
        {
            SeeCameraImage(queue_bytes.Dequeue());
        }
    }

    void ReadImage()
    {
        while(true)
        {
            if (Client != null)
            {
                stream = Client.GetStream();
                //recevBuffer = new byte[DataSize];
                stream.Read(recevBuffer, 0, recevBuffer.Length); // stream�� �ִ� ����Ʈ�迭 ������ ���� ������ ����Ʈ�迭�� �ֱ�
                if (recevBuffer == null) return;

                queue_bytes.Enqueue(recevBuffer);       // recevBuffer�� ũ�⸦ �Ҵ��س����� stream.Read�� ���� �ڵ����� ����
            }
        }
    }

    public void SeeCameraImage(byte[] cameradatas)
    {
        pickedImage.LoadRawTextureData(cameradatas);
        pickedImage.Apply();
        Main.texture = pickedImage;
    }

    public void OnApplicationQuit()
    {
        foreach (Process process in Process.GetProcesses())
        {
            if (process.ProcessName.StartsWith("XRTeleSpinCam"))
            {
                process.Kill();
            }
        }
    }
}
