using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AegibongLabel : MonoBehaviour
{
    public static List<string> Label_total;
    public static List<string> Label_Cate_1;
    public static List<string> Label_Cate_2;

    public static List<string> Label_Minimap;

    public static Sprite[] NaviLabel;
    public static Sprite[] MapLabel;
    
    public static Sprite[] DetailImage;
    public static Sprite[] MinimapLabel;
    public static Sprite CaptureMark;
    public static Sprite Tip_K;
    public static Sprite Tip_E;
    public static Sprite Tip_C;
    public static Sprite Tip_J;

    public static AudioClip[] Narration_K;
    public static AudioClip[] Narration_E;
    public static AudioClip[] Narration_C;
    public static AudioClip[] Narration_J;

    public static string[] WaitingVideo_path;

    public static bool[] ModeActive;

    public static void LoadLabelInfo()
    {
        Label_total = new List<string> { "UIsland", "Spoonbill", "Ganghwa", "JoR", "Ssangma", 
                                         "Saeseommae", "Mullet", "Namunjae", "Pep", "SongakM", 
                                         "Mouse", "Wcrane", "Dragonfly", "HanteoM", "Mosaedal",
                                         "SeoglyupoV", "Crab", "Chilmyeoncho", "Gijungdong", "Daesungdong",
                                         "Gary", "Haehong", "Gaesgaemichwi", "ImjinR", "Dolgoji",
                                         "Butterfly", "Odusan"};
        Label_Cate_1 = new List<string> {"Spoonbill", "Saeseommae", "Mullet", "Namunjae", "Pep",
                                         "Mouse", "Wcrane", "Dragonfly", "Mosaedal", "Crab",
                                         "Chilmyeoncho", "Gary", "Haehong", "Gaesgaemichwi", "Butterfly"};
        Label_Cate_2 = new List<string> {"UIsland", "Ganghwa", "JoR", "Ssangma", "SongakM",
                                         "HanteoM", "SeoglyupoV", "Gijungdong", "Daesungdong", "ImjinR",
                                         "Dolgoji", "Odusan"};

        Label_Minimap = new List<string> { "UIsland", "SongakM", "Odusan" };

        NaviLabel = new Sprite[Resources.LoadAll<Sprite>("Aegibong/Sprite/NavigationLabel").Length];
        MapLabel = new Sprite[Resources.LoadAll<Sprite>("Aegibong/Sprite/MapLabel").Length];

        DetailImage = new Sprite[Resources.LoadAll<Sprite>("Aegibong/Sprite/DetailImage").Length];
        MinimapLabel = new Sprite[Resources.LoadAll<Sprite>("Aegibong/Sprite/Hotspot").Length];

        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("Aegibong/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("Aegibong/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("Aegibong/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("Aegibong/Narration/Japanese").Length];

        NaviLabel = Resources.LoadAll<Sprite>("Aegibong/Sprite/NavigationLabel");
        MapLabel = Resources.LoadAll<Sprite>("Aegibong/Sprite/MapLabel");

        DetailImage = Resources.LoadAll<Sprite>("Aegibong/Sprite/DetailImage");
        MinimapLabel = Resources.LoadAll<Sprite>("Aegibong/Sprite/Hotspot");

        CaptureMark = Resources.Load<Sprite>("Aegibong/Sprite/CaptureMark");

        Tip_K = Resources.Load<Sprite>("Aegibong/Sprite/Tip_K");
        Tip_E = Resources.Load<Sprite>("Aegibong/Sprite/Tip_E");
        Tip_C = Resources.Load<Sprite>("Aegibong/Sprite/Tip_C");
        Tip_J = Resources.Load<Sprite>("Aegibong/Sprite/Tip_J");

        Narration_K = Resources.LoadAll<AudioClip>("Aegibong/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("Aegibong/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("Aegibong/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("Aegibong/Narration/Japanese");

        //WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/Video", "*.mp4");

        //SettingManager.Password_Setting = "0523";

        //GameManager.MainMode = "XRMode";
        //ClearMode.StartPosition = new Vector3(-1705, -2744, -1631);
        //ClearMode.StartZoom = 200;
        //ClearMode.MaxZoomIn = 1851;
        //ClearMode.LabelMaxZoomIn = 1200;//970
        //ClearMode.MaxZoomOut = -100;
        //ClearMode.MinLabelSize = 1.0f;
        //ClearMode.MaxLabelSize = 3;//5.5f;

        ModeActive = new bool[3];
    }
}
