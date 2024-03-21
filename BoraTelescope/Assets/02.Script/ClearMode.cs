using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ClearMode : MonoBehaviour
{



    public enum LabelMoveState
    {
        None,
        Move,
    }
    public LabelMoveState labelmovestate = 0;

    public enum LabelDetailState
    {
        Close,
        Open,
        Closing,
        Opening,
    }
    public LabelDetailState labeldetailstate = 0;

    public enum MiniMapButtonState
    {
        None,
        Click,
    }
    public MiniMapButtonState minimapbuttonstate = 0;


    public GameManager gamemanager;
    GameObject ClickLabel;
    [SerializeField]
    ExplainMode explainmode;
    public GameObject AllMapLabels;
    public GameObject Label360;
    private float zoom_int = 1.0f;
    public static float zoommove_t;
    public static float MaxZoomIn = 1851;
    public static float MaxZoomOut = -3369;
    public int touchcount_int;
    public Image TestImage;
    float StartZoom = 956;
    Vector3 changeZoom;
    private float full_x;
    private float full_y;
    public float min_x;
    public float min_y;
    public float max_x;
    public float max_y;
    public float min_x360;
    public float min_y360;
    public float max_x360;
    public float max_y360;
    private float ZoomOut_min_x;
    private float ZoomOut_min_y;
    private float ZoomOut_max_x;
    private float ZoomOut_max_y;
    private float cameraout_x;
    private float cameraout_y;
    public static float MinLabelSize = 1.0f;
    public static float MaxLabelSize = 5.5f;
    public static float Cameraz = -1631;

    float bx;
    float by;
    float fx;
    float fy;
    string dir;
    float value;
    Vector3 beforepos;
    public float MinZoomValue;
    public float MaxZoomValue;

    public DisableLabel disablelabel;
    [SerializeField]
    public GameObject Main;
    [SerializeField]
    GameObject DetailImage_Background;
    [SerializeField]
    Image DetailImage;
    [SerializeField]
    UIText DetailText;
    [SerializeField]
    Text DetailTitleText;
    [SerializeField]
    Text DetailSubTitleText;
    [SerializeField]
    RectTransform DetailTextContent;
    [SerializeField]
    GameObject MiniMap360;
    [SerializeField]
    GameObject Btn_Explain;
    [SerializeField]
    GameObject Btn_WebView;
    [SerializeField]
    GameObject Btn_DetailSound;
    public Spoonbill spoonbill;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gamemanager.clearMode = this;
        gamemanager.ad = GetComponent<AudioSource>();
        gamemanager.NavigationBar.SetActive(true);
        gamemanager.UI_All.SetActive(true);
        gamemanager.pinchzoom.ZoomValue.gameObject.SetActive(false);
        gamemanager.MiniMap_Background.gameObject.SetActive(true);
        gamemanager.modeonoff.NamsanHout();

        for (int i = 0; i < gamemanager.LanguageBar.GetComponent<LangageObj>().LangList.Count; i++)
        {
            gamemanager.LanguageBar.GetComponent<LangageObj>().LangList[i].SetActive(true);
        }

        switch (Contentsinfo.ContentsName)
        {
            case "Lotte":
                MaxZoomIn = 1851;
                MaxZoomOut = -3369;
                MinZoomValue = 1;
                MaxZoomValue = 0.035f;
                Main.transform.parent.transform.localPosition = new Vector3(0, 0, 956);
                Main.transform.localPosition = new Vector3(-19435, 5115, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 1560;
                break;
            case "BEXCO":
                MaxZoomIn = 1851;
                MaxZoomOut = 1;
                MinZoomValue = 1;
                MaxZoomValue = 0.035f;
                Main.transform.localPosition = new Vector3(-1501, 1834, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                gamemanager.LanguageBar.GetComponent<LangageObj>().Chi.SetActive(false);
                gamemanager.LanguageBar.GetComponent<LangageObj>().Jap.SetActive(false);
                break;
            case "High1":
                MaxZoomIn = 1851;
                MaxZoomOut = 1;
                MinZoomValue = 1;
                MaxZoomValue = 0.035f;
                Main.transform.localPosition = new Vector3(7853, 4099, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                gamemanager.LanguageBar.GetComponent<LangageObj>().Chi.SetActive(false);
                gamemanager.LanguageBar.GetComponent<LangageObj>().Jap.SetActive(false);
                break;
            case "Odu":
                MaxZoomIn = 1851;
                MaxZoomOut = 1;
                MinZoomValue = 1;
                MaxZoomValue = 0.035f;
                Main.transform.localPosition = new Vector3(20204, 122, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                break;
            case "Apsan":
                MaxZoomIn = 1851;
                MaxZoomOut = -3369;
                MinZoomValue = 1;
                MaxZoomValue = 0.035f;
                gamemanager.GetComponent<LabelMake>().ReadytoStart();
                gamemanager.GetComponent<LabelMake>().MapLabel();
                Main.transform.localPosition = new Vector3(-8407, -870, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                //ClearMode.LabelMaxZoomIn = 970;
                //ClearMode.MinLabelSize = 1.0f;
                //ClearMode.MaxLabelSize = 5.5f;
                break;
            case "Aegibong":
                MaxZoomIn = 1851;
                MaxZoomOut = -100;
                MinZoomValue = 1;
                MaxZoomValue = 0.035f;
                gamemanager.GetComponent<LabelMake>().ReadytoStart();
                gamemanager.GetComponent<LabelMake>().MapLabel();
                Main.transform.localPosition = new Vector3(-1705, -2744, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2316;
                //ClearMode.LabelMaxZoomIn = 970;
                //ClearMode.MinLabelSize = 1.0f;
                //ClearMode.MaxLabelSize = 5.5f;
                break;
        }
        gamemanager.modeonoff.Reset();
        gamemanager.modeonoff.ClearMode.transform.GetChild(0).gameObject.SetActive(true);
        gamemanager.Tip_Obj.SetActive(true);
        gamemanager.modeonoff.TipMode.transform.GetChild(0).gameObject.SetActive(true);
        gamemanager.navibarstate = GameManager.NavibarState.Opening;

        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                GameObject kobj = new GameObject();
                kobj.name = "Korea";
                gamemanager.ChangeLangage(kobj);
                Destroy(kobj);
                break;
            case GameManager.LangState.English:
                GameObject eobj = new GameObject();
                eobj.name = "English";
                gamemanager.ChangeLangage(eobj);
                Destroy(eobj);
                break;
            case GameManager.LangState.Chienses:
                if (Contentsinfo.ContentsName == "BEXCO" || Contentsinfo.ContentsName == "High1")
                {
                    GameObject obj = new GameObject();
                    obj.name = "Korea";
                    gamemanager.ChangeLangage(obj);
                    Destroy(obj);
                }
                else
                {
                    GameObject cobj = new GameObject();
                    cobj.name = "Chienses";
                    gamemanager.ChangeLangage(cobj);
                    Destroy(cobj);
                }
                break;
            case GameManager.LangState.Japan:
                if (Contentsinfo.ContentsName == "BEXCO" || Contentsinfo.ContentsName == "High1")
                {
                    GameObject obj = new GameObject();
                    obj.name = "Korea";
                    gamemanager.ChangeLangage(obj);
                    Destroy(obj);
                }
                else
                {
                    GameObject jobj = new GameObject();
                    jobj.name = "Japan";
                    gamemanager.ChangeLangage(jobj);
                    Destroy(jobj);
                }
                break;
        }

        value = (gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - (MaxZoomOut)) / ((MaxZoomIn - MaxZoomOut) / 100);
        value = 100 - value;
        for (int i = 0; i < gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
        {
            gamemanager.clearMode.AllMapLabels.transform.GetChild(i).localScale = new Vector3(MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value));
        }

        if (SceneManager.GetActiveScene().name.Contains("Aegibong"))
        {
            for (int i = 0; i < disablelabel.HiddenObj_s.Length; i++)
            {
                disablelabel.HiddenObj_s[i].transform.localScale = new Vector3(MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        zoommove_t += Time.deltaTime * 4;
        zoom_int = ((Main.transform.parent.gameObject.transform.position.z - MaxZoomIn) / -522) + 1.2f;

        if (touchcount_int == 0 || touchcount_int == 1)
        {
            touchcount_int = Input.touchCount;
        }
        else
        {
            try
            {
                if (Input.touches[0].phase == TouchPhase.Ended && Input.touches[1].phase == TouchPhase.Ended)
                {
                    touchcount_int = 0;
                }
            }
            catch
            {
                touchcount_int = 0;
            }
        }

        CameraRange();
        LabelMove();
        LabelDetail();
        if (Input.touchCount == 1 && gamemanager.UI_All.activeSelf)
        {
            float y = 0;
            float x = Input.GetTouch(0).position.x;
            float Xvalue = 0;
            float Xvalue2 = 3000;
            if (gamemanager.navibarstate == GameManager.NavibarState.Open || gamemanager.navibarstate == GameManager.NavibarState.Opening || gamemanager.langbarstate == GameManager.LangBarState.Open || gamemanager.langbarstate == GameManager.LangBarState.Opening || gamemanager.etcbarstate == GameManager.EtcBarState.Open || gamemanager.etcbarstate == GameManager.EtcBarState.Opening)
            {
                Xvalue = 500;
            }

            if (gamemanager.clearMode.labeldetailstate == ClearMode.LabelDetailState.Open || gamemanager.clearMode.labeldetailstate == ClearMode.LabelDetailState.Opening)
            {
                Xvalue2 = 1400;
            }

            if (x < 500)
            {
                y = 400;
            }
            else
            {
                y = 120;
            }

            if (Input.GetTouch(0).position.y > y && Input.GetTouch(0).position.x > Xvalue && Input.GetTouch(0).position.x < Xvalue2)
            {
                ClearModeMove();
            }
        }
        MiniMap();

        if (SceneManager.GetActiveScene().name.Contains("Lotte"))
        {
            if (Clear360Obj.activeSelf)
            {
                min_x360 = -36790.24f;
                max_x360 = 77640;
                max_y360 = -(Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize - 5885) + 7096;
                min_y360 = (Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize - 5885) - 1050;

                if (Main.transform.position.y > min_y360 && Main.transform.position.y < max_y360)
                {
                    if (Main.transform.position.x - 2 <= min_x360)
                    {
                        Main.transform.position = new Vector3(60641.84f, Main.transform.position.y, Main.transform.position.z);
                    }
                    else if (Main.transform.position.x + 2 >= max_x360)
                    {
                        Main.transform.position = new Vector3(-19771.31f, Main.transform.position.y, Main.transform.position.z);
                    }
                }
            }
        }
    }

    public void MiniMap()
    {
        if (minimapbuttonstate == MiniMapButtonState.None)
        {
            float value = (Main.transform.localPosition.x - min_x) / (max_x - min_x);
            gamemanager.MiniMap_Camera.transform.localPosition = new Vector3((800 * value) - 400, 0, 0);
        }
        else if (minimapbuttonstate == MiniMapButtonState.Click)
        {
            if (Input.touchCount == 1)
            {
                float xvalue = Input.GetTouch(0).position.x - 1000;
                xvalue = Mathf.Clamp(xvalue, -400, 400);
                gamemanager.MiniMap_Camera.transform.localPosition = new Vector3(xvalue, gamemanager.MiniMap_Camera.transform.localPosition.y, gamemanager.MiniMap_Camera.transform.localPosition.z);
                float value = (gamemanager.MiniMap_Camera.transform.localPosition.x + 400) / 8;
                Main.transform.localPosition = new Vector3(min_x + (((max_x - min_x) / 100) * value), Main.transform.localPosition.y, Main.transform.localPosition.z);
            }
        }
    }

    public void ClearModeMove()
    {
        if (touchcount_int == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                labeldetailstate = LabelDetailState.Closing;
                labelmovestate = LabelMoveState.None;
                beforepos = Input.mousePosition;
                bx = beforepos.x;
                by = beforepos.y;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                fx = (bx - Input.mousePosition.x) * zoom_int;
                fy = (by - Input.mousePosition.y) * zoom_int;
                beforepos = Input.mousePosition;
                bx = beforepos.x;
                by = beforepos.y;
                touchmovecamera();
            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                bx = 0;
                by = 0;
                beforepos = Vector3.zero;
            }
        }
        else if (touchcount_int == 2)
        {
            PinchZoom();
        }
    }

    public void touchmovecamera()
    {
        if (SceneManager.GetActiveScene().name.Contains("Lotte"))
        {
            if (Clear120Obj.activeSelf)
            {
                Main.transform.position = new Vector3(Main.transform.position.x + fx, Main.transform.position.y + fy, Main.transform.position.z);
                Main.transform.position = new Vector3(Mathf.Clamp(Main.transform.position.x, min_x, max_x), Mathf.Clamp(Main.transform.position.y, min_y, max_y), Main.transform.position.z);
            }
            else if (Clear360Obj.activeSelf)
            {
                Main.transform.position = new Vector3(Main.transform.position.x + fx, Main.transform.position.y + fy, Main.transform.position.z);
                Main.transform.position = new Vector3(Mathf.Clamp(Main.transform.position.x, min_x360, max_x360), Mathf.Clamp(Main.transform.position.y, min_y360, max_y360), Main.transform.position.z);
            }
        }
        else
        {
            Main.transform.position = new Vector3(Main.transform.position.x + fx, Main.transform.position.y + fy, Main.transform.position.z);
            Main.transform.position = new Vector3(Mathf.Clamp(Main.transform.position.x, min_x, max_x), Mathf.Clamp(Main.transform.position.y, min_y, max_y), Main.transform.position.z);
        }
    }

    public void PinchZoom()
    {

    }

    public void CameraRange()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            //����ī�޶� �Ӱ�������
            full_x = (int)TestImage.rectTransform.rect.width;
            full_y = (int)TestImage.rectTransform.rect.height;

            cameraout_x = TestImage.transform.parent.gameObject.GetComponent<SetWidth>().CameraWidth / 2;
            cameraout_y = (TestImage.transform.parent.gameObject.GetComponent<SetWidth>().CameraWidth * 1080 / 1920) / 2;

            min_x = -full_x / 2 + TestImage.transform.position.x + cameraout_x;
            max_x = full_x / 2 + TestImage.transform.position.x - cameraout_x;
            min_y = -full_y / 2 + TestImage.transform.position.y + cameraout_y;
            max_y = full_y / 2 + TestImage.transform.position.y - cameraout_y;

            if (cameraout_x != 0 && cameraout_y != 0)
            {
                if (ZoomOut_min_x == 0)
                {
                    ZoomOut_min_x = min_x;
                    ZoomOut_min_y = min_y;
                    ZoomOut_max_x = max_x;
                    ZoomOut_max_y = max_y;
                }
            }
            else
            {
                ZoomOut_min_x = 0;
                ZoomOut_min_y = 0;
                ZoomOut_max_x = 0;
                ZoomOut_max_y = 0;
            }
        }
    }

    void LabelMove()
    {
        if (labelmovestate == LabelMoveState.Move)
        {
            if (ClickLabel != null)
            {
                SetchangeZoom(ClickLabel.name);
                Main.transform.parent.localPosition = Vector3.Lerp(Main.transform.parent.localPosition, changeZoom, Time.deltaTime * 4);
                gamemanager.clearMode.MoveZoomOut();
                value = (gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - (MaxZoomOut)) / ((MaxZoomIn - MaxZoomOut) / 100);
                value = 100 - value;
                for (int i = 0; i < gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
                {
                    gamemanager.clearMode.AllMapLabels.transform.GetChild(i).localScale = new Vector3(MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value));
                }

                if (SceneManager.GetActiveScene().name.Contains("Aegibong"))
                {
                    for (int i = 0; i < disablelabel.HiddenObj_s.Length; i++)
                    {
                        disablelabel.HiddenObj_s[i].transform.localScale = new Vector3(MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value));
                    }
                }

                float x = ClickLabel.transform.position.x;
                float y = ClickLabel.transform.position.y;
                Main.transform.position = Vector3.Lerp(Main.transform.position, new Vector3(x, y, Main.transform.position.z), Time.deltaTime * 4);
                if (Math.Abs(x - Main.transform.position.x) < 1 && Math.Abs(y - Main.transform.position.y) < 1 && Math.Abs(Main.transform.parent.localPosition.z - changeZoom.z) < 10)
                {
                    labelmovestate = LabelMoveState.None;
                    if (ClickLabel.name != "https://search.naver.com/search.naver?where=nexearch&sm=top_hty&fbm=1&ie=utf8&query=%EA%B3%A0%EB%93%A0%EB%9E%A8%EC%A7%80%EB%B2%84%EA%B1%B0+%ED%98%84%EB%8C%80%EB%B0%B1%ED%99%94%EC%A0%90")
                    {
                        LabelDetailSetting();
                        labeldetailstate = LabelDetailState.Opening;
                    }
                }
            }
        }
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
                    labeldetailstate = LabelDetailState.Open;
                }
                break;
            case LabelDetailState.Closing:
                if (gamemanager.ad.isPlaying)
                {
                    gamemanager.ad.Stop();
                }
                if (Contentsinfo.ContentsName == "Lotte")
                {
                    for (int i = 0; i < explainmode.obj.Length; i++)
                    {
                        if (explainmode.obj[i].activeSelf)
                        {
                            explainmode.obj[i].SetActive(false);
                            explainmode.DragWebviewEnd();
                        }
                    }
                }
                DetailImage_Background.transform.localPosition = new Vector3(Mathf.Lerp(DetailImage_Background.transform.localPosition.x, 1218, Time.deltaTime * 2), 393.5f, 0);
                if (Math.Abs(DetailImage_Background.transform.localPosition.x - 1218) < 5)
                {
                    DetailImage_Background.transform.localPosition = new Vector3(1218, 393.5f, 0);
                    labeldetailstate = LabelDetailState.Close;
                }
                break;
        }
    }

    public void LabelDetailSetting()
    {
        Btn_DetailSound.transform.gameObject.SetActive(true);
        int index = -1;
        for (int i = 0; i < AllMapLabels.transform.childCount; i++)
        {
            if (ClickLabel.name == AllMapLabels.transform.GetChild(i).gameObject.name)
            {
                index = i;
                break;
            }
        }

        if (Contentsinfo.ContentsName == "Odu")
        {
            switch (GameManager.langstate)
            {
                case GameManager.LangState.Korea:
                    DetailImage.sprite = gamemanager.DetailImage_K[index];
                    DetailText.text = gamemanager.DetailText_K[index];
                    DetailTitleText.text = gamemanager.LabelName_K[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_K[index];
                    break;
                case GameManager.LangState.English:
                    DetailImage.sprite = gamemanager.DetailImage_K[index];
                    DetailText.text = gamemanager.DetailText_E[index];
                    DetailTitleText.text = gamemanager.LabelName_E[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_E[index];
                    break;
                case GameManager.LangState.Chienses:
                    DetailImage.sprite = gamemanager.DetailImage_C[index];
                    DetailText.text = gamemanager.DetailText_C[index];
                    DetailTitleText.text = gamemanager.LabelName_C[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_C[index];
                    break;
                case GameManager.LangState.Japan:
                    DetailImage.sprite = gamemanager.DetailImage_J[index];
                    DetailText.text = gamemanager.DetailText_J[index];
                    DetailTitleText.text = gamemanager.LabelName_J[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_J[index];
                    break;
            }
        }
        else
        {
            switch (GameManager.langstate)
            {
                case GameManager.LangState.Korea:
                    DetailImage.sprite = gamemanager.DetailImage_K[index];
                    DetailText.text = gamemanager.DetailText_K[index];
                    DetailTitleText.text = gamemanager.LabelName_K[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_K[index];
                    break;
                case GameManager.LangState.English:
                    DetailImage.sprite = gamemanager.DetailImage_K[index];
                    DetailText.text = gamemanager.DetailText_E[index];
                    DetailTitleText.text = gamemanager.LabelName_E[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_E[index];
                    break;
                case GameManager.LangState.Chienses:
                    DetailImage.sprite = gamemanager.DetailImage_K[index];
                    DetailText.text = gamemanager.DetailText_C[index];
                    DetailTitleText.text = gamemanager.LabelName_C[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_C[index];
                    break;
                case GameManager.LangState.Japan:
                    DetailImage.sprite = gamemanager.DetailImage_K[index];
                    DetailText.text = gamemanager.DetailText_J[index];
                    DetailTitleText.text = gamemanager.LabelName_J[index];
                    DetailSubTitleText.text = gamemanager.LabelName_E[index];
                    gamemanager.ad.clip = gamemanager.Narration_J[index];
                    break;
            }
        }

        if (ClickLabel.name == "Spoonbill")
        {
            spoonbill.SelectSpoonbill();
        }

        /*
        if(ClickLabel.name == "Gijeong")
        {
            DetailImage.transform.GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(0).GetComponent<DetailVideo>().NorthKoreanFlag;
            DetailImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (ClickLabel.name == "Daeseoung")
        {
            DetailImage.transform.GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(0).GetComponent<DetailVideo>().SouthKoreanFlag;
            DetailImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else*/
        if (ClickLabel.name == "Banpo")
        {
            DetailImage.transform.GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(0).GetComponent<DetailVideo>().Banpo;
            DetailImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (ClickLabel.name == "NTower")
        {
            DetailImage.transform.GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(0).GetComponent<DetailVideo>().NTower;
            DetailImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (ClickLabel.name == "Daeseoung")
        {
            DetailImage.transform.GetChild(5).GetChild(1).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(5).GetComponent<DetailVideo>().SouthKoreanFlag;
            DetailImage.transform.GetChild(5).gameObject.SetActive(true);
            DetailImage.transform.GetChild(5).GetChild(1).gameObject.SetActive(true);
            DetailImage.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        }
        else if (ClickLabel.name == "Gijeong")
        {
            DetailImage.transform.GetChild(5).GetChild(1).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(5).GetComponent<DetailVideo>().NorthKoreanFlag;
            DetailImage.transform.GetChild(5).gameObject.SetActive(true);
            DetailImage.transform.GetChild(5).GetChild(1).gameObject.SetActive(true);
            DetailImage.transform.GetChild(5).GetChild(0).gameObject.SetActive(false);
        }
        else if (ClickLabel.name == "Gwansan")
        {
            DetailImage.transform.GetChild(5).GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(5).GetComponent<DetailVideo>().GawnSan;
            DetailImage.transform.GetChild(5).gameObject.SetActive(true);
            DetailImage.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
            DetailImage.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
        }
        else if (ClickLabel.name == "Gijungdong")
        {
            DetailImage.transform.GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(0).GetComponent<DetailVideo>().NorthKoreanFlag;
            DetailImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (ClickLabel.name == "Daesungdong")
        {
            DetailImage.transform.GetChild(0).GetComponent<VideoPlayer>().clip = DetailImage.transform.GetChild(0).GetComponent<DetailVideo>().SouthKoreanFlag;
            DetailImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name.Contains("Aegibong") || SceneManager.GetActiveScene().name.Contains("Lotte") || SceneManager.GetActiveScene().name.Contains("XRMode"))
        {
            DetailImage.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name.Contains("Odu"))

        {
            DetailImage.transform.GetChild(5).gameObject.SetActive(false);
        }

        gamemanager.ad.Play();
        Invoke("LabelDetailSizeSetting", 0.1f);
    }

    void LabelDetailSizeSetting()
    {
        if (ClickLabel.name == "Coex" || (ClickLabel.name == "Stadium" && SceneManager.GetActiveScene().name.Contains("Lotte")) || ClickLabel.name == "Art")
        {
            Btn_Explain.SetActive(true);
            Btn_WebView.SetActive(true);
            DetailImage.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(511, 400 + DetailText.GetComponent<RectTransform>().sizeDelta.y + 50);//  670);
            if (DetailImage.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.y > 650)
            {
                DetailImage.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(511, 650);
            }
        }
        else
        {
            if (Contentsinfo.ContentsName == "Lotte")
            {
                Btn_Explain.SetActive(false);
                Btn_WebView.SetActive(false);
                DetailImage.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(511, 618);
            }
        }
        DetailTextContent.anchoredPosition = new Vector2(DetailTextContent.anchoredPosition.x, 0);
        DetailTextContent.sizeDelta = new Vector2(DetailTextContent.sizeDelta.x, DetailText.GetComponent<RectTransform>().sizeDelta.y + 5);
    }

    public void OnClcikLabelBtn(GameObject obj)
    {
        gamemanager.pinchzoom.zoomstate = global::PinchZoom.ZoomState.None;
        labeldetailstate = LabelDetailState.Closing;
        if (ClickLabel != obj)
        {
            float x = obj.transform.position.x;
            float y = obj.transform.position.y;
            ClickLabel = obj;
            labelmovestate = LabelMoveState.Move;
        }
        else
        {
            ClickLabel = null;
        }

    }

    public void MoveZoomOut()
    {
        if (SceneManager.GetActiveScene().name.Contains("Lotte"))
        {
            if (Clear120Obj.activeSelf)
            {
                if (Main.transform.localPosition.x <= min_x)
                {
                    if (Main.transform.localPosition.y <= min_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x + 0, min_y + 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y >= max_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x + 0.05f, max_y - 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y > min_y && Main.transform.localPosition.y < max_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x + 0.05f, Main.transform.localPosition.y, Cameraz), zoommove_t);
                    }
                }
                else if (Main.transform.localPosition.x >= max_x)
                {
                    if (Main.transform.localPosition.y <= min_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x - 0.05f, min_y + 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y >= max_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x - 0.05f, max_y - 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y > min_y && Main.transform.localPosition.y < max_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x - 0.05f, Main.transform.localPosition.y, Cameraz), zoommove_t);
                    }
                }
                else if (Main.transform.localPosition.x > min_x && Main.transform.localPosition.x < max_x)
                {
                    if (Main.transform.localPosition.y <= min_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, min_y + 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y >= max_y)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, max_y - 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y > min_y && Main.transform.localPosition.y < max_y)
                    {
                        //Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, Main.transform.localPosition.y, Main.transform.localPosition.z), zoommove_t);
                    }
                }
            }
            else if (Clear360Obj.activeSelf)
            {
                if (Main.transform.localPosition.x <= min_x360)
                {
                    if (Main.transform.localPosition.y <= min_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x360 + 0, min_y360 + 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y >= max_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x360 + 0.05f, max_y360 - 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y > min_y360 && Main.transform.localPosition.y < max_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x360 + 0.05f, Main.transform.localPosition.y, Cameraz), zoommove_t);
                    }
                }
                else if (Main.transform.localPosition.x >= max_x360)
                {
                    if (Main.transform.localPosition.y <= min_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x360 - 0.05f, min_y360 + 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y >= max_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x360 - 0.05f, max_y360 - 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y > min_y360 && Main.transform.localPosition.y < max_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x360 - 0.05f, Main.transform.localPosition.y, Cameraz), zoommove_t);
                    }
                }
                else if (Main.transform.localPosition.x > min_x360 && Main.transform.localPosition.x < max_x360)
                {
                    if (Main.transform.localPosition.y <= min_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, min_y360 + 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y >= max_y360)
                    {
                        Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, max_y360 - 0.05f, Cameraz), zoommove_t);
                    }
                    else if (Main.transform.localPosition.y > min_y360 && Main.transform.localPosition.y < max_y360)
                    {
                        //Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, Main.transform.localPosition.y, Main.transform.localPosition.z), zoommove_t);
                    }
                }
            }
        }
        else
        {
            if (Main.transform.localPosition.x <= min_x)
            {
                if (Main.transform.localPosition.y <= min_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x + 0, min_y + 0.05f, Cameraz), zoommove_t);
                }
                else if (Main.transform.localPosition.y >= max_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x + 0.05f, max_y - 0.05f, Cameraz), zoommove_t);
                }
                else if (Main.transform.localPosition.y > min_y && Main.transform.localPosition.y < max_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(min_x + 0.05f, Main.transform.localPosition.y, Cameraz), zoommove_t);
                }
            }
            else if (Main.transform.localPosition.x >= max_x)
            {
                if (Main.transform.localPosition.y <= min_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x - 0.05f, min_y + 0.05f, Cameraz), zoommove_t);
                }
                else if (Main.transform.localPosition.y >= max_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x - 0.05f, max_y - 0.05f, Cameraz), zoommove_t);
                }
                else if (Main.transform.localPosition.y > min_y && Main.transform.localPosition.y < max_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(max_x - 0.05f, Main.transform.localPosition.y, Cameraz), zoommove_t);
                }
            }
            else if (Main.transform.localPosition.x > min_x && Main.transform.localPosition.x < max_x)
            {
                if (Main.transform.localPosition.y <= min_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, min_y + 0.05f, Cameraz), zoommove_t);
                }
                else if (Main.transform.localPosition.y >= max_y)
                {
                    Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, max_y - 0.05f, Cameraz), zoommove_t);
                }
                else if (Main.transform.localPosition.y > min_y && Main.transform.localPosition.y < max_y)
                {
                    //Main.transform.localPosition = Vector3.Lerp(Main.transform.localPosition, new Vector3(Main.transform.localPosition.x, Main.transform.localPosition.y, Main.transform.localPosition.z), zoommove_t);
                }
            }
        }
    }

    public void CloseLabelDetail()
    {
        labeldetailstate = LabelDetailState.Closing;
    }

    void SetchangeZoom(string name)
    {
        if (name == "MasicIsland")
        {
            changeZoom = new Vector3(0, 0, -248);
        }
        else if (name == "Lake")
        {
            changeZoom = new Vector3(0, 0, 55);
        }
        else if (name == "Lotte")
        {
            changeZoom = new Vector3(0, 0, -545);
        }
        else if (name == "Stadium" && Contentsinfo.ContentsName == "Lotte")
        {
            changeZoom = new Vector3(0, 0, 388);
        }
        else if (name == "Olympic" || name == "Olympic_1")
        {
            changeZoom = new Vector3(0, 0, 107);
        }
        else if (name == "Art" || name == "Cemetery" || name == "Banpo" || name == "NTower")
        {
            changeZoom = new Vector3(0, 0, 1851);
        }
        else
        {
            changeZoom = new Vector3(0, 0, StartZoom);
        }
    }

    public void OnClickHomeBtn()
    {
        switch (Contentsinfo.ContentsName)
        {
            case "Lotte":
                if (Clear120Obj.activeSelf)
                {
                    Main.transform.parent.transform.localPosition = new Vector3(0, 0, 956);
                    Main.transform.localPosition = new Vector3(-19435, 5115, -1631);
                    Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 1560;
                }
                else
                {
                    OnClick360Btn();
                    OnClickHomeBtn();
                }
                break;
            case "BEXCO":
                Main.transform.localPosition = new Vector3(-1501, 1834, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                Main.transform.parent.transform.localPosition = new Vector3(0, 0, 1);
                break;
            case "High1":
                Main.transform.localPosition = new Vector3(7853, 4099, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                Main.transform.parent.transform.localPosition = new Vector3(0, 0, 1);
                break;
            case "Odu":
                Main.transform.localPosition = new Vector3(20204, 122, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                Main.transform.parent.transform.localPosition = new Vector3(0, 0, 1);
                break;
            case "Apsan":
                Main.transform.localPosition = new Vector3(-8407, -870, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2515;
                Main.transform.parent.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case "Aegibong":
                Main.transform.localPosition = new Vector3(-1705, -2744, -1631);
                Main.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, -1630);
                Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 2316;
                Main.transform.parent.transform.localPosition = new Vector3(0, 0, 0);
                break;
        }

        value = (gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - (MaxZoomOut)) / ((MaxZoomIn - MaxZoomOut) / 100);
        value = 100 - value;
        for (int i = 0; i < gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
        {
            gamemanager.clearMode.AllMapLabels.transform.GetChild(i).localScale = new Vector3(MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value));
        }

        if (SceneManager.GetActiveScene().name.Contains("Aegibong"))
        {
            for (int i = 0; i < disablelabel.HiddenObj_s.Length; i++)
            {
                disablelabel.HiddenObj_s[i].transform.localScale = new Vector3(MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value), MinZoomValue + (MaxZoomValue * value));
            }
        }

        labeldetailstate = LabelDetailState.Closing;
        labelmovestate = LabelMoveState.None;
        minimapbuttonstate = MiniMapButtonState.None;
        gamemanager.pinchzoom.zoomstate = global::PinchZoom.ZoomState.None;
    }

    void Invoke360()
    {
        btn360.enabled = true;
        if (gamemanager.navibarstate != GameManager.NavibarState.Closing)
        {
            gamemanager.navibarstate = GameManager.NavibarState.Closing;
        }
    }

    public Button btn360;
    public GameObject Notice360;
    public GameObject Clear120Obj;
    public GameObject Clear360Obj;

    public void OnClick360Btn()
    {
        if (btn360.transform.GetChild(1).gameObject.activeSelf)
        {
            btn360.transform.GetChild(1).gameObject.SetActive(false);
        }

        btn360.enabled = false;
        Invoke("Invoke360", 0.5f);

        labelmovestate = LabelMoveState.None;
        labeldetailstate = LabelDetailState.Closing;

        if (Clear120Obj.activeSelf)
        {
            MiniMap360.SetActive(true);
            //gamemanager.setpano.ReduceLoading();
            Notice360.SetActive(true);
            //Obj3D.SetActive(false);
            AllMapLabels.SetActive(false);
            Label360.SetActive(true);
            gamemanager.Arrow.SetActive(false);
            gamemanager.MiniMap_Background.transform.gameObject.SetActive(false);
            Clear120Obj.SetActive(false);
            Clear360Obj.SetActive(true);
            Main.transform.parent.gameObject.transform.position = new Vector3(Main.transform.parent.gameObject.transform.position.x, Main.transform.parent.gameObject.transform.position.y, StartZoom);
            Cameraz = -1631;
            Main.transform.position = new Vector3(48174.74f, 6228.141f, Cameraz);
            Main.transform.localPosition = new Vector3(Main.transform.localPosition.x, Main.transform.localPosition.y, Cameraz);
        }
        else
        {
            MiniMap360.SetActive(false);
            Notice360.SetActive(false);
            //Obj3D.SetActive(false);
            AllMapLabels.SetActive(true);
            Label360.SetActive(false);
            gamemanager.Arrow.SetActive(true);
            gamemanager.MiniMap_Background.transform.gameObject.SetActive(true);
            Clear120Obj.SetActive(true);
            Clear360Obj.SetActive(false);
            Main.transform.parent.transform.localPosition = new Vector3(0, 0, 956);
            Main.transform.localPosition = new Vector3(-19435, 5115, -1631);
            Main.transform.GetChild(0).GetComponent<Camera>().orthographicSize = 1560;
        }
    }

    public void OnClickDetailSoundBtn(GameObject btn)
    {
        if (btn.transform.GetChild(0).gameObject.activeSelf)
        {
            btn.transform.GetChild(0).gameObject.SetActive(false);
            gamemanager.ad.Stop();
        }
        else
        {
            btn.transform.GetChild(0).gameObject.SetActive(true);
            gamemanager.ad.Play();
        }
    }
}
