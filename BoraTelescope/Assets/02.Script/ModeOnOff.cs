using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeOnOff : MonoBehaviour
{
    [SerializeField]
    GameManager gamemanager;
    public GameObject LiveMode;
    public GameObject XRMode;
    public GameObject ClearMode;
    public GameObject PastMode;
    public GameObject GuideMode;
    public GameObject LanguageMode;
    public GameObject TipMode;
    public GameObject CaptureMode;
    public GameObject VisitMode;
    public GameObject EtcMode;
    public GameObject NamsanHMode;
    public GameObject CultureMode;
    public List<GameObject> ModeList = new List<GameObject>();

    GameObject NHobj;
    // Start is called before the first frame update
    void Start()
    {
        ModeList.Add(LiveMode);
        ModeList.Add(XRMode);
        ModeList.Add(ClearMode);
        ModeList.Add(PastMode);
        ModeList.Add(GuideMode);
        ModeList.Add(LanguageMode);
        ModeList.Add(TipMode);
        ModeList.Add(CaptureMode);
        ModeList.Add(VisitMode);
        ModeList.Add(EtcMode);
        ModeList.Add(NamsanHMode);
        ModeList.Add(CultureMode);
    }

    public void Reset()
    {
        for(int i=0; i<ModeList.Count; i++)
        {
            ModeList[i].transform.GetChild(0).gameObject.SetActive(false);
        }

        if(SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            ClearMode.transform.GetChild(0).gameObject.SetActive(true); 
        }
        else if(SceneManager.GetActiveScene().name.Contains("XRMode"))
        {
            LiveMode.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    public void NamsanHIn()
    {
        //transform.GetChild(0).gameObject.SetActive(false);
        //NamsanHMode.gameObject.SetActive(true);
        //NHobj = Instantiate(EtcMode);
        //NHobj.name = "Etc";
        //NHobj.transform.parent = VisitMode.transform.parent;
        //VisitMode.SetActive(false);
        //NHobj.transform.localPosition = VisitMode.transform.localPosition;
        //gamemanager.MiniMap_Background.transform.parent.gameObject.SetActive(true);

        CultureMode.SetActive(false);
        LiveMode.SetActive(false);
        ClearMode.SetActive(false);
        PastMode.SetActive(false);
        GuideMode.SetActive(false);
        VisitMode.SetActive(false);
        NamsanHMode.SetActive(true);
        NamsanHMode.transform.GetChild(0).gameObject.SetActive(true);
        EtcMode.transform.localPosition = XRMode.transform.localPosition;
    }

    public void NamsanHout()
    {
        //transform.GetChild(0).gameObject.SetActive(true);
        //NamsanHMode.gameObject.SetActive(false);
        //Destroy(NHobj);
        //NHobj = null;
        //VisitMode.SetActive(true);



        NamsanHMode.SetActive(false);
        LiveMode.SetActive(true);
        ClearMode.SetActive(true);
        PastMode.SetActive(true);
        GuideMode.SetActive(true);
        VisitMode.SetActive(true);
        EtcMode.transform.localPosition = new Vector3(XRMode.transform.localPosition.x, 0, 0);
        gamemanager.MiniMap_Background.transform.parent.gameObject.SetActive(true);
    }

    public void CultureIn()
    {
        CultureMode.SetActive(true);
        LiveMode.SetActive(false);
        ClearMode.SetActive(false);
        PastMode.SetActive(false);
        GuideMode.SetActive(false);
        VisitMode.SetActive(false);
        gamemanager.Homebtn.SetActive(false);
        NamsanHMode.SetActive(false);
        EtcMode.transform.localPosition = XRMode.transform.localPosition;
    }

    public void CultureOut()
    {
        CultureMode.SetActive(false);
        LiveMode.SetActive(true);
        ClearMode.SetActive(true);
        PastMode.SetActive(true);
        GuideMode.SetActive(true);
        VisitMode.SetActive(true);
        gamemanager.Homebtn.SetActive(true);
        EtcMode.transform.localPosition = new Vector3(XRMode.transform.localPosition.x, 0, 0);
        gamemanager.MiniMap_Background.transform.parent.gameObject.SetActive(true);
    }

    public void OnClearMode()
    {
        Reset();
        ClearMode.transform.GetChild(0).gameObject.SetActive(true);
    }
}
