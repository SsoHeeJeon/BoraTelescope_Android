using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameManager;
using static Loading;


public class ARModeLabelPosition
{
    public string LabelName;
    public float Label_X;
    public float Label_Y;

    public ARModeLabelPosition(string labelname, float label_x, float label_y)
    {
        LabelName = labelname;
        Label_X = label_x;
        Label_Y = label_y;
    }
}

public class LabelText
{
    public string LabelName_K;
    public string LabelName_E;
    public string LabelName_C;
    public string LabelName_J;
    public string LabelName;
    public string Korean;
    public string English;
    public string Chinese;
    public string Japanese;

    public LabelText(string labelname, string kor, string eng, string chi, string jap)
    {
        LabelName = labelname;
        Korean = kor;
        English = eng;
        Chinese = chi;
        Japanese = jap;
    }
}

public class PanTiltRange
{
    public float Min_Pan;
    public float Max_Pan;
    public float Min_Tilt;
    public float Max_Tilt;
    public float StartPosition_x;
    public float StartPosition_y;
    public float ChangeValue_x;
    public float ChangeValue_y;
    public int WaitingTime;

    public PanTiltRange(float minx, float maxx, float miny, float maxy, float startlabel_x, float startlabel_y, float valueX, float valueY, int waittime)
    {
        Min_Pan = minx;
        Max_Pan = maxx;
        Min_Tilt = miny;
        Max_Tilt = maxy;
        StartPosition_x = startlabel_x;
        StartPosition_y = startlabel_y;
        ChangeValue_x = valueX;
        ChangeValue_y = valueY;
        WaitingTime = waittime;
    }
}

public class GameManager : Contentsinfo
{
    private static GameManager instance;

    //��ũ��Ʈ
    public Loading loading;
    public ClearMode clearMode;
    public BoraJoyStickLotte joystick;
    public VideoManager guidevideo;
    public ScreenCapture screencapture;
    public Visitmanager visitmanager;
    public ModeOnOff modeonoff;
    public See360Lotte see360;
    public PinchZoom pinchzoom;
    public NamSanHMode namsanhmode;
    public TourismMode tourismode;
    public EndIsland_Tour endisland_tour;

    //���� UI
    public GameObject UI_All;
    public GameObject MenuBar;
    public GameObject NavigationBar;
    public GameObject LanguageBar;
    public GameObject EtcBar;
    public GameObject Arrow;
    public GameObject MiniMap_Background;
    public GameObject MiniMap_Camera;
    public GameObject MiniMap_CameraGuide;
    public GameObject ZoomBar;
    public GameObject ErrorMessage;
    public GameObject CategoryContent;
    public GameObject Tip_Obj;
    public GameObject CaptureBtn;
    public GameObject BackGround;
    public GameObject CaptueObject;
    public GameObject Homebtn;
    public GameObject Tipbtn;
    public GameObject AutoModePlayer;
    public GameObject Zoombtn;
    public GameObject CaptureSelfi;
    public GameObject Selfi_Obj;
    public GameObject stopselfi;
    public AudioSource ad;
    public Sprite ZoomIn;
    public Sprite ZoomOut;
    public GameObject GM;
    public GameObject Manager;

    // �����
    public AudioSource ButtonEffect;
    public AudioClip ButtonSound;

    // �׺���̼�â, ����â On/Off
    public string MoveDir;
    public float navi_t;
    public float langnavi_t;
    public float ETCnavi_t;
    public static float touchCount;
    public Scrollbar naviscroll;
    public GameObject navilabel;
    public RectTransform NaviRect;
    public RectTransform LangRect;
    public RectTransform EtcRect;
    public Image LangChildImg;
    public Image EtcChildImg;


    public float minimapCamera_x;

    public bool NaviOn = false;
    public bool langNaviOn = false;
    public bool EtcOn = false;
    public bool moveNavi = false;
    public bool movelangNavi = false;
    public bool moveEtcNavi = false;
    public static bool MoveCamera = false;
    public bool WantNoLabel = false;
    public static bool AnyError = false;
    public static float ErrorMessageTime;
    public static bool Readpulse = false;
    public static string PreScene;
    public static bool SettingLabelPosition = false;
    public bool StartMiniMapDrag = false;

    public static string PrevMode;
    public bool alreadywaitingLog = false;
    public bool GuideCheck;

    public bool StartPast;
    public bool StartGuide;
    public bool StartCapture;

    public static float waitingTime = 300;
    public float ResetPositionTime;
    string ManagerModePassword = "025697178";
    //public Vector3 Arrowpos_normal = new Vector3(213.0f, 197.0f);
    public Vector3 Arrowpos_extend = new Vector3(286.0f, 180.0f);
    public static float barOpen = 472f;
    public static float barClose = 60f;
    public static uint startlabel_x;
    public static uint startlabel_y;
    public static string MainMode = "LiveMode";

    public float touchtime;
    public static bool ClearModeFirst = false;
    public bool Pastcheck;


    public enum State
    {
        //Demo,
        NoDemo,
    }
    public State state = 0;

    public enum NavibarState
    {
        Open,
        Close,
        Opening,
        Closing,
    }
    public NavibarState navibarstate = 0;
    Image NaviBackground;

    public enum LangBarState
    {
        Close,
        Open,
        Opening,
        Closing,
    }
    public LangBarState langbarstate = 0;
    Image LangBackground;

    public enum EtcBarState
    {
        Close,
        Open,
        Opening,
        Closing,
    }
    public EtcBarState etcbarstate = 0;
    Image EtcBackground;

    public enum LangState
    {
        Korea,
        Japan,
        English,
        Chienses,
    }
    public static LangState langstate = 0;

    public enum WaitingCheckState
    {
        None,
        Check,
        CheckFinish,
    }
    public WaitingCheckState waitingcheckstate = 0;

    // Start is called before the first frame update
    void Start()
    {
        NaviBackground = NavigationBar.transform.GetChild(0).gameObject.GetComponent<Image>();
        LangBackground = LanguageBar.transform.GetChild(0).gameObject.GetComponent<Image>();
        EtcBackground = EtcBar.transform.GetChild(0).gameObject.GetComponent<Image>();
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
        DontDestroyOnLoad(GM);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ChangeLang(langstate);
        Screen.SetResolution(1920, 1080, true);
    }

    private int ClickCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0))
        {
            touchtime = 0;
        }
        else
        {
            if (!SceneManager.GetActiveScene().name.Contains("WaitingMode"))
            {
                //touchtime += Time.deltaTime;
            }
        }

        if (touchtime > 60)
        {
            if (!Tip_Obj.activeSelf)
            {
                OnClickHomeBtn();
            }
            if (touchtime > 120)
            {
                UI_All.SetActive(false);
                SceneManager.LoadScene("WaitingMode");
                touchtime = 0;
            }
        }

        NaviArr_set();
        LangArr_set();
        EtcArr_set();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))
                Invoke("DoubleClick", 1.0f);

        }
        else if (ClickCount >= 2)
        {
            CancelInvoke("DoubleClick");
            Application.Quit();
        }
    }

    private void DoubleClick()
    {
        ClickCount = 0;
    }


    public void Menu(GameObject btn)
    {
        see360.GameObject.transform.parent = see360.gameObject.transform;
        see360.GameObject.transform.localPosition = Vector3.zero;
        see360.GameObject.SetActive(false);

        if (Tip_Obj.activeSelf)
        {
            Tip_Obj.SetActive(false);
            modeonoff.TipMode.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            if (!(btn.name == "Tip" || btn.name == "Language" || btn.name == "Etc"))
            {
                for (int i = 0; i < modeonoff.ModeList.Count; i++)
                {
                    modeonoff.ModeList[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            try
            {
                btn.transform.GetChild(0).gameObject.SetActive(true);
            }
            catch
            {
                modeonoff.PastMode.transform.GetChild(0).gameObject.SetActive(true);
            }
            switch (btn.name)
            {
                case "LiveMode":
                    ErrorMessage.gameObject.SetActive(true);
                    modeonoff.LiveMode.transform.GetChild(0).gameObject.SetActive(false);
                    modeonoff.ClearMode.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "XRMode":
                    ErrorMessage.gameObject.SetActive(true);
                    break;
                case "ClearMode":
                    if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
                    {
                        if (Contentsinfo.ContentsName == "Lotte")
                        {
                            if (clearMode.Clear120Obj.activeSelf)
                            {
                                if (see360.obj360.transform.parent.gameObject.activeSelf)
                                {
                                    see360.Close360();
                                }

                                if (navibarstate == NavibarState.Close || navibarstate == NavibarState.Closing)
                                {
                                    navibarstate = NavibarState.Opening;
                                    etcbarstate = EtcBarState.Closing;
                                    langbarstate = LangBarState.Closing;
                                }
                                else if (navibarstate == NavibarState.Open || navibarstate == NavibarState.Opening)
                                {
                                    navibarstate = NavibarState.Closing;
                                }
                            }
                        }
                        else
                        {
                            if (navibarstate == NavibarState.Close || navibarstate == NavibarState.Closing)
                            {
                                navibarstate = NavibarState.Opening;
                                etcbarstate = EtcBarState.Closing;
                                langbarstate = LangBarState.Closing;
                            }
                            else if (navibarstate == NavibarState.Open || navibarstate == NavibarState.Opening)
                            {
                                navibarstate = NavibarState.Closing;
                            }
                        }
                    }
                    else if (SceneManager.GetActiveScene().name != "ClearMode")
                    {
                        if (see360.obj360.transform.parent.gameObject.activeSelf)
                        {
                            see360.Close360();
                        }

                        if (startstate == StartState.Lotte)
                        {
                            //Loading.nextScene = "ClearModeLotte";
                            OnClickLotte();
                        }
                        else if (startstate == StartState.Odu)
                        {
                            Loading.nextScene = "ClearModeOdu";
                        }
                        SceneManager.LoadScene("Loading");
                    }
                    break;
                case "PastMode":
                    if (!see360.obj360.transform.parent.gameObject.activeSelf)
                    {
                        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
                        {
                            if (startstate == StartState.Lotte)
                            {
                                langbarstate = LangBarState.Closing;
                                etcbarstate = EtcBarState.Closing;
                                navibarstate = NavibarState.Closing;
                                ResetList();
                                ContentsName = "Lotte";
                                TelescopeInfo(ContentsName);
                                GetComponent<ReadJsonFile>().Readfile();
                                Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
                                Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
                                Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
                                Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
                                // Pastcheck = true;
                                // Loading.nextScene = "XRMode";
                                // SceneManager.LoadSceneAsync("Loading");
                            }
                            else if (startstate == StartState.Odu)
                            {
                                langbarstate = LangBarState.Closing;
                                etcbarstate = EtcBarState.Closing;
                                navibarstate = NavibarState.Closing;
                                ResetList();
                                ContentsName = "Odu";
                                TelescopeInfo(ContentsName);
                                GetComponent<ReadJsonFile>().Readfile();
                                Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
                                Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
                                Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
                                Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
                                // Pastcheck = true;
                                // Loading.nextScene = "XRMode";
                                // SceneManager.LoadSceneAsync("Loading");
                            }

                            see360.GameObject.SetActive(true);
                            see360.GameObject.transform.parent = Camera.main.transform;
                            see360.GameObject.transform.localPosition = Vector3.zero;
                            see360.obj360.transform.GetChild(0).transform.position = new Vector3(0, 0, 0);
                        }
                        else
                        {
                            ErrorMessage.SetActive(true);
                        }
                    }
                    break;
                case "GuideMode":
                    if (see360.obj360.transform.parent.gameObject.activeSelf)
                    {
                        see360.Close360();
                        if (state == State.NoDemo)
                        {
                            GameObject obj = new GameObject();
                            obj.name = "ClearMode";
                            Menu(obj);
                            Destroy(obj);
                        }
                    }
                    guidevideo.GuideLanguage();
                    guidevideo.transform.parent.gameObject.SetActive(true);

                    break;
                case "Language":
                    if (langbarstate == LangBarState.Open || langbarstate == LangBarState.Opening)
                    {
                        langbarstate = LangBarState.Closing;
                    }
                    else
                    {
                        langbarstate = LangBarState.Opening;
                        etcbarstate = EtcBarState.Closing;
                        navibarstate = NavibarState.Closing;
                    }
                    break;
                case "Tip":
                    if (!Tip_Obj.activeSelf)        // Tip �̹����� ��Ȱ��ȭ���¸� Ȱ��ȭ
                    {
                        Tip_Obj.SetActive(true);
                    }
                    else if (Tip_Obj.activeSelf)      // Tip �̹����� Ȱ��ȭ ���¸� ��Ȱ��ȭ
                    {
                        Tip_Obj.SetActive(false);
                    }
                    break;
                case "Etc":
                    EtcBar.SetActive(true);
                    if (etcbarstate == EtcBarState.Open || etcbarstate == EtcBarState.Opening)
                    {
                        etcbarstate = EtcBarState.Closing;
                    }
                    else if (etcbarstate == EtcBarState.Closing || etcbarstate == EtcBarState.Close)
                    {
                        etcbarstate = EtcBarState.Opening;
                        navibarstate = NavibarState.Closing;
                        langbarstate = LangBarState.Closing;
                    }
                    break;
                case "Capture":
                    if (!CaptureSelfi.activeSelf)
                    {
                        CaptureSelfi.SetActive(true);
                    }
                    else
                    {
                        CaptureSelfi.SetActive(false);
                    }
                    break;
                case "Setting":

                    break;
                case "Navi_Close":      // �׺���̼� â�� x ��ư �����ϸ� �׺���̼�â ��Ȱ��ȭ
                    navibarstate = NavibarState.Closing;
                    if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
                    {
                        modeonoff.ClearMode.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    break;
                case "LangNavi_Close":      // ���� â�� x ��ư �����ϸ� ���� ��Ȱ��ȭ
                    langbarstate = LangBarState.Closing;
                    if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
                    {
                        modeonoff.ClearMode.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    //MenuBar.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case "Etc_Close":      // ���� â�� x ��ư �����ϸ� ���� ��Ȱ��ȭ
                    etcbarstate = EtcBarState.Closing;
                    if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
                    {
                        modeonoff.ClearMode.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    break;
                case "Visit":
                    if (!SceneManager.GetActiveScene().name.Contains("VisitMode"))
                    {
                        if (see360.obj360.transform.parent.gameObject.activeSelf)
                        {
                            see360.Close360();
                        }
                        UI_All.SetActive(false);
                        modeonoff.Reset();
                        //if (NNCam.Controller._webcam != null)
                        //{
                        //    NNCam.Controller._webcam.Stop();
                        //}
                        Loading.nextScene = "VisitMode";
                        SceneManager.LoadScene("Loading");
                    }
                    break;
                case "NamsanHMode":
                    namsanhmode.OnClickHomeBtn();
                    if (navibarstate == NavibarState.Open || navibarstate == NavibarState.Opening)
                    {
                        navibarstate = NavibarState.Closing;
                    }
                    else if (navibarstate == NavibarState.Close || navibarstate == NavibarState.Closing)
                    {
                        navibarstate = NavibarState.Opening;
                    }
                    break;
            }
        }
    }

    public void NaviArr_set()
    {
        if (NaviRect == null)
        {
            NaviRect = NavigationBar.GetComponent<RectTransform>();
        }
        if (navibarstate == NavibarState.Opening)
        {
            Arrow.SetActive(false);
            if (NaviRect.sizeDelta.x < barOpen)
            {
                NaviRect.sizeDelta = Vector2.Lerp(NaviRect.sizeDelta, new Vector2(barOpen + 5f, 1080), Time.deltaTime * 5);
                NaviBackground.fillAmount += 0.5f * Time.deltaTime;
                if (NaviRect.sizeDelta.x > barOpen - 5)
                {
                    NaviRect.sizeDelta = new Vector2(barOpen + 5f, 1080);
                    navibarstate = NavibarState.Open;
                }
            }
        }
        else if (navibarstate == NavibarState.Closing)
        {
            if (NaviRect.sizeDelta.x > barClose)
            {
                NaviRect.sizeDelta = Vector2.Lerp(NaviRect.sizeDelta, new Vector2(barClose - 5f, 1080), Time.deltaTime * 3);
                NaviBackground.fillAmount -= 0.5f * Time.deltaTime;
                if (NaviRect.sizeDelta.x < barClose + 10)
                {
                    if (etcbarstate == EtcBarState.Close && langbarstate == LangBarState.Close)
                    {
                        if (!(ContentsName == "NamsanH" || ContentsName == "Dora"))
                        {
                            if (!SceneManager.GetActiveScene().name.Contains("VisitMode"))
                            {
                                Arrow.SetActive(true);
                            }
                        }
                    }
                    if (see360.obj360.transform.parent.gameObject.activeSelf)
                    {
                        Arrow.SetActive(false);
                    }
                    NaviRect.sizeDelta = new Vector2(barClose + 5f, 1080);
                    navibarstate = NavibarState.Close;
                }
            }
        }
    }

    public void LangArr_set()
    {
        if (LangRect == null)
        {
            LangRect = LanguageBar.GetComponent<RectTransform>();
        }
        if (langbarstate == LangBarState.Opening)
        {
            Arrow.SetActive(false);
            if (LangRect.sizeDelta.x < barOpen)
            {
                LangRect.sizeDelta = Vector2.Lerp(LangRect.sizeDelta, new Vector2(barOpen + 5f, 1080), Time.deltaTime * 5);
                LangBackground.fillAmount += 0.5f * Time.deltaTime;
                if (LangRect.sizeDelta.x > barOpen - 5)
                {
                    LangRect.sizeDelta = new Vector2(barOpen + 5f, 1080);
                    langbarstate = LangBarState.Open;
                }
            }
        }
        else if (langbarstate == LangBarState.Closing)
        {
            if (LangRect.sizeDelta.x > barClose)
            {
                LangRect.sizeDelta = Vector2.Lerp(LangRect.sizeDelta, new Vector2(barClose - 5f, 1080), Time.deltaTime * 3);
                LangBackground.fillAmount -= 0.5f * Time.deltaTime;
                if (LangRect.sizeDelta.x < barClose + 10)
                {
                    if (navibarstate == NavibarState.Close && etcbarstate == EtcBarState.Close)
                    {
                        if (!(ContentsName == "NamsanH" || ContentsName == "Dora" || ContentsName == "EndIsland"))
                        {
                            if (!SceneManager.GetActiveScene().name.Contains("VisitMode"))
                            {
                                Arrow.SetActive(true);
                            }
                        }
                    }
                    if (see360.obj360.transform.parent.gameObject.activeSelf)
                    {
                        Arrow.SetActive(false);
                    }
                    LangRect.sizeDelta = new Vector2(barClose + 5f, 1080);
                    modeonoff.LanguageMode.transform.GetChild(0).gameObject.SetActive(false);
                    langbarstate = LangBarState.Close;
                }
            }
        }
    }

    public void EtcArr_set()
    {
        if (EtcRect == null)
        {
            EtcRect = EtcBar.GetComponent<RectTransform>();
        }
        if (etcbarstate == EtcBarState.Opening)
        {
            Arrow.SetActive(false);
            if (EtcRect.sizeDelta.x < barOpen)
            {
                EtcRect.sizeDelta = Vector2.Lerp(EtcRect.sizeDelta, new Vector2(barOpen + 5f, 1080), Time.deltaTime * 5);
                EtcBackground.fillAmount += 0.5f * Time.deltaTime;
                if (EtcRect.sizeDelta.x > barOpen - 5)
                {
                    EtcRect.sizeDelta = new Vector2(barOpen + 5f, 1080);
                    etcbarstate = EtcBarState.Open;
                }
            }
        }
        else if (etcbarstate == EtcBarState.Closing)
        {
            if (EtcRect.sizeDelta.x > barClose)
            {
                EtcRect.sizeDelta = Vector2.Lerp(EtcRect.sizeDelta, new Vector2(barClose - 5f, 1080), Time.deltaTime * 3);
                EtcBackground.fillAmount -= 0.5f * Time.deltaTime;
                if (EtcRect.sizeDelta.x < barClose + 10)
                {
                    if (navibarstate == NavibarState.Close && langbarstate == LangBarState.Close)
                    {
                        if (!(ContentsName == "NamsanH" || ContentsName == "Dora" || ContentsName == "EndIsland"))
                        {
                            if (!SceneManager.GetActiveScene().name.Contains("VisitMode"))
                            {
                                Arrow.SetActive(true);
                            }
                        }
                    }
                    if (see360.obj360.transform.parent.gameObject.activeSelf)
                    {
                        Arrow.SetActive(false);
                    }
                    EtcRect.sizeDelta = new Vector2(barClose + 5f, 1080);
                    modeonoff.EtcMode.transform.GetChild(0).gameObject.SetActive(false);
                    etcbarstate = EtcBarState.Close;
                }
            }
        }
    }

    public void ButtonClickSound()
    {

    }

    public void MinimapMoveStart()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            clearMode.minimapbuttonstate = ClearMode.MiniMapButtonState.Click;
        }
    }

    public void MinimapMoveEnd()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            clearMode.minimapbuttonstate = ClearMode.MiniMapButtonState.None;
        }
    }

    public void OnClickLabelBtn(GameObject obj)
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            int index = -1;
            for (int i = 0; i < clearMode.AllMapLabels.transform.childCount; i++)
            {
                if (obj.name == clearMode.AllMapLabels.transform.GetChild(i).gameObject.name)
                {
                    index = i;
                    break;
                }
            }
            clearMode.OnClcikLabelBtn(clearMode.AllMapLabels.transform.GetChild(index).gameObject);
        }
        else if (SceneManager.GetActiveScene().name.Contains("NamsanHMode"))
        {
            namsanhmode.Merry.SetActive(false);
            namsanhmode.NaviLabel(obj);
            navibarstate = NavibarState.Closing;
        }
    }

    public void ChangeLangage(GameObject obj)
    {
        switch (obj.name)
        {
            case "Korea":
                langstate = LangState.Korea;
                break;
            case "English":
                langstate = LangState.English;
                break;
            case "Chinese":
                langstate = LangState.Chienses;
                break;
            case "Japanese":
                langstate = LangState.Japan;
                break;
        }
        ChangeLang(langstate);
        if (ContentsName == "Aegibong" || ContentsName == "Apsan")
        {
            GetComponent<LabelMake>().MapLabel();
        }
        else if (ContentsName == "EndIsland")
        {
            if (endisland_tour.ClickObj != null)
            {
                tourismode.SelectLabel(endisland_tour.ClickObj.name);
            }
        }
        langbarstate = LangBarState.Closing;
    }

    public void ChangeLang(LangState Lang)
    {
        for (int i = 0; i < NaviLabelList.Count; i++)
        {
            Destroy(NaviLabelList[i].gameObject);
        }
        NaviLabelList.Clear();

        switch (Lang)
        {
            case LangState.Korea:
                for (int i = 0; i < Label_total.Count; i++)
                {
                    LabelData(Label_total[i], NaviLabel_K[i], i, i);
                }
                NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_total.Count) + 27 * (Label_total.Count));
                break;
            case LangState.English:
                for (int i = 0; i < Label_total.Count; i++)
                {
                    LabelData(Label_total[i], NaviLabel_E[i], i, i);
                }
                NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_total.Count) + 27 * (Label_total.Count));
                break;
            case LangState.Chienses:
                for (int i = 0; i < Label_total.Count; i++)
                {
                    LabelData(Label_total[i], NaviLabel_C[i], i, i);
                }
                NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_total.Count) + 27 * (Label_total.Count));
                break;
            case LangState.Japan:
                for (int i = 0; i < Label_total.Count; i++)
                {
                    LabelData(Label_total[i], NaviLabel_J[i], i, i);
                }
                NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_total.Count) + 27 * (Label_total.Count));
                break;
        }
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            clearMode.labeldetailstate = ClearMode.LabelDetailState.Closing;
        }
        else if (SceneManager.GetActiveScene().name.Contains("NamsanH"))
        {
            namsanhmode.OnClickHomeBtn();
        }

        if (Contentsinfo.ContentsName == "Apsan" || ContentsName == "Aegibong")
        {
            //switch(Lang)
            //{
            //    case LangState.Korea:
            //        for (int i = 0; i < clearMode.AllMapLabels.transform.childCount; i++)
            //        {
            //            clearMode.AllMapLabels.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = LabelName_K[i];
            //        }
            //        break;
            //    case LangState.English:
            //        for (int i = 0; i < clearMode.AllMapLabels.transform.childCount; i++)
            //        {
            //            clearMode.AllMapLabels.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = LabelName_E[i];
            //        }
            //        break;
            //    case LangState.Chienses:
            //        for (int i = 0; i < clearMode.AllMapLabels.transform.childCount; i++)
            //        {
            //            clearMode.AllMapLabels.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = LabelName_C[i];
            //        }
            //        break;
            //    case LangState.Japan:
            //        for (int i = 0; i < clearMode.AllMapLabels.transform.childCount; i++)
            //        {
            //            clearMode.AllMapLabels.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Text>().text = LabelName_J[i];
            //        }
            //        break;
            //}
            //GetComponent<LabelMake>().ReadytoStart();
            //GetComponent<LabelMake>().MapLabel();
        }
    }

    public void OnCLickCategoryBtn(GameObject obj)
    {
        GetComponent<LabelMake>().Navilabel_Icon.Clear();
        GetComponent<LabelMake>().Navilabel_Text.Clear();
        for (int i = 0; i < obj.transform.parent.childCount; i++)
        {
            if (obj.transform.parent.GetChild(i).name == obj.name)
            {
                obj.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                obj.transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);
            }
        }
        switch (obj.name)
        {
            case "Total":
                ChangeLang(langstate);
                break;
            case "Eco":
                for (int i = 0; i < NaviLabelList.Count; i++)
                {
                    Destroy(NaviLabelList[i].gameObject);
                }
                NaviLabelList.Clear();
                switch (langstate)
                {
                    case LangState.Korea:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_1.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_1[k])
                                {
                                    LabelData(Label_Cate_1[k], NaviLabel_K[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_1.Count) + 27 * (Label_Cate_1.Count));
                        break;
                    case LangState.English:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_1.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_1[k])
                                {
                                    LabelData(Label_Cate_1[k], NaviLabel_E[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_1.Count) + 27 * (Label_Cate_1.Count));
                        break;
                    case LangState.Chienses:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_1.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_1[k])
                                {
                                    LabelData(Label_Cate_1[k], NaviLabel_C[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_1.Count) + 27 * (Label_Cate_1.Count));
                        break;
                    case LangState.Japan:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_1.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_1[k])
                                {
                                    LabelData(Label_Cate_1[k], NaviLabel_J[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_1.Count) + 27 * (Label_Cate_1.Count));
                        break;
                }
                break;
            case "Building":
                for (int i = 0; i < NaviLabelList.Count; i++)
                {
                    Destroy(NaviLabelList[i].gameObject);
                }
                NaviLabelList.Clear();
                switch (langstate)
                {
                    case LangState.Korea:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_2.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_2[k])
                                {
                                    LabelData(Label_Cate_2[k], NaviLabel_K[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_2.Count) + 27 * (Label_Cate_2.Count));
                        break;
                    case LangState.English:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_2.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_2[k])
                                {
                                    LabelData(Label_Cate_2[k], NaviLabel_E[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_2.Count) + 27 * (Label_Cate_2.Count));
                        break;
                    case LangState.Chienses:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_2.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_2[k])
                                {
                                    LabelData(Label_Cate_2[k], NaviLabel_C[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_2.Count) + 27 * (Label_Cate_2.Count));
                        break;
                    case LangState.Japan:
                        for (int i = 0; i < Label_total.Count; i++)
                        {
                            for (int k = 0; k < Label_Cate_2.Count; k++)
                            {
                                if (Label_total[i] == Label_Cate_2[k])
                                {
                                    LabelData(Label_Cate_2[k], NaviLabel_J[i], k, i);
                                }
                            }
                        }
                        NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_Cate_2.Count) + 27 * (Label_Cate_2.Count));
                        break;
                }
                break;

        }

    }

    public void OnClickHomeBtn()
    {
        langbarstate = LangBarState.Closing;
        navibarstate = NavibarState.Closing;
        etcbarstate = EtcBarState.Closing;

        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }

        if (guidevideo.transform.parent.gameObject.activeSelf)
        {
            guidevideo.OnClickYes();
        }
        else
        {
            Tip_Obj.gameObject.SetActive(true);
        }


        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            clearMode.OnClickHomeBtn();
            modeonoff.ClearMode.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name.Contains("VisitMode"))
        {
            Tip_Obj.gameObject.SetActive(false);
            visitmanager.OnClickHomeBtn();
        }
        else if (SceneManager.GetActiveScene().name.Contains("NamsanHMode"))
        {
            namsanhmode.OnClickHomeBtn();
        }
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public void OnClickLotte()
    {
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "Lotte";
        TelescopeInfo(ContentsName);
        GetComponent<ReadJsonFile>().Readfile();
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
        Loading.nextScene = "ClearModeLotte";
        SceneManager.LoadSceneAsync("Loading");
    }

    public void OnClickBEXCO()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "BEXCO";
        TelescopeInfo(ContentsName);
        GetComponent<ReadJsonFile>().Readfile();
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
        Loading.nextScene = "ClearModeBEXCO";
        SceneManager.LoadSceneAsync("Loading");
    }

    public void OnClickHigh1()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "High1";
        TelescopeInfo(ContentsName);
        GetComponent<ReadJsonFile>().Readfile();
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
        Loading.nextScene = "ClearModeHigh1";
        SceneManager.LoadSceneAsync("Loading");
    }

    public void OnClickOdu()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        if (startstate == StartState.Lotte)
        {
            langbarstate = LangBarState.Closing;
            etcbarstate = EtcBarState.Closing;
            navibarstate = NavibarState.Closing;
            ResetList();
            ContentsName = "Odu";
            TelescopeInfo(ContentsName);
            GetComponent<ReadJsonFile>().Readfile();
            Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
            Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
            Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
            Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
            Loading.nextScene = "ClearModeOdu";
            SceneManager.LoadSceneAsync("Loading");
        }
        else if (startstate == StartState.Odu)
        {
            langbarstate = LangBarState.Closing;
            etcbarstate = EtcBarState.Closing;
            navibarstate = NavibarState.Closing;
            ResetList();
            ContentsName = "Odu";
            TelescopeInfo(ContentsName);
            GetComponent<ReadJsonFile>().Readfile();
            Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
            Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
            Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
            Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
            Loading.nextScene = "XRMode";
            SceneManager.LoadSceneAsync("Loading");
        }
    }

    public void OnCLickApsan()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "Apsan";
        Loading.nextScene = "ClearModeApsan";
        SceneManager.LoadSceneAsync("Loading");
        GetComponent<ReadJsonFile>().Readfile();
        TelescopeInfo(ContentsName);
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
    }

    public void OnCLickAegibong()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "Aegibong";
        Loading.nextScene = "ClearModeAegibong";
        SceneManager.LoadSceneAsync("Loading");
        GetComponent<ReadJsonFile>().Readfile();
        TelescopeInfo(ContentsName);
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
    }

    public void OnCLickEndisland()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "EndIsland";
        Loading.nextScene = "TourismMode_EndIsland";
        SceneManager.LoadSceneAsync("Loading");
        GetComponent<ReadJsonFile>().Readfile();
        TelescopeInfo(ContentsName);
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
    }

    public void OnCLickGoldSunset()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "GoldSunset";
        Loading.nextScene = "TourismMode_GoldSunset";
        SceneManager.LoadSceneAsync("Loading");
        GetComponent<ReadJsonFile>().Readfile();
        TelescopeInfo(ContentsName);
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
    }

    public void OnClickNamsnaH()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "NamsanH";
        Loading.nextScene = "NamsanHMode";
        SceneManager.LoadSceneAsync("Loading");
        GetComponent<ReadJsonFile>().Readfile();
        TelescopeInfo(ContentsName);
        Tip_Obj.GetComponent<Langague>().sp[0] = Tip_K;
        Tip_Obj.GetComponent<Langague>().sp[1] = Tip_E;
        Tip_Obj.GetComponent<Langague>().sp[2] = Tip_C;
        Tip_Obj.GetComponent<Langague>().sp[3] = Tip_J;
    }

    public void OnClickDora()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "Dora";
        Loading.nextScene = "CultureMode_Dora";
        SceneManager.LoadSceneAsync("Loading");
    }

    public void OnClickSpace()
    {
        if (see360.obj360.transform.parent.gameObject.activeSelf)
        {
            see360.Close360();
        }
        langbarstate = LangBarState.Closing;
        etcbarstate = EtcBarState.Closing;
        navibarstate = NavibarState.Closing;
        ResetList();
        ContentsName = "Space";
        Loading.nextScene = "Space";
        SceneManager.LoadSceneAsync("Loading");
    }


    public Vector3 originPos;
    public void SetMark()
    {
        GameObject markcustom = screencapture.customMark;

        markcustom.transform.GetChild(0).gameObject.GetComponent<Text>().text = DateTime.Now.ToString("yyyy.MM.dd HH:mm");

        originPos = markcustom.transform.localPosition;
        markcustom.SetActive(true);
        BackGround.SetActive(true);
        if (SceneManager.GetActiveScene().name == "ClearMode")
        {
            markcustom.transform.localPosition = Vector3.zero;
            markcustom.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void FlashEffect()
    {
        screencapture.flasheffect.SetActive(true);
        screencapture.flasheffect.GetComponent<Image>().color = screencapture.flashColor;
        Invoke("OffFlashEffect", 1f);
    }

    public void OffFlashEffect()
    {
        screencapture.flasheffect.SetActive(false);
        screencapture.customMark.SetActive(false);
        screencapture.customMark.transform.parent = screencapture.transform;
        screencapture.customMark.transform.localPosition = originPos;
        originPos = Vector3.zero;

    }

    public void OnClickCaptureBtn()
    {
        navibarstate = NavibarState.Closing;
        etcbarstate = EtcBarState.Closing;
        langbarstate = LangBarState.Closing;
        ErrorMessage.SetActive(true);
    }

    public void OnClickSelfiBtn()
    {
        navibarstate = NavibarState.Closing;
        etcbarstate = EtcBarState.Closing;
        langbarstate = LangBarState.Closing;
        ErrorMessage.SetActive(true);
    }

    public void CaptureSelfiCamera()
    {
        ErrorMessage.SetActive(true);
    }


    int ManagerCount = 0;
    public void OnclickManagerBtn()
    {
        ManagerCount++;
        if (ManagerCount == 3)
        {
            ManagerCount = 0;
            if (Manager.activeSelf)
            {
                Manager.SetActive(false);
            }
            else
            {
                Manager.SetActive(true);
            }
        }
        else
        {
            Invoke("ManagerCount0", 1.5f);
        }
    }

    void ManagerCount0()
    {
        ManagerCount = 0;
    }
}
