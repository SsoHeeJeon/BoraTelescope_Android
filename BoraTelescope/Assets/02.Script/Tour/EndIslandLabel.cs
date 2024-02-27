using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EndIslandLabel : MonoBehaviour
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
        Label_total = new List<string> { "SimchungH", "Wcrane", "Jangsan", "Seal", "Spoonbill",
                                         "Wolrae", "Nll"};
        Label_Cate_1 = new List<string> { "Wcrane", "Seal", "Spoonbill"};
        Label_Cate_2 = new List<string> { "SimchungH", "Jangsan", "Wolrae", "Nll"};

        Label_Minimap = new List<string> { "SimchungH", "Jangsan", "Wolrae" };

        DisableLabel.HiddenLabelList = new List<string> { "Airport", "Pyongyang", "Big", "Small", "Simchung"};
        DisableLabel.HiddenLabelPosition = new Vector3[5];

        TourismMode.TourList = new List<string> { "Island", "Dumujin", "Tower", "Nampori", "Dragon",
                                               "Kongdol", "Sagoj", "Dock", "Observation", "SealRock",
                                               "Simchung", "Lion"};

        NaviLabel = new Sprite[Resources.LoadAll<Sprite>("EndIsland/Sprite/NavigationLabel").Length];
        MapLabel = new Sprite[Resources.LoadAll<Sprite>("EndIsland/Sprite/MapLabel").Length];

        DetailImage = new Sprite[Resources.LoadAll<Sprite>("EndIsland/Sprite/DetailImage").Length];
        MinimapLabel = new Sprite[Resources.LoadAll<Sprite>("EndIsland/Sprite/Hotspot").Length];

        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("EndIsland/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("EndIsland/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("EndIsland/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("EndIsland/Narration/Japanese").Length];

        NaviLabel = Resources.LoadAll<Sprite>("EndIsland/Sprite/NavigationLabel");
        MapLabel = Resources.LoadAll<Sprite>("EndIsland/Sprite/MapLabel");

        DetailImage = Resources.LoadAll<Sprite>("EndIsland/Sprite/DetailImage");
        MinimapLabel = Resources.LoadAll<Sprite>("EndIsland/Sprite/Hotspot");

        CaptureMark = Resources.Load<Sprite>("EndIsland/Sprite/CaptureMark");

        Tip_K = Resources.Load<Sprite>("EndIsland/Sprite/Tip_K");
        Tip_E = Resources.Load<Sprite>("EndIsland/Sprite/Tip_E");
        Tip_C = Resources.Load<Sprite>("EndIsland/Sprite/Tip_C");
        Tip_J = Resources.Load<Sprite>("EndIsland/Sprite/Tip_J");

        Narration_K = Resources.LoadAll<AudioClip>("EndIsland/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("EndIsland/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("EndIsland/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("EndIsland/Narration/Japanese");

        //WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/Video", "*.mp4");


        //GameManager.MainMode = "XRMode";
        //ClearMode.StartPosition = new Vector3(-1705, -2744, -1631);
        //ClearMode.StartZoom = 200;
        //ClearMode.MaxZoomIn = 1851;
        //ClearMode.LabelMaxZoomIn = 1200;//970
        //ClearMode.MaxZoomOut = -100;
        //ClearMode.MinLabelSize = 1.0f;
        //ClearMode.MaxLabelSize = 3;//5.5f;

        //ModeActive = new bool[3];
    }
}
