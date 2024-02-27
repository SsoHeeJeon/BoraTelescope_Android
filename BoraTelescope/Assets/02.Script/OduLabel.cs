using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class OduLabel : MonoBehaviour
{
    //public static string ContentsVersion = "2.5.8";

    public static List<string> Label_total;
    public static List<string> Label_Cate_1;
    public static List<string> Label_Cate_2;

    public static Sprite[] NaviLabel;
    public static Sprite[] NaviLabel_K;
    public static Sprite[] NaviLabel_E;
    public static Sprite[] NaviLabel_C;
    public static Sprite[] NaviLabel_J;
    public static Sprite[] DetailImage_K;
    public static Sprite[] DetailImage_C;
    public static Sprite[] DetailImage_J;
    public static Sprite Tip;

    public static AudioClip[] Narration_K;
    public static AudioClip[] Narration_E;
    public static AudioClip[] Narration_C;
    public static AudioClip[] Narration_J;

    public static VideoClip[] WaitingVideo;
    public static string[] WaitingVideo_path;

    public static bool[] ModeActive;

    public static void LoadLabelInfo()
    {
        Label_total = new List<string> {"Aegibong", "JoR", "Saeholligi", "TurtleShip", "Crane", "Pep", "Ganghaw", "Seoglyupo", "HanR", "Weasel",
                                        "Gary", "Solnari", "Goose", "NorthGP", "Otter", "Gwansan", "Thresher", "Historic", "Center", "School",
                                        "Duksu", "Imhan", "House", "Goshawk", "Dokminari", "Songak", "Manwol", "Yuni", "GunJang", "Broadcast", "Eagle",
                                        "Wcrane", "Gijeong", "ImjinR", "SacheonR", "Panmoon", "Daeseoung", "Joleum", "Dora"};
        Label_Cate_1 = new List<string> {"JoR", "Saeholligi", "Crane", "Pep", "Weasel", "Gary", "Solnari", "Goose", "Otter", "Duksu",
                                         "Goshawk", "Dokminari", "Songak", "Yuni", "GunJang", "Eagle", "Wcrane", "ImjinR", "SacheonR", "Joleum"};
        Label_Cate_2 = new List<string> {"Aegibong", "TurtleShip", "Ganghaw", "Seoglyupo", "HanR", "NorthGP", "Gwansan", "Thresher", "Historic", "Center",
                                         "School", "Imhan", "House", "Manwol", "Broadcast", "Gijeong", "Panmoon", "Daeseoung", "Dora"};

        NaviLabel_K = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_K").Length];
        NaviLabel_E = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_E").Length];
        NaviLabel_C = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_C").Length];
        NaviLabel_J = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_J").Length];
        DetailImage_K = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/DetailImage_K").Length];
        DetailImage_C = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/DetailImage_C").Length];
        DetailImage_J = new Sprite[Resources.LoadAll<Sprite>("Odu/Sprite/DetailImage_J").Length];
        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("Odu/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("Odu/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("Odu/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("Odu/Narration/Japanese").Length];

        NaviLabel_K = Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_K");
        NaviLabel_E = Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_E");
        NaviLabel_C = Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_C");
        NaviLabel_J = Resources.LoadAll<Sprite>("Odu/Sprite/NavigationLabel_J");

        DetailImage_K = Resources.LoadAll<Sprite>("Odu/Sprite/DetailImage_K");
        DetailImage_C = Resources.LoadAll<Sprite>("Odu/Sprite/DetailImage_C");
        DetailImage_J = Resources.LoadAll<Sprite>("Odu/Sprite/DetailImage_J");
        
        Tip = Resources.Load<Sprite>("Odu/Sprite/Tip");

        Narration_K = Resources.LoadAll<AudioClip>("Odu/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("Odu/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("Odu/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("Odu/Narration/Japanese");

        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/Odu/Video", "*.mp4");
        //}
        //else if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/Video", "*.mp4");
        //}

        ModeActive = new bool[4];

        for (int index = 0; index < ModeActive.Length; index++)
        {
            ModeActive[index] = true;
        }

        See360Lotte.Past70 = Resources.Load<Sprite>("Lotte/Sprite/360/Past70");
        See360Lotte.Past80 = Resources.Load<Sprite>("Lotte/Sprite/360/Past80");
        See360Lotte.Current = Resources.Load<Sprite>("Lotte/Sprite/360/Current");
        See360Lotte.DisVideo = Directory.GetFiles(Application.dataPath + "/Resources/Lotte/Sprite/360/Dissolve/", "*.mp4");

        for (int index = 0; index < See360Lotte.DisVideo.Length; index++)
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
