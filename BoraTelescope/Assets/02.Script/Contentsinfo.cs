using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Contentsinfo : MonoBehaviour
{
    [SerializeField]
    GameObject NaviLabelPrefab;
    [SerializeField]
    GameObject DNaviLabelPrefab;

    GameObject RNaviLabelPrefab;
    public static string ContentsName;

    public List<string> Label_total = new List<string>();
    public List<string> Label_Cate_1 = new List<string>();
    public List<string> Label_Cate_2 = new List<string>();
    public List<GameObject> NaviLabelList = new List<GameObject>();
    [SerializeField]
    public RectTransform NaviLabelContent;

    public List<Vector2> XRModeLabel = new List<Vector2>();

    public Sprite[] NaviLabel;
    public Sprite[] NaviLabel_K;
    public Sprite[] NaviLabel_E;
    public Sprite[] NaviLabel_C;
    public Sprite[] NaviLabel_J;
    public Sprite[] DetailImage_K;
    public Sprite[] DetailImage_E;
    public Sprite[] DetailImage_C;
    public Sprite[] DetailImage_J;

    public List<string> DetailText_K = new List<string>();
    public List<string> DetailText_E = new List<string>();
    public List<string> DetailText_C = new List<string>();
    public List<string> DetailText_J = new List<string>();

    public List<string> LabelName_K = new List<string>();
    public List<string> LabelName_E = new List<string>();
    public List<string> LabelName_C = new List<string>();
    public List<string> LabelName_J = new List<string>();

    public AudioClip[] Narration_K;
    public AudioClip[] Narration_E;
    public AudioClip[] Narration_C;
    public AudioClip[] Narration_J;

    public VideoClip[] WaitingVideo;
    public Sprite[] MapLabel;

    public Sprite Tip_K;
    public Sprite Tip_E;
    public Sprite Tip_C;
    public Sprite Tip_J;

    public enum StartState
    {
        Lotte,
        Odu,
    }
    public StartState startstate = 0;

    private void Awake()
    {
        ResetList();
        if (ContentsName == null)
        {
            if (startstate == StartState.Odu)
            {
                ContentsName = "Odu";
            }
            else if (startstate == StartState.Lotte)
            {
                ContentsName = "Lotte";
            }
            TelescopeInfo(ContentsName);
        }
    }

    public void ResetList()
    {
        for (int i = 0; i < NaviLabelList.Count; i++)
        {
            Destroy(NaviLabelList[i].gameObject);
        }
        NaviLabelList.Clear();

        Resources.UnloadUnusedAssets();
        Label_total.Clear();
        Label_Cate_1.Clear();
        Label_Cate_2.Clear();
        Array.Clear(NaviLabel, 0, NaviLabel.Length);
        Array.Clear(NaviLabel_K, 0, NaviLabel_K.Length);
        Array.Clear(NaviLabel_E, 0, NaviLabel_E.Length);
        Array.Clear(NaviLabel_C, 0, NaviLabel_C.Length);
        Array.Clear(NaviLabel_J, 0, NaviLabel_J.Length);
        Array.Clear(DetailImage_K, 0, DetailImage_K.Length);
        Array.Clear(DetailImage_C, 0, DetailImage_C.Length);
        Array.Clear(DetailImage_J, 0, DetailImage_J.Length);
        DetailText_K.Clear();
        DetailText_E.Clear();
        DetailText_C.Clear();
        DetailText_J.Clear();
        LabelName_K.Clear();
        LabelName_E.Clear();
        LabelName_C.Clear();
        LabelName_J.Clear();
        Array.Clear(MapLabel, 0, MapLabel.Length);
        Array.Clear(Narration_K, 0, Narration_K.Length);
        Array.Clear(Narration_E, 0, Narration_E.Length);
        Array.Clear(Narration_C, 0, Narration_C.Length);
        Array.Clear(Narration_J, 0, Narration_J.Length);
        XRModeLabel.Clear();

        Array.Clear(WaitingVideo, 0, WaitingVideo.Length);
        GC.Collect();
        GetComponent<LabelMake>().Navilabel_Icon.Clear();
        GetComponent<LabelMake>().Navilabel_Text.Clear();
    }

    public void TelescopeInfo(string Telescope)
    {
        switch (Telescope)
        {
            case "High1":
                //PlayerSettings.bundleVersion = DoraLabel.ContentsVersion;
                High1Label.LoadLabelInfo();
                if (High1Label.DetailImage_J != null)
                {
                    Label_total = High1Label.Label_total;
                    Label_Cate_1 = High1Label.Label_Cate_1;
                    Label_Cate_2 = High1Label.Label_Cate_2;

                    NaviLabel_K = (Sprite[])High1Label.NaviLabel_K.Clone();
                    NaviLabel_E = (Sprite[])High1Label.NaviLabel_E.Clone();
                    NaviLabel_C = (Sprite[])High1Label.NaviLabel_C.Clone();
                    NaviLabel_J = (Sprite[])High1Label.NaviLabel_J.Clone();
                    DetailImage_K = (Sprite[])High1Label.DetailImage_K.Clone();
                    DetailImage_C = (Sprite[])High1Label.DetailImage_C.Clone();
                    DetailImage_J = (Sprite[])High1Label.DetailImage_J.Clone();
                    Narration_K = (AudioClip[])High1Label.Narration_K.Clone();
                    Narration_E = (AudioClip[])High1Label.Narration_E.Clone();
                    Narration_C = (AudioClip[])High1Label.Narration_C.Clone();
                    Narration_J = (AudioClip[])High1Label.Narration_J.Clone();
                    Tip_K = Resources.Load<Sprite>("Odu/Sprite/Tip_K");
                    Tip_E = Resources.Load<Sprite>("Odu/Sprite/Tip_E");
                    Tip_C = Resources.Load<Sprite>("Odu/Sprite/Tip_C");
                    Tip_J = Resources.Load<Sprite>("Odu/Sprite/Tip_J");
                    print(Tip_K);
                }
                RNaviLabelPrefab = NaviLabelPrefab;
                break;
            case "Odu":
                //PlayerSettings.bundleVersion = DoraLabel.ContentsVersion;
                OduLabel.LoadLabelInfo();


                Label_total = OduLabel.Label_total;
                Label_Cate_1 = OduLabel.Label_Cate_1;
                Label_Cate_2 = OduLabel.Label_Cate_2;


                NaviLabel_K = (Sprite[])OduLabel.NaviLabel_K.Clone();
                NaviLabel_E = (Sprite[])OduLabel.NaviLabel_E.Clone();
                NaviLabel_C = (Sprite[])OduLabel.NaviLabel_C.Clone();
                NaviLabel_J = (Sprite[])OduLabel.NaviLabel_J.Clone();
                DetailImage_K = (Sprite[])OduLabel.DetailImage_K.Clone();
                DetailImage_C = (Sprite[])OduLabel.DetailImage_C.Clone();
                DetailImage_J = (Sprite[])OduLabel.DetailImage_J.Clone();
                Narration_K = (AudioClip[])OduLabel.Narration_K.Clone();
                Narration_E = (AudioClip[])OduLabel.Narration_E.Clone();
                Narration_C = (AudioClip[])OduLabel.Narration_C.Clone();
                Narration_J = (AudioClip[])OduLabel.Narration_J.Clone();
                Tip_K = Resources.Load<Sprite>("Odu/Sprite/Tip_K");
                Tip_E = Resources.Load<Sprite>("Odu/Sprite/Tip_E");
                Tip_C = Resources.Load<Sprite>("Odu/Sprite/Tip_C");
                Tip_J = Resources.Load<Sprite>("Odu/Sprite/Tip_J");


                RNaviLabelPrefab = NaviLabelPrefab;
                break;
            case "BEXCO":
                BEXCOLabel.LoadLabelInfo();
                Label_total = BEXCOLabel.Label_total;
                Label_Cate_1 = BEXCOLabel.Label_Cate_1;
                Label_Cate_2 = BEXCOLabel.Label_Cate_2;
                NaviLabel_K = new Sprite[BEXCOLabel.NaviLabel_K.Length];
                NaviLabel_E = new Sprite[BEXCOLabel.NaviLabel_E.Length];
                DetailImage_K = new Sprite[BEXCOLabel.DetailImage_K.Length];
                //DetailText_K = (Sprite[])BEXCOLabel.DetailText_K.Clone();
                //DetailText_E = (Sprite[])BEXCOLabel.DetailText_E.Clone();
                Narration_K = new AudioClip[BEXCOLabel.Narration_K.Length];
                Narration_E = new AudioClip[BEXCOLabel.Narration_E.Length];

                NaviLabel_K = (Sprite[])BEXCOLabel.NaviLabel_K.Clone();
                NaviLabel_E = (Sprite[])BEXCOLabel.NaviLabel_E.Clone();
                DetailImage_K = (Sprite[])BEXCOLabel.DetailImage_K.Clone();
                Narration_K = (AudioClip[])BEXCOLabel.Narration_K.Clone();
                Narration_E = (AudioClip[])BEXCOLabel.Narration_E.Clone();

                Tip_K = Resources.Load<Sprite>("Odu/Sprite/Tip_K");
                Tip_E = Resources.Load<Sprite>("Odu/Sprite/Tip_E");
                Tip_C = Resources.Load<Sprite>("Odu/Sprite/Tip_C");
                Tip_J = Resources.Load<Sprite>("Odu/Sprite/Tip_J");
                //WaitingVideo_path = (string[])BEXCOLabel.WaitingVideo_path.Clone();
                RNaviLabelPrefab = NaviLabelPrefab;
                break;
            case "Lotte":
                LoadLabelInfoLotte();
                RNaviLabelPrefab = NaviLabelPrefab;
                break;

            case "Apsan":
                ApsanLabel.LoadLabelInfo();
                Label_total = ApsanLabel.Label_total;
                Label_Cate_1 = ApsanLabel.Label_Cate_1;
                Label_Cate_2 = ApsanLabel.Label_Cate_2;

                NaviLabel_K = (Sprite[])ApsanLabel.NaviLabel.Clone();
                DetailImage_K = (Sprite[])ApsanLabel.DetailImage.Clone();

                NaviLabel_E = NaviLabel_K;
                NaviLabel_C = NaviLabel_K;
                NaviLabel_J = NaviLabel_K;

                MapLabel = new Sprite[ApsanLabel.MapLabel.Length];
                MapLabel = ApsanLabel.MapLabel;

                Narration_K = new AudioClip[ApsanLabel.Narration_K.Length];
                Narration_E = new AudioClip[ApsanLabel.Narration_E.Length];
                Narration_C = new AudioClip[ApsanLabel.Narration_C.Length];
                Narration_J = new AudioClip[ApsanLabel.Narration_J.Length];
                Narration_K = (AudioClip[])ApsanLabel.Narration_K.Clone();
                Narration_E = (AudioClip[])ApsanLabel.Narration_E.Clone();
                Narration_C = (AudioClip[])ApsanLabel.Narration_C.Clone();
                Narration_J = (AudioClip[])ApsanLabel.Narration_J.Clone();

                Tip_K = Resources.Load<Sprite>("Apsan/Sprite/Tip_K");
                Tip_E = Resources.Load<Sprite>("Apsan/Sprite/Tip_E");
                Tip_C = Resources.Load<Sprite>("Apsan/Sprite/Tip_C");
                Tip_J = Resources.Load<Sprite>("Apsan/Sprite/Tip_J");

                RNaviLabelPrefab = DNaviLabelPrefab;
                break;
            case "NamsanH":
                GetComponent<NamsanHNaviLabel>().NamSanClick();
                LoadLabelInfoNH();
                break;
            case "Aegibong":
                AegibongLabel.LoadLabelInfo();
                Label_total = AegibongLabel.Label_total;
                Label_Cate_1 = AegibongLabel.Label_Cate_1;
                Label_Cate_2 = AegibongLabel.Label_Cate_2;

                NaviLabel_K = (Sprite[])AegibongLabel.NaviLabel.Clone();
                DetailImage_K = (Sprite[])AegibongLabel.DetailImage.Clone();

                NaviLabel_E = NaviLabel_K;
                NaviLabel_C = NaviLabel_K;
                NaviLabel_J = NaviLabel_K;

                MapLabel = new Sprite[AegibongLabel.MapLabel.Length];
                MapLabel = AegibongLabel.MapLabel;

                Narration_K = new AudioClip[AegibongLabel.Narration_K.Length];
                Narration_E = new AudioClip[AegibongLabel.Narration_E.Length];
                Narration_C = new AudioClip[AegibongLabel.Narration_C.Length];
                Narration_J = new AudioClip[AegibongLabel.Narration_J.Length];
                Narration_K = (AudioClip[])AegibongLabel.Narration_K.Clone();
                Narration_E = (AudioClip[])AegibongLabel.Narration_E.Clone();
                Narration_C = (AudioClip[])AegibongLabel.Narration_C.Clone();
                Narration_J = (AudioClip[])AegibongLabel.Narration_J.Clone();

                Tip_K = Resources.Load<Sprite>("Aegibong/Sprite/Tip_K");
                Tip_E = Resources.Load<Sprite>("Aegibong/Sprite/Tip_E");
                Tip_C = Resources.Load<Sprite>("Aegibong/Sprite/Tip_C");
                Tip_J = Resources.Load<Sprite>("Aegibong/Sprite/Tip_J");

                RNaviLabelPrefab = DNaviLabelPrefab;
                break;

            case "EndIsland":
                EndIslandLabel.LoadLabelInfo();
                Label_total = EndIslandLabel.Label_total;
                Label_Cate_1 = EndIslandLabel.Label_Cate_1;
                Label_Cate_2 = EndIslandLabel.Label_Cate_2;

                NaviLabel_K = (Sprite[])EndIslandLabel.NaviLabel.Clone();
                DetailImage_K = (Sprite[])EndIslandLabel.DetailImage.Clone();

                NaviLabel_E = NaviLabel_K;
                NaviLabel_C = NaviLabel_K;
                NaviLabel_J = NaviLabel_K;

                MapLabel = new Sprite[EndIslandLabel.MapLabel.Length];
                MapLabel = EndIslandLabel.MapLabel;

                Narration_K = new AudioClip[EndIslandLabel.Narration_K.Length];
                Narration_E = new AudioClip[EndIslandLabel.Narration_E.Length];
                Narration_C = new AudioClip[EndIslandLabel.Narration_C.Length];
                Narration_J = new AudioClip[EndIslandLabel.Narration_J.Length];
                Narration_K = (AudioClip[])EndIslandLabel.Narration_K.Clone();
                Narration_E = (AudioClip[])EndIslandLabel.Narration_E.Clone();
                Narration_C = (AudioClip[])EndIslandLabel.Narration_C.Clone();
                Narration_J = (AudioClip[])EndIslandLabel.Narration_J.Clone();

                Tip_K = Resources.Load<Sprite>("Island/Sprite/Tip_K");
                Tip_E = Resources.Load<Sprite>("Island/Sprite/Tip_E");
                Tip_C = Resources.Load<Sprite>("Island/Sprite/Tip_C");
                Tip_J = Resources.Load<Sprite>("Island/Sprite/Tip_J");

                RNaviLabelPrefab = DNaviLabelPrefab;
                break;
        }

        if (!(ContentsName == "Dora" || ContentsName == "EndIsland"))
        {
            for (int i = 0; i < Label_total.Count; i++)
            {
                LabelData(Label_total[i], NaviLabel_K[i], i, i);
            }
            NaviLabelContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, +12 + 62 * (Label_total.Count) + 27 * (Label_total.Count));
        }
    }

    public void LabelData(string Name, Sprite sp, int i, int k)
    {
        GameObject obj = Instantiate(RNaviLabelPrefab);
        obj.SetActive(true);
        obj.transform.parent = NaviLabelContent;
        obj.name = Name;
        if (ContentsName == "Apsan" || ContentsName == "Aegibong")
        {
            switch (GameManager.langstate)
            {
                case GameManager.LangState.Korea:
                    obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = LabelName_K[k];
                    break;
                case GameManager.LangState.English:
                    obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = LabelName_E[k];
                    break;
                case GameManager.LangState.Chienses:
                    obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = LabelName_C[k];
                    break;
                case GameManager.LangState.Japan:
                    obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = LabelName_J[k];
                    break;
            }
            GetComponent<LabelMake>().Navilabel_Text.Add(obj.transform.GetChild(0).gameObject.GetComponent<Text>());
            obj.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = sp;
            GetComponent<LabelMake>().Navilabel_Icon.Add(obj.transform.GetChild(1).gameObject.GetComponent<Image>());
            GetComponent<LabelMake>().NavigationTextObj(obj.transform.GetChild(0).gameObject.GetComponent<Text>());
        }
        else
        {
            obj.GetComponent<Image>().sprite = sp;
            if (ContentsName == "NamsanH")
            {
                obj.transform.GetChild(0).gameObject.SetActive(false);
                obj.transform.GetChild(1).gameObject.SetActive(false);
            }
        }

        float count = NaviLabelList.Count;
        obj.transform.localPosition = new Vector3(0, -12 - obj.GetComponent<RectTransform>().rect.height * count - 27 * count, 0);
        NaviLabelList.Add(obj);
    }

    public void LoadLabelInfoLotte()
    {
        Label_total = new List<string> {"Daemo", "MasicIsland", "Lake", "Lotte", "Art",
                                        "Cemetery", "Tombs", "Coex", "Banpo", "Stadium",
                                        "JamsilPark", "HanR", "ChungDam", "YoungDong", "SungSu",
                                        "NTower"};
        Label_Cate_1 = new List<string> { "Daemo", "Lake", "Banpo", "HanR", "ChungDam", "YoungDong", "SungSu" };
        Label_Cate_2 = new List<string> {"MasicIsland", "Lotte", "Art", "Cemetery", "Tombs",
                                         "Coex", "Stadium", "JamsilPark", "NTower"};

        NaviLabel_K = new Sprite[Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_K").Length];
        NaviLabel_E = new Sprite[Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_E").Length];
        NaviLabel_C = new Sprite[Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_C").Length];
        NaviLabel_J = new Sprite[Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_J").Length];

        //DetailImage = new Sprite[Resources.LoadAll<Sprite>("Lotte/Sprite/DetailImage_K").Length];

        DetailImage_K = new Sprite[Resources.LoadAll<Sprite>("Lotte/Sprite/DetailImage_K").Length];
        //DetailImage_E = new Sprite[Resources.LoadAll<Sprite>("Sprite/DetailImage_E").Length];
        //DetailImage_C = new Sprite[Resources.LoadAll<Sprite>("Sprite/DetailImage_C").Length];
        //DetailImage_J = new Sprite[Resources.LoadAll<Sprite>("Sprite/DetailImage_J").Length];

        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("Lotte/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("Lotte/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("Lotte/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("Lotte/Narration/Japanese").Length];

        NaviLabel_K = Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_K");
        NaviLabel_E = Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_E");
        NaviLabel_C = Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_C");
        NaviLabel_J = Resources.LoadAll<Sprite>("Lotte/Sprite/NavigationLabel_J");

        //DetailImage = Resources.LoadAll<Sprite>("Lotte/Sprite/DetailImage_K");

        DetailImage_K = Resources.LoadAll<Sprite>("Lotte/Sprite/DetailImage_K");
        //DetailImage_E = Resources.LoadAll<Sprite>("Sprite/DetailImage_E");
        //DetailImage_C = Resources.LoadAll<Sprite>("Sprite/DetailImage_C");
        //DetailImage_J = Resources.LoadAll<Sprite>("Sprite/DetailImage_J");

        Narration_K = Resources.LoadAll<AudioClip>("Lotte/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("Lotte/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("Lotte/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("Lotte/Narration/Japanese");

        Tip_K = Resources.Load<Sprite>("Lotte/Sprite/Tip_K");
        Tip_E = Resources.Load<Sprite>("Lotte/Sprite/Tip_E");
        Tip_C = Resources.Load<Sprite>("Lotte/Sprite/Tip_C");
        Tip_J = Resources.Load<Sprite>("Lotte/Sprite/Tip_J");


        See360Lotte.Past70 = Resources.Load<Sprite>("Lotte/Sprite/360/Past70");
        See360Lotte.Past80 = Resources.Load<Sprite>("Lotte/Sprite/360/Past80");
        See360Lotte.Current = Resources.Load<Sprite>("Lotte/Sprite/360/Current");
        // See360Lotte.DisVideo = Directory.GetFiles(Application.dataPath + "/Resources/Lotte/Sprite/360/Dissolve/", "*.mp4");
        // See360Lotte.DisVideo = Directory.GetFiles(Application.streamingAssetsPath + "/Lotte/Sprite/360/Dissolve/", "*.mp4");
        TextAsset[] loadedFiles = Resources.LoadAll<TextAsset>("Lotte/Sprite/360/Dissolve/");
        //string[] fileNames = new string[loadedFiles.Length];

        string[] fileNames = Directory.GetFiles("Assets/Resources/Lotte/Sprite/360/Dissolve", "*.mp4*", SearchOption.AllDirectories);

        for (int i = 0; i < loadedFiles.Length; i++)
        {
            fileNames[i] = loadedFiles[i].name;
        }

        See360Lotte.DisVideo = fileNames;

        for (int index = 0; index < See360Lotte.DisVideo.Length; index++)
        {
            if(!(See360Lotte.DisVideo[index].Contains("meta")))
            {
                if (See360Lotte.DisVideo[index].Contains("CurPast70"))
                {
                    See360Lotte.Dis_CurPast70 = See360Lotte.DisVideo[index];
                }
                else if (See360Lotte.DisVideo[index].Contains("CurPast87"))
                {
                    See360Lotte.Dis_CurPast87 = See360Lotte.DisVideo[index];
                }
                else if (See360Lotte.DisVideo[index].Contains("Past87Cur"))
                {
                    See360Lotte.Dis_Past87Cur = See360Lotte.DisVideo[index];
                }
                else if (See360Lotte.DisVideo[index].Contains("Past8770"))
                {
                    See360Lotte.Dis_Past8770 = See360Lotte.DisVideo[index];
                }
                else if (See360Lotte.DisVideo[index].Contains("Past70Cur"))
                {
                    See360Lotte.Dis_Past70Cur = See360Lotte.DisVideo[index];
                }
                else if (See360Lotte.DisVideo[index].Contains("Past7087"))
                {
                    See360Lotte.Dis_Past7087 = See360Lotte.DisVideo[index];
            }

            }
        }
    }

    public AudioClip[] Narration_Docent_K;
    public AudioClip[] Narration_Wisdom_K;
    public AudioClip[] Narration_Flow_K;

    public AudioClip[] Narration_Docent_E;
    public AudioClip[] Narration_Wisdom_E;
    public AudioClip[] Narration_Flow_E;

    public AudioClip[] Narration_Docent_C;
    public AudioClip[] Narration_Wisdom_C;
    public AudioClip[] Narration_Flow_C;

    public AudioClip[] Narration_Docent_J;
    public AudioClip[] Narration_Wisdom_J;
    public AudioClip[] Narration_Flow_J;

    public void LoadLabelInfoNH()
    {
        Label_total = new List<string> { "1991", "1996", "1998", "2003", "2013", "House1", "House2", "House3", "House4", "House5", "House6", "House7", "House8", "House9", "House10" };
        Label_Cate_1 = new List<string> { "1991", "1996", "1998", "2003", "2013" };
        Label_Cate_2 = new List<string> { "House1", "House2", "House3", "House4", "House5", "House6", "House7", "House8", "House9", "House10" };

        //NaviLabel_K = new Sprite[Resources.LoadAll<Sprite>("Sprite/NavigationLabel_K").Length];
        //NaviLabel_E = new Sprite[Resources.LoadAll<Sprite>("Sprite/NavigationLabel_E").Length];
        NaviLabel_K = GetComponent<NamsanHNaviLabel>().NaviLabel_K;
        NaviLabel_E = GetComponent<NamsanHNaviLabel>().NaviLabel_E;
        NaviLabel_C = GetComponent<NamsanHNaviLabel>().NaviLabel_C;
        NaviLabel_J = GetComponent<NamsanHNaviLabel>().NaviLabel_J;

        DetailImage_K = new Sprite[Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_K").Length];
        DetailImage_E = new Sprite[Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_E").Length];
        DetailImage_C = new Sprite[Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_K").Length];
        DetailImage_J = new Sprite[Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_K").Length];

        Narration_Docent_K = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Korea/Docent").Length];
        Narration_Wisdom_K = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Korea/Wisdom").Length];
        Narration_Flow_K = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Korea/Flow").Length];

        Narration_Docent_E = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/English/Docent").Length];
        Narration_Wisdom_E = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/English/Wisdom").Length];
        Narration_Flow_E = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/English/FLow").Length];

        Narration_Docent_C = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Chinese/Docent").Length];
        Narration_Wisdom_C = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Chinese/Wisdom").Length];
        Narration_Flow_C = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Chinese/Flow").Length];

        Narration_Docent_J = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Japan/Docent").Length];
        Narration_Wisdom_J = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Japan/Wisdom").Length];
        Narration_Flow_J = new AudioClip[Resources.LoadAll<AudioClip>("NamsanH/Narration/Japan/Flow").Length];

        //NaviLabel_K = Resources.LoadAll<Sprite>("Sprite/NavigationLabel_K");
        //NaviLabel_E = Resources.LoadAll<Sprite>("Sprite/NavigationLabel_E");
        DetailImage_K = Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_K");
        DetailImage_E = Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_E");
        DetailImage_C = Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_K");
        DetailImage_J = Resources.LoadAll<Sprite>("NamsanH/Sprite/DetailImage_K");

        Narration_Docent_K = Resources.LoadAll<AudioClip>("NamsanH/Narration/Korea/Docent");
        Narration_Wisdom_K = Resources.LoadAll<AudioClip>("NamsanH/Narration/Korea/Wisdom");
        Narration_Flow_K = Resources.LoadAll<AudioClip>("NamsanH/Narration/Korea/Flow");
        Narration_Docent_E = Resources.LoadAll<AudioClip>("NamsanH/Narration/English/Docent");
        Narration_Wisdom_E = Resources.LoadAll<AudioClip>("NamsanH/Narration/English/Wisdom");
        Narration_Flow_E = Resources.LoadAll<AudioClip>("NamsanH/Narration/English/FLow");
        Narration_Docent_C = Resources.LoadAll<AudioClip>("NamsanH/Narration/Chinese/Docent");
        Narration_Wisdom_C = Resources.LoadAll<AudioClip>("NamsanH/Narration/Chinese/Wisdom");
        Narration_Flow_C = Resources.LoadAll<AudioClip>("NamsanH/Narration/Chinese/FLow");
        Narration_Docent_J = Resources.LoadAll<AudioClip>("NamsanH/Narration/Japan/Docent");
        Narration_Wisdom_J = Resources.LoadAll<AudioClip>("NamsanH/Narration/Japan/Wisdom");
        Narration_Flow_J = Resources.LoadAll<AudioClip>("NamsanH/Narration/Japan/FLow");

        Tip_K = Resources.Load<Sprite>("NamsanH/Sprite/Tip_Nam_K");
        Tip_E = Resources.Load<Sprite>("NamsanH/Sprite/Tip_Nam_E");
        Tip_C = Resources.Load<Sprite>("NamsanH/Sprite/Tip_Nam_C");
        Tip_J = Resources.Load<Sprite>("NamsanH/Sprite/Tip_Nam_J");
    }
}
