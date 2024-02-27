using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoplayer;
    [SerializeField]
    Image slider;
    [SerializeField]
    GameObject Handle;
    [SerializeField]
    GameObject SelectImg;
    [SerializeField]
    GameObject Touch;
    [SerializeField]
    RawImage VideoImg;

    GameManager gamemanager;
    public bool isDrag;
    float fulltime;
    float fullt_m;
    float fullt_s;
    float curt_m;
    float curt_s;
    public Text curT;
    public Text fullT;
    public Sprite Guide_Play;
    public Sprite Guide_Pause;
    public Image PlayPause;

    public VideoClip Guide_K;
    public VideoClip Guide_E;
    public VideoClip Guide_C;
    public VideoClip Guide_J;

    public GameObject[] Pos = new GameObject[4];

    float Stoptime;

    private void Start()
    {
        slider.fillAmount = 0;
        gamemanager = transform.parent.parent.GetComponent<GameManager>();
        GuideLanguage();
    }

    void Update()
    {
        fullt_m = (int)(fulltime / 60);
        fullt_s = (int)(fulltime - fullt_m * 60);
        fullT.text = string.Format("{0:00}", fullt_m) + " : " + string.Format("{0:00}", fullt_s);

        curt_m = (int)(videoplayer.time / 60);
        curt_s = (int)(videoplayer.time - curt_m * 60);
        curT.text = string.Format("{0:00}", curt_m) + " : " + string.Format("{0:00}", curt_s);

        if (!isDrag)
        {
            slider.fillAmount = (float)videoplayer.time / fulltime;
            Handle.GetComponent<RectTransform>().anchoredPosition = new Vector3(slider.fillAmount * 956, Handle.transform.localPosition.y, Handle.transform.localPosition.z);
        }

        

        switch(GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                Stoptime = 52.5596335794089f;
                break;
            case GameManager.LangState.English:
                Stoptime = 49.3493002290407f;
                break;
            case GameManager.LangState.Chienses:
                Stoptime = 59.5261336096069f;
                break;
            case GameManager.LangState.Japan:
                Stoptime = 68.5685003182411f;
                break;
        }
        if (Math.Abs(videoplayer.time - Stoptime) <0.1f && !videoplayer.isPaused)
        {
            GuidePP();
            Touch.SetActive(true);
            videoplayer.time += 0.3f;
        }

        if(slider.fillAmount>0.99f)
        {
            Touch.SetActive(true);
        }

        if (Touch.activeSelf && !videoplayer.isPaused)
        {
            Touch.SetActive(false);
        }
    }

    public void GuideLanguage()
    {
        for (int index = 0; index < Pos.Length; index++)
        {
            Pos[index].SetActive(false);
        }

        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                videoplayer.clip = Guide_K;
                Pos[0].SetActive(true);
                break;
            case GameManager.LangState.English:
                videoplayer.clip = Guide_E;
                Pos[1].SetActive(true);
                break;
            case GameManager.LangState.Chienses:
                videoplayer.clip = Guide_C;
                Pos[2].SetActive(true);
                break;
            case GameManager.LangState.Japan:
                videoplayer.clip = Guide_J;
                Pos[3].SetActive(true);
                break;
        }
        fulltime = CalculateLengh();
        Handle.GetComponent<HandleEvent>().fulltime = fulltime;
    }

    float CalculateLengh()
    {
        float fraction = (float)videoplayer.frameCount / (float)videoplayer.frameRate;
        return fraction;
    }

    bool VideoState = false;
    public void GuidePP()
    {
        if (VideoState == false)
        {
            if (PlayPause.sprite == Guide_Play)
            {
                videoplayer.Pause();
                PlayPause.sprite = Guide_Pause;
                VideoState = true;
            }
            else if (PlayPause.sprite == Guide_Pause)
            {
                videoplayer.Play();
                PlayPause.sprite = Guide_Play;
                VideoState = true;
            }
            VideoState = false;
        }
    }

    public void OnClickBtn()
    {
        if(!videoplayer.isPaused)
        {
            videoplayer.Pause();
            SelectImg.SetActive(true);
            VideoImg.GetComponent<Button>().enabled = false;
        }
        else
        {
            if(slider.fillAmount>=0.99f)
            {
                OnClickYes();
            }
            else
            {
                videoplayer.Play();
            }
        }
        Touch.SetActive(false);
    }

    public void OnClickYes()
    {
        gamemanager.modeonoff.GuideMode.transform.GetChild(0).gameObject.SetActive(false);
        VideoImg.GetComponent<Button>().enabled = true;
        SelectImg.SetActive(false);
        gamemanager.Homebtn.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            //gamemanager.MenuBar.transform.GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(true);

            //if (gamemanager.see360.obj360.transform.parent.gameObject.activeSelf)
            //{
            //    gamemanager.see360.Close360();
            //}
            //else if (gamemanager.clearMode.Clear360Obj.activeSelf)
            //{
            //    gamemanager.clearMode.OnClick360Btn();
            //}
            //gamemanager.moveannounce.OpenMode("Clear");
        }
        else if(SceneManager.GetActiveScene().name.Contains("XRMode"))
        {
            gamemanager.MenuBar.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
            //gamemanager.moveannounce.OpenMode("Live");
        }
        //gamemanager.UISetting();
        gamemanager.Tip_Obj.SetActive(true);
        gamemanager.modeonoff.TipMode.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnClickNo()
    {
        videoplayer.Play();
        VideoImg.GetComponent<Button>().enabled = true;
        SelectImg.SetActive(false);
    }
}
