using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class EndIsland_Tour : MonoBehaviour
{
    public GameManager gamemanager;
    public TourismMode tourismmode;
    public GameObject AllMapLabels;
    public GameObject RoadMapLabels;

    public GameObject[] Tourlist;
    //public LabelDetail labeldetail;
    public GameObject PathToggle;
    public Sprite PathMode;
    public Sprite TourMode;
    public GameObject ResultList;
    public GameObject SelectTour;
    public List<GameObject> SelectPathList = new List<GameObject>();
    public GameObject TourManager;
    public GameObject See360;
    public GameObject ClickObj;
    string NowLanguage;
    [SerializeField]
    GameObject Toggle;

    [SerializeField]
    public List<Sprite> splist = new List<Sprite>();
    [SerializeField]
    Material Video360;
    [SerializeField]
    Image SeeImg;
    [SerializeField]
    GameObject notcie360;
    [SerializeField]
    public GameObject TourMessage;

    public enum LabelDetailState
    {
        Close,
        Open,
        Closing,
        Opening,
    }
    public LabelDetailState labeldetailstate = 0;

    [SerializeField]
    public GameObject DetailImage_Background;
    [SerializeField]
    public Image DetailImage;
    [SerializeField]
    public UIText DetailText;
    [SerializeField]
    public Text DetailTitleText;
    [SerializeField]
    public Text DetailSubTitleText;
    [SerializeField]
    public RectTransform DetailTextContent;
    [SerializeField]
    GameObject DetailOpenBtn;

    float changescaletime;
    bool ChangeScale = false;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //gamemanager.Homebtn.SetActive(false);
        gamemanager.endisland_tour = this;
        gamemanager.ad = GetComponent<AudioSource>();
        tourismmode = gamemanager.tourismode;
        tourismmode.UISetting();
        tourismmode.TourLabel_list.Clear();
        for (int i=0; i<AllMapLabels.transform.childCount; i++)
        {
            tourismmode.TourLabel_list.Add(AllMapLabels.transform.GetChild(i).gameObject);
            //gamemanager.labelmake.Tour_RoadLabel.Add(RoadMapLabels.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>());
        }


        //TourismMode.TourLabel_list = new GameObject[Tourlist.Length];
        //TourismMode.TourLabel_list = Tourlist;

        tourismmode.MapLabel();
        AllMapLabels.transform.parent.gameObject.GetComponent<DisableLabel>().MapLabel();

        if (SceneManager.GetActiveScene().name.Contains("Tourism"))
        {
            GameManager.PrevMode = "TourismMode";
        }

        NowLanguage = GameManager.langstate.ToString();
        changescaletime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (NowLanguage != GameManager.langstate.ToString())
        {
            tourismmode.MapLabel();
            AllMapLabels.transform.parent.gameObject.GetComponent<DisableLabel>().MapLabel();

            NowLanguage = GameManager.langstate.ToString();
        }

        if(ChangeScale == true)
        {
            TogglePath();
        }

        LabelDetail();
    }

    public void TogglePath()
    {
        changescaletime += Time.deltaTime;

        if (Toggle.activeSelf)      // 일반모드(scale = 1)
        {
            if (Mathf.Abs(BackGroundDefault.transform.localScale.x - 1) > 0.01f)
            {
                BackGroundDefault.transform.position = Vector3.Lerp(new Vector3(-852.0f, 412.0f, 537.0f), new Vector3(-739.0f, 479.0f, 537.0f), changescaletime * 2f);
                BackGroundDefault.transform.localScale = Vector3.Lerp(new Vector3(0.775f, 0.775f, 0.775f), new Vector3(1, 1, 1), changescaletime * 2f);
                SetRoadUI.fillAmount = Mathf.Lerp(1, 0, changescaletime * 2f);

            }
            else if (Mathf.Abs(BackGroundDefault.transform.localScale.x - 1) <= 0.01f)
            {
                BackGroundDefault.transform.position = new Vector3(-739.0f, 479.0f, 537.0f);
                BackGroundDefault.transform.localScale = new Vector3(1, 1, 1);
                SetRoadUI.fillAmount = 0;
                AllMapLabels.SetActive(true);
                DisableLabel.transform.GetChild(0).gameObject.SetActive(true);
                DisableLabel.transform.GetChild(1).gameObject.SetActive(true);
                changescaletime = 0;
                ChangeScale = false;
            }
        }
        else if (!Toggle.activeSelf)      // 길찾기모드(scale = 0.775)
        {
            if (Mathf.Abs(BackGroundDefault.transform.localScale.x - 0.775f) > 0.01f)
            {
                BackGroundDefault.transform.position = Vector3.Lerp(new Vector3(-739.0f, 479.0f, 537.0f), new Vector3(-852.0f, 412.0f, 537.0f), changescaletime * 2f);
                BackGroundDefault.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(0.775f, 0.775f, 0.775f), changescaletime * 2f);
                SetRoadUI.fillAmount = Mathf.Lerp(0, 1, changescaletime * 2f);
            }
            else if (Mathf.Abs(BackGroundDefault.transform.localScale.x - 0.775f) <= 0.01f)
            {
                BackGroundDefault.transform.position = new Vector3(-852.0f, 412.0f, 537.0f);
                BackGroundDefault.transform.localScale = new Vector3(0.775f, 0.775f, 0.775f);
                SetRoadUI.fillAmount = 1;
                RoadMapLabels.SetActive(true);

                for (int index = 0; index < RoadMapLabels.transform.childCount; index++)
                {
                    if (RoadMapLabels.transform.GetChild(index).gameObject.name != "Observation")
                    {
                        RoadMapLabels.transform.GetChild(index).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    }
                }
                changescaletime = 0;
                ChangeScale = false;
            }
        }

        //if (TourPath == false)
        //{
        //    PathToggle.GetComponent<Image>().sprite = PathMode;
        //    ResultList.SetActive(true);
        //    TourPath = true;
        //}
        //else if (TourPath == true)
        //{
        //    PathToggle.GetComponent<Image>().sprite = TourMode;
        //    ResultList.SetActive(false);
        //    TourPath = false;
        //}
    }

    [SerializeField]
    GameObject Video360Btn;
    [SerializeField]
    GameObject Img2DBtn;
    [SerializeField]
    GameObject ButtonBackground;
    [SerializeField]
    VideoPlayer videoplayer;
    public void SelectLabel(GameObject Label)
    {
        if(!TourManager.activeSelf)
        {
            Video360Btn.SetActive(false);
            Img2DBtn.SetActive(false);
            ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 80);
            switch (Label.name)
            {
                case "Island":
                    this.gameObject.GetComponent<EndIsland_Eco>().swan_ani.gameObject.SetActive(true);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("SeeSwan");
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    this.gameObject.GetComponent<EndIsland_Eco>().swan_ani.gameObject.transform.parent.gameObject.SetActive(true);
                    this.gameObject.GetComponent<EndIsland_Eco>().swan_ani.StartAni();
                    break;
                case "Dumujin":
                    See360.SetActive(false);
                    SeeImg.gameObject.SetActive(false);
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    break;
                case "Tower":
                    Video360.SetTexture("_MainTex", splist[8].texture);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("Tour_360");
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(357,220,0);
                    SeeImg.gameObject.SetActive(false);
                    Video360Btn.SetActive(true);
                    Video360Btn.GetComponent<see360Btn>().count = 0;
                    Video360Btn.GetComponent<see360Btn>().splist = Label.GetComponent<Video360info>().Splist;
                    break;
                case "Nampori":
                    See360.SetActive(false);
                    SeeImg.gameObject.SetActive(true);
                    SeeImg.sprite = splist[10];
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    break;
                case "Dragon":
                    Video360.SetTexture("_MainTex", splist[0].texture);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("Tour_Video");
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(0, 220, 354);
                    SeeImg.gameObject.SetActive(false);
                    Img2DBtn.SetActive(true);
                    videoplayer.clip = Label.gameObject.GetComponent<VideoClipinfo>().video;
                    break;
                case "Kongdol":
                    Video360.SetTexture("_MainTex", splist[1].texture);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("Tour_Video");
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(0, 45, 0);
                    SeeImg.gameObject.SetActive(false);
                    Img2DBtn.SetActive(true);
                    videoplayer.clip = Label.gameObject.GetComponent<VideoClipinfo>().video;
                    break;
                case "Sagoj":
                    Video360.SetTexture("_MainTex", splist[3].texture);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("Tour_Video");
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(0, 250, 354);
                    SeeImg.gameObject.SetActive(false);
                    Img2DBtn.SetActive(true);
                    videoplayer.clip = Label.gameObject.GetComponent<VideoClipinfo>().video;
                    break;
                case "Dock":
                    See360.SetActive(false);
                    SeeImg.gameObject.SetActive(true);
                    SeeImg.sprite = splist[11];
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    break;
                case "Observation":
                    Video360.SetTexture("_MainTex", splist[2].texture);
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(2.5f, 286, 0);
                    SeeImg.gameObject.SetActive(false);
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    Notcie360();
                    break;
                case "SealRock":
                    Video360.SetTexture("_MainTex", splist[4].texture);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("Tour_Video");
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(0, 320, 354);
                    SeeImg.gameObject.SetActive(false);
                    Img2DBtn.SetActive(true);
                    videoplayer.clip = Label.gameObject.GetComponent<VideoClipinfo>().video;
                    break;
                case "Simchung":
                    Video360.SetTexture("_MainTex", splist[5].texture);
                    TourMessage.GetComponent<NoticeWindow>().NoticeWindowOpen("Tour_360");
                    See360.SetActive(true);
                    See360.transform.rotation = Quaternion.Euler(5, 185, 0);
                    SeeImg.gameObject.SetActive(false);
                    Video360Btn.SetActive(true);
                    Video360Btn.GetComponent<see360Btn>().count = 0;
                    Video360Btn.GetComponent<see360Btn>().splist = Label.GetComponent<Video360info>().Splist;
                    break;
                case "Lion":
                    See360.SetActive(false);
                    SeeImg.gameObject.SetActive(true);
                    SeeImg.sprite = splist[12];
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 80);
                    break;
            }



            AllMapLabels.transform.parent.gameObject.SetActive(false);
            ClickObj = Label;

            tourismmode.SelectLabel(Label.name);
            labeldetailstate = LabelDetailState.Opening;
            
        }
    }

    [SerializeField]
    GameObject Dumujin360;
    public void Out360()
    {
        if (Toggle.activeSelf)
        {
            if (ClickObj != null)
            {
                if (ClickObj.name == "Island")
                {
                    BackGroundDefault.SetActive(true);
                    AllMapLabels.transform.parent.gameObject.SetActive(true);
                    this.gameObject.GetComponent<EndIsland_Eco>().swan_ani.finishAni();
                    //this.gameObject.GetComponent<EndIsland_Eco>().swan_ani.gameObject.transform.parent.gameObject.SetActive(false);
                    ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 80);
                    ClickObj = null;
                    labeldetailstate = LabelDetailState.Closing;
                    this.gameObject.GetComponent<EndIsland_Eco>().swan_ani.gameObject.SetActive(false);
                }
                else
                {
                    if (See360.activeSelf || SeeImg.gameObject.activeSelf || Dumujin360.activeSelf)
                    {
                        if (!TourManager.activeSelf)
                        {
                            ButtonBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 80);
                            Dumujin360.SetActive(false);
                            SeeImg.gameObject.SetActive(false);
                            See360.SetActive(false);
                            AllMapLabels.transform.parent.gameObject.SetActive(true);
                            ClickObj = null;
                            labeldetailstate = LabelDetailState.Closing;
                        }
                    }
                }
            }
        } else if (!Toggle.activeSelf)
        {
            roadManager.SetActive(false);
            Toggle.SetActive(true);
            RoadMapLabels.SetActive(false);
            roadManager.GetComponent<DirectionManager>().Reset();
            ChangeScale = true;
        }
    }

    public void NarrStopPlay()
    {
        //if (gamemanager.label.PlayNarr == true)
        //{
        //    gamemanager.label.Narration.Stop();
        //}
        //else if (gamemanager.label.PlayNarr == false)
        //{
        //    gamemanager.label.Narration.Play();
        //}
        //Invoke("WaitStopPlay", 0.5f);
    }

    public void WaitStopPlay()
    {
        //if (gamemanager.label.PlayNarr == true)
        //{
        //    gamemanager.labeldetail.Detail_Background.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = gamemanager.label.Narr_On;
        //    gamemanager.label.PlayNarr = false;
        //}
        //else if (gamemanager.label.PlayNarr == false)
        //{
        //    gamemanager.labeldetail.Detail_Background.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = gamemanager.label.Narr_Off;
        //    gamemanager.label.PlayNarr = true;
        //}
    }

    [SerializeField]
    GameObject BackGroundRoad;
    [SerializeField]
    GameObject BackGroundDefault;

    [SerializeField]
    public GameObject roadManager;
    public Image SetRoadUI;
    public GameObject DisableLabel;
    [SerializeField]
    GameObject Car;
    public void OnClickToggle()
    {
        if (Toggle.activeSelf)
        {
            Car.SetActive(false);
            Toggle.SetActive(false);
            roadManager.SetActive(true);
            DisableLabel.transform.GetChild(0).gameObject.SetActive(false); 
            DisableLabel.transform.GetChild(1).gameObject.SetActive(false);
            AllMapLabels.SetActive(false);
        }
        else
        {
            Car.SetActive(true);
            roadManager.SetActive(false);
            Toggle.SetActive(true);
            RoadMapLabels.SetActive(false);
            roadManager.GetComponent<DirectionManager>().Reset();
        }
        ChangeScale = true;
    }

    public List<GameObject> foodlist = new List<GameObject>();
    public void FoodLang()
    {
        for(int i=0; i<foodlist.Count; i++)
        {
            foodlist[i].gameObject.SetActive(false);
        }
        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                foodlist[0].gameObject.SetActive(true);
                break;
            case GameManager.LangState.English:
                foodlist[1].gameObject.SetActive(true);
                break;
            case GameManager.LangState.Chienses:
                foodlist[2].gameObject.SetActive(true);
                break;
            case GameManager.LangState.Japan:
                foodlist[3].gameObject.SetActive(true);
                break;
        }
    }

    public void Notcie360()
    {
        notcie360.SetActive(true);
        Invoke("OffNotice360", 1f);
    }

    void OffNotice360()
    {
        notcie360.SetActive(false);
    }

    void LabelDetail()
    {
        //float speed = (1 / 493 * Time.deltaTime);
        switch (labeldetailstate)
        {
            //725 1218
            case LabelDetailState.Opening:
                DetailImage_Background.transform.localPosition = new Vector3(Mathf.Lerp(DetailImage_Background.transform.localPosition.x, 725, Time.deltaTime * 2), 393.5f, 0);
                if (Math.Abs(DetailImage_Background.transform.localPosition.x - 725) < 5)
                {
                    DetailImage_Background.transform.localPosition = new Vector3(725, 393.5f, 0);
                    DetailOpenBtn.SetActive(false);
                    labeldetailstate = LabelDetailState.Open;
                }
                break;
            case LabelDetailState.Closing:
                if (gamemanager.ad.isPlaying)
                {
                    gamemanager.ad.Stop();
                }
                DetailImage_Background.transform.localPosition = new Vector3(Mathf.Lerp(DetailImage_Background.transform.localPosition.x, 1218, Time.deltaTime * 2), 393.5f, 0);
                if (Math.Abs(DetailImage_Background.transform.localPosition.x - 1218) < 5)
                {
                    DetailImage_Background.transform.localPosition = new Vector3(1218, 393.5f, 0);
                    if(!AllMapLabels.transform.parent.gameObject.activeSelf)
                    {
                        DetailOpenBtn.SetActive(true);
                    }
                    labeldetailstate = LabelDetailState.Close;
                }
                break;
        }
    }

    public void CloseLabelDetail()
    {
        labeldetailstate = LabelDetailState.Closing;
    }

    public void OpenLabelDetail()
    {
        DetailOpenBtn.SetActive(false);
        labeldetailstate = LabelDetailState.Opening;
    }
}
