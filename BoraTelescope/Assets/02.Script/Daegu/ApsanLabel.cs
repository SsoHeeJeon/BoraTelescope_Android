using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ApsanLabel : MonoBehaviour
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

    public static AudioClip[] Narration_K;
    public static AudioClip[] Narration_E;
    public static AudioClip[] Narration_C;
    public static AudioClip[] Narration_J;

    public static string[] WaitingVideo_path;

    public static bool[] ModeActive;

    public static void LoadLabelInfo()
    {
        Label_total = new List<string> { "Diak", "Market", "SunObservation", "Lake", "Artcenter",
                                         "Durupark", "Tower83", "Anjilang", "Bangogae", "Flowerisland",
                                         "Dalsungpark", "VStreet", "Historic", "Guam", "SugarStreet",
                                         "ConcertHouse", "Dongsungro", "RedrawStreet", "PalgongMt",
                                         "Lions", "Stadium", "Susung"};
        Label_Cate_1 = new List<string> { "Lake", "Durupark", "Flowerisland", "Dalsungpark", "PalgongMt", "Susung" };
        Label_Cate_2 = new List<string> {"Diak", "Market", "SunObservation", "Artcenter","Tower83",
                                         "Anjilang", "Bangogae", "VStreet", "Historic", "Guam",
                                         "SugarStreet", "ConcertHouse", "School", "Dongsungro", "RedrawStreet",
                                         "Lions", "Stadium"};

        Label_Minimap = new List<string> { "Diak", "Tower83", "Stadium" };

        NaviLabel = new Sprite[Resources.LoadAll<Sprite>("Apsan/Sprite/NavigationLabel").Length];
        MapLabel = new Sprite[Resources.LoadAll<Sprite>("Apsan/Sprite/MapLabel").Length];

        DetailImage = new Sprite[Resources.LoadAll<Sprite>("Apsan/Sprite/DetailImage").Length];
        MinimapLabel = new Sprite[Resources.LoadAll<Sprite>("Apsan/Sprite/Hotspot").Length];

        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("Apsan/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("Apsan/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("Apsan/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("Apsan/Narration/Japanese").Length];

        NaviLabel = Resources.LoadAll<Sprite>("Apsan/Sprite/NavigationLabel");
        MapLabel = Resources.LoadAll<Sprite>("Apsan/Sprite/MapLabel");

        DetailImage = Resources.LoadAll<Sprite>("Apsan/Sprite/DetailImage");
        MinimapLabel = Resources.LoadAll<Sprite>("Apsan/Sprite/Hotspot");

        CaptureMark = Resources.Load<Sprite>("Apsan/Sprite/CaptureMark");

        Narration_K = Resources.LoadAll<AudioClip>("Apsan/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("Apsan/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("Apsan/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("Apsan/Narration/Japanese");

        //WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/Video", "*.mp4");


        //GameManager.MainMode = "XRMode";
        //ClearMode.StartPosition = new Vector3(-8407, -870, -1631);
        //ClearMode.StartZoom = 0;
        //ClearMode.MaxZoomIn = 1851;
        //ClearMode.LabelMaxZoomIn = 970;
        //ClearMode.MaxZoomOut = -3369;
        //ClearMode.MinLabelSize = 1.0f;
        //ClearMode.MaxLabelSize = 5.5f;

    }
}
