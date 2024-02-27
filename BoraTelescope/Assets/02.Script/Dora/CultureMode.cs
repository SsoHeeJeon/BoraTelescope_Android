using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CultureMode : MonoBehaviour
{
    public enum LabelDetailState
    {
        Open,
        Close,
        Opening,
        Closing,
    }
    public LabelDetailState labeldetailstate = 0;


    public GameObject DetailImage_Background;
    public GameObject Info;


    private GameObject GameManager_Obj;       // GameManager 오브젝트
    public GameManager gamemanager;                         // GameManager 스크립트
    public Culture_Label CultureLabel;                     // 라벨관련 정보 및 이미지 있는 스크립트
    public Animator Camera_ani;

    public GameObject SelectLabel;

    public GameObject Map;
    public GameObject AllLabel;
    public GameObject AllLabel_1;

    public static bool selectLabel = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Process process in Process.GetProcesses())
        {
            if (process.ProcessName.StartsWith("XRTeleSpinCam"))
            {
                process.Kill();
            }
        }

        GameManager_Obj = GameObject.Find("GameManager");       // GameManager 찾기
        gamemanager = GameManager_Obj.GetComponent<GameManager>();       // GameManager Script 찾기
        for (int i = 0; i < gamemanager.LanguageBar.GetComponent<LangageObj>().LangList.Count; i++)
        {
            gamemanager.LanguageBar.GetComponent<LangageObj>().LangList[i].SetActive(true);
        }
        gamemanager.UI_All.SetActive(true);
        gamemanager.Arrow.SetActive(false);
        gamemanager.MiniMap_Background.transform.parent.transform.gameObject.SetActive(false);
        gamemanager.Homebtn.SetActive(false);
        gamemanager.modeonoff.CultureIn();
    }

    private void Update()
    {
        Label_arr();
    }

    void Label_arr()
    {
        switch (labeldetailstate)
        {
            //725 1218
            case LabelDetailState.Opening:
                DetailImage_Background.transform.localPosition = new Vector3(Mathf.Lerp(DetailImage_Background.transform.localPosition.x, 725, Time.deltaTime * 2), 393.5f, 0);
                if (Math.Abs(DetailImage_Background.transform.localPosition.x - 725) < 5)
                {
                    GetComponent<AudioSource>().Play();
                    DetailImage_Background.transform.localPosition = new Vector3(725, 393.5f, 0);
                    labeldetailstate = LabelDetailState.Open;
                }
                break;
            case LabelDetailState.Closing:
                DetailImage_Background.transform.localPosition = new Vector3(Mathf.Lerp(DetailImage_Background.transform.localPosition.x, 1218, Time.deltaTime * 2), 393.5f, 0);
                if (Math.Abs(DetailImage_Background.transform.localPosition.x - 1218) < 5)
                {
                    DetailImage_Background.transform.localPosition = new Vector3(1218, 393.5f, 0);
                    labeldetailstate = LabelDetailState.Close;
                }
                break;
        }
    }

    public void SettingDetail()
    {

    }

    // 라벨 누르면 라벨에 따라 강조표시하기
    public void OpenHighlight(GameObject label_btn)
    {
        if (SelectLabel == null)
        {
            SelectLabel = label_btn;

            Camera_ani.SetBool("Select" + SelectLabel.name, true);
            Camera_ani.GetBool("Select" + SelectLabel.name);
            Camera_ani.SetBool("See" + SelectLabel.name, true);
            Camera_ani.GetBool("See" + SelectLabel.name);

            CultureLabel.Labelstateimage();

            selectLabel = true;
        }
        else if (SelectLabel != null)
        {
            if (label_btn.name == SelectLabel.name)
            {
                SelectLabel = null;
                selectLabel = false;
                CloseDetailInfo();
            }
            else if (label_btn.name != SelectLabel.name)
            {
                SelectLabel = label_btn;
                ////////this.GetComponent<LabelDetail>().CloseDetailWindow();
                labeldetailstate = LabelDetailState.Closing;
                GetComponent<AudioSource>().Stop();
                CultureLabel.Labelstateimage();
            }
        }
    }

    // 상세설명 닫기
    public void CloseDetailInfo()
    {
        //CultureLabel.Detail_audio.Stop();
        SelectLabel = null;
        CultureLabel.Labelstateimage();

        for (int k = 0; k < 32; k++)
        {
            if (Camera_ani.GetParameter(k).name.Contains("See"))
            {
                Camera_ani.SetBool(Camera_ani.GetParameter(k).name, false);
                Camera_ani.GetBool(Camera_ani.GetParameter(k).name);
            }
        }
        ///////////this.GetComponent<LabelDetail>().CloseDetailWindow();
        labeldetailstate = LabelDetailState.Closing;
        GetComponent<AudioSource>().Stop();
        Invoke("returnCamera", 0.5f);
    }

    public void returnCamera()
    {
        for (int k = 0; k < 32; k++)
        {
            if (Camera_ani.GetParameter(k).name.Contains("Select"))
            {
                Camera_ani.SetBool(Camera_ani.GetParameter(k).name, false);
                Camera_ani.GetBool(Camera_ani.GetParameter(k).name);
            }
        }
    }

    public void OnClickDetailSoundBtn(GameObject btn)
    {
        if (btn.transform.GetChild(0).gameObject.activeSelf)
        {
            btn.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            btn.transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
