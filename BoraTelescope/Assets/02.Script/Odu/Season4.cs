using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Season4 : MonoBehaviour
{
    enum SeasonState
    {
        Close,
        Open,
        Closing,
        Opening,
    }
    SeasonState seasonstate = 0;


    [SerializeField]
    GameObject PanoSpring;
    [SerializeField]
    GameObject PanoSummer;
    [SerializeField]
    GameObject PanoFall;
    [SerializeField]
    GameObject PanoWinter;

    public List<GameObject> PanoList = new List<GameObject>();

    [SerializeField]
    GameObject XRSpring;
    [SerializeField]
    GameObject XRSummer;
    [SerializeField]
    GameObject XRFall;
    [SerializeField]
    GameObject XRWinter;

    public List<GameObject> XRList = new List<GameObject>();

    [SerializeField]
    GameObject EffectSpring;
    [SerializeField]
    GameObject EffectSummer;
    [SerializeField]
    GameObject EffectFall;
    [SerializeField]
    GameObject EffectWinter;

    public List<GameObject> EffectList = new List<GameObject>();

    [SerializeField]
    GameObject LabelSpring;
    [SerializeField]
    GameObject LabelSummer;
    [SerializeField]
    GameObject LabelFall;
    [SerializeField]
    GameObject LabelWinter;

    public List<GameObject> LabelList = new List<GameObject>();


    [SerializeField]
    ClearMode clearmode;
    [SerializeField]
    GameObject seasonBar;
    // Start is called before the first frame update
    void Start()
    {
        PanoList.Add(PanoSpring);
        PanoList.Add(PanoSummer);
        PanoList.Add(PanoFall);
        PanoList.Add(PanoWinter);

        XRList.Add(XRSpring);
        XRList.Add(XRSummer);
        XRList.Add(XRFall);
        XRList.Add(XRWinter);

        EffectList.Add(EffectSpring);
        EffectList.Add(EffectSummer);
        EffectList.Add(EffectFall);
        EffectList.Add(EffectWinter);

        LabelList.Add(LabelSpring);
        LabelList.Add(LabelSummer);
        LabelList.Add(LabelFall);
        LabelList.Add(LabelWinter);

        GameObject obj = new GameObject();
        if (DateTime.Now.ToString("MM") == "12" || DateTime.Now.ToString("MM") == "01" || DateTime.Now.ToString("MM") == "02")
        {
            obj.name = "Winter";
            OnClickSeason(obj);

        }
        else if (DateTime.Now.ToString("MM") == "03" || DateTime.Now.ToString("MM") == "04" || DateTime.Now.ToString("MM") == "05")
        {
            obj.name = "Spring";
            OnClickSeason(obj);
        }
        else if (DateTime.Now.ToString("MM") == "06" || DateTime.Now.ToString("MM") == "07" || DateTime.Now.ToString("MM") == "08")
        {
            obj.name = "Summer";
            OnClickSeason(obj);
        }
        else if (DateTime.Now.ToString("MM") == "09" || DateTime.Now.ToString("MM") == "10" || DateTime.Now.ToString("MM") == "11")
        {
            obj.name = "Fall";
            OnClickSeason(obj);
        }
        Destroy(obj);
    }
    private void Update()
    {
        SeasonBar();
    }

    public void OnClickSeason(GameObject obj)
    {
        EffectList[1].GetComponent<Animator>().enabled = false;
        for (int i=0; i<PanoList.Count; i++)
        {
            PanoList[i].SetActive(false);
            XRList[i].SetActive(false);
            EffectList[i].SetActive(false);
            LabelList[i].SetActive(false);
        }

        switch(obj.name)
        {
            case "Spring":
                PanoList[0].SetActive(true);
                XRList[0].SetActive(true);
                EffectList[0].SetActive(true);
                LabelList[0].SetActive(true);
                clearmode.AllMapLabels = LabelList[0];
                break;
            case "Summer":
                PanoList[1].SetActive(true);
                XRList[1].SetActive(true);
                EffectList[1].SetActive(true);
                LabelList[1].SetActive(true);
                clearmode.AllMapLabels = LabelList[1];
                EffectList[1].GetComponent<Animator>().enabled = true;
                break;
            case "Fall":
                PanoList[2].SetActive(true);
                XRList[2].SetActive(true);
                EffectList[2].SetActive(true);
                LabelList[2].SetActive(true);
                clearmode.AllMapLabels = LabelList[2];
                break;
            case "Winter":
                PanoList[3].SetActive(true);
                XRList[3].SetActive(true);
                EffectList[3].SetActive(true);
                LabelList[3].SetActive(true);
                clearmode.AllMapLabels = LabelList[3];
                break;
        }
    }

    void SeasonBar()
    {
        if(seasonstate == SeasonState.Closing)
        {
            seasonBar.transform.localPosition = new Vector3(seasonBar.transform.localPosition.x, Mathf.Lerp(seasonBar.transform.localPosition.y, 720, Time.deltaTime*3), seasonBar.transform.localPosition.z);
            if(seasonBar.transform.localPosition.y > 715)
            {
                seasonBar.transform.localPosition = new Vector3(seasonBar.transform.localPosition.x, 720, seasonBar.transform.localPosition.z);
                seasonstate = SeasonState.Close;
            }
        }
        else if(seasonstate == SeasonState.Opening)
        {
            seasonBar.transform.localPosition = new Vector3(seasonBar.transform.localPosition.x, Mathf.Lerp(seasonBar.transform.localPosition.y, 508, Time.deltaTime*3), seasonBar.transform.localPosition.z);
            if(seasonBar.transform.localPosition.y<513)
            {
                seasonBar.transform.localPosition = new Vector3(seasonBar.transform.localPosition.x, 508, seasonBar.transform.localPosition.z);
                seasonstate = SeasonState.Open;
            }
        }
    }

    public void OnClickSeasonBarBtn(Image img)
    {
        if(seasonstate == SeasonState.Open || seasonstate == SeasonState.Opening)
        {
            img.transform.GetChild(0).gameObject.SetActive(false);
            seasonstate = SeasonState.Closing;
        }
        else if(seasonstate == SeasonState.Close || seasonstate == SeasonState.Closing)
        {
            img.transform.GetChild(0).gameObject.SetActive(true);
            seasonstate = SeasonState.Opening;
        }
    }
}
