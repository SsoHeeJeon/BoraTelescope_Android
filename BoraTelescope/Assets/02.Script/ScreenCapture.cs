using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class ScreenCapture : UploadImage
{
    private Camera Objcamera;       //보여지는 카메라.

    public GameObject flasheffect;
    public GameObject customMark;

    private int resWidth;
    private int resHeight;
    string path;

    public static float count;
    public static bool counttime = false;
    // Use this for initialization
    public void ReadyToCapture()
    {
        if (SceneManager.GetActiveScene().name.Contains("XRMode"))
        {
            Objcamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
        else if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            Objcamera = gamemanager.clearMode.Main.GetComponent<Camera>();
        }
        resWidth = Screen.width;
        resHeight = Screen.height;
        path = Application.dataPath + "/ScreenShot/";
        QRCodeImage.transform.parent.gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount = 0;
    }

    public void ClickScreenShot()
    {
        GetBoranum();
        counttime = true;
        if(Objcamera!= null)
        {
            StartCoroutine(CaptureandSave());
        }
    }

    private IEnumerator CaptureandSave()
    {
        yield return new WaitForEndOfFrame();
        DirectoryInfo dir = new DirectoryInfo(path);
        if (!dir.Exists)
        {
            Directory.CreateDirectory(path);
        }
        string name;
        string filename;
        name = path + boranum + "-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        filename = boranum + "-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";


        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        Objcamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
        Objcamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(rec, 0, 0);
        byte[] bytes = screenShot.EncodeToPNG();
        Debug.Log(bytes);
        File.WriteAllBytes(name, bytes);
        PutImageObject(name, filename);
        Objcamera.targetTexture = null;
        Destroy(screenShot);
        
    }

    public static bool startflasheffect = false;
    bool changed = true;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1, 1, 1, 0.745f);

    public void playFlashEffect()
    {
        if (startflasheffect == true)
        {
            if (changed)
            {
                flasheffect.GetComponent<Image>().color = flashColor;

                changed = false;
            }
            else
            {
                flasheffect.GetComponent<Image>().color = Color.Lerp(flasheffect.GetComponent<Image>().color, Color.clear, flashSpeed * Time.deltaTime);
                if (flasheffect.GetComponent<Image>().color.a < 0.1f)
                {
                    startflasheffect = false;
                    flasheffect.gameObject.SetActive(false);
                    ReadyToCapture();
                    ClickScreenShot();
                }
            }
        }

    }
}