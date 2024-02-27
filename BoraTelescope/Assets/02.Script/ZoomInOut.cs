using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZoomInOut : MonoBehaviour
{
    const string serverIP = "127.0.0.1";
    const int orderport = 8003;
    TcpClient orderClient;


    private void Start()
    {
        DigitalZoom("Origin");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            DigitalZoom("Plus");
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            DigitalZoom("Minus");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            DigitalZoom("ZoomOut");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            DigitalZoom("ZoomIn");
        }
    }

    NetworkStream orderStream;
    public double zoomFactor = 1;
    private void SendMessage(byte factor)
    {
        if (orderClient == null)
        {
            orderClient = new TcpClient(serverIP, orderport);
            orderStream = orderClient.GetStream();
        }
        //Debug.Log("sd: " + factor.ToString());

        orderStream.WriteByte(factor);
        Thread.Sleep(10);
        byte[] bytes = new byte[10];
        int msg = orderStream.ReadByte();
        zoomFactor = (double)msg / 10;
    }

    public void DigitalZoom(string state)
    {
        if (state == "Plus")
        {
            if(zoomFactor<5)
            {
                zoomFactor = zoomFactor + 0.1;
            }
            else
            {
                zoomFactor = zoomFactor + 0.3;
            }
        }
        else if (state == "Minus")
        {
            if (zoomFactor < 5)
            {
                zoomFactor = zoomFactor - 0.1;
            }
            else
            {
                zoomFactor = zoomFactor - 0.3;
            }
        }
        else if (state == "ZoomOut")
        {
            if (zoomFactor <= 3)
            {
                //ChangeZoomOutFactor();
                Invoke("ChangeZoomOutFactor", 0.001f);

            }
        }
        else if (state == "ZoomIn")
        {
            if (zoomFactor >= 1)
            {
                //ChangeZoomInFactor();
                Invoke("ChangeZoomInFactor", 0.001f);
            }
            else if (zoomFactor >= 3)
            {
                zoomFactor = 3;
            }
        }
        else if (state == "Origin")
        {
            zoomFactor = 1;
        }
        else
        {
            zoomFactor = (float.Parse(state));
        }
        zoomFactor = Mathf.Round((float)zoomFactor * 10) * 0.1f;
        GoZoomThread();
    }

    public void ChangeZoomOutFactor()
    {
        zoomFactor = zoomFactor - 0.5;
        if (zoomFactor <= 1)
        {
            //print("zoomFactor1 = " + zoomFactor);
            zoomFactor = 1;
            CancelInvoke("ChangeZoomOutFactor");
        }
        else
        {
            Invoke("ChangeZoomOutFactor", 0.02f);
        }

        if (zoomFactor != 1)
        {
            zoomFactor = Mathf.Round((float)zoomFactor * 10) * 0.1f;
        }
        GoZoomThread();
        //print("zoomFactor = " + zoomFactor);
    }

    public void ChangeZoomInFactor()
    {
        zoomFactor = zoomFactor + 0.5;
        if (zoomFactor >= 3)
        {
            //print("zoomFactor1 = " + zoomFactor);
            zoomFactor = 3;
            CancelInvoke("ChangeZoomInFactor");
        }
        else
        {
            Invoke("ChangeZoomInFactor", 0.02f);
        }

        if (zoomFactor != 3)
        {
            zoomFactor = Mathf.Round((float)zoomFactor * 10) * 0.1f;
        }
        GoZoomThread();
    }

    public void GoZoomThread()
    {
        Thread thread = new Thread(
            () => {
                SendMessage((byte)(zoomFactor * 10));
            }
            );
        thread.Start();
        //print("zoomFactor = " + zoomFactor);
    }
}
