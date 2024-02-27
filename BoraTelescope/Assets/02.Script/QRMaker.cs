using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class QRMaker : MonoBehaviour
{
    public string url;
    public RawImage QRCodeImage;
    public GameManager gamemanager;
    public string boranum;
    private static Color32[] EncodeURL(string UrlText, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = width,
                Height = height
            }
        };
        return writer.Write(UrlText);
    }

    public Texture2D CreateQR(string URL)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = EncodeURL(URL, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();

        return encoded;
    }

    public void MakeQRCode()
    {
        //url = "http://211.104.146.87:78/info/boraphotodownload/be890630-088e-4760-8cc7-905c6a91bdf1-1-2022-07-07-18-27-27-661.png";
        //string url = "https://borabucket.s3.ap-northeast-2.amazonaws.com/" + filename;
        Texture2D QRImage = CreateQR(url);

        QRCodeImage.texture = QRImage;
        Invoke("waitQRcode", 1f);
    }

    public void waitQRcode()
    {

        QRCodeImage.transform.parent.gameObject.SetActive(true);
        QRCodeImage.gameObject.SetActive(true);
        QRCodeImage.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        ScreenCapture.counttime = false;
        QRCodeImage.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount = 0;
        QRCodeImage.transform.parent.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        Invoke("SetCloseBut", 1f);
        Invoke("CloseQRCode", 30f);

    }

    public void SetCloseBut()
    {
        QRCodeImage.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void CloseQRCode()
    {
        QRCodeImage.gameObject.SetActive(false);
        QRCodeImage.transform.parent.gameObject.SetActive(false);
        gamemanager.BackGround.SetActive(false);
    }

    public void GetBoranum()
    {
        string borainfo = File.ReadAllText("C:/XRTeleSpinCam/bora_info.txt");
        borainfo.Replace("\r\n", string.Empty);
        boranum = borainfo.Substring(13, borainfo.IndexOf("\r\n") - 13);
    }
}
