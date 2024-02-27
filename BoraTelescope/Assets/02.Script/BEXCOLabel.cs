using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class BEXCOLabel : MonoBehaviour
{
    public static  string ContentsVersion = "1.10.5";

    public static List<string> Label_total;
    public static List<string> Label_Cate_1;
    public static List<string> Label_Cate_2;

    public static Sprite[] NaviLabel;
    public static Sprite[] NaviLabel_K;
    public static Sprite[] NaviLabel_E;
    public static Sprite[] NaviLabel_C;
    public static Sprite[] NaviLabel_J;
    public static Sprite[] DetailImage_K;
    public static Sprite[] DetailImage_E;
    public static Sprite[] DetailImage_C;
    public static Sprite[] DetailImage_J;
    public static Sprite[] DetailText_K;
    public static Sprite[] DetailText_E;
    public static Sprite[] DetailText_C;
    public static Sprite[] DetailText_J;

    public static AudioClip[] Narration_K;
    public static AudioClip[] Narration_E;
    public static AudioClip[] Narration_C;
    public static AudioClip[] Narration_J;

    public static VideoClip[] WaitingVideo;
    public static string[] WaitingVideo_path;

    public static bool[] ModeActive;

    public static void LoadLabelInfo()
    {
        Label_total = new List<string> {"JangSan", "Beach", "BEXCO", "Port", "City", "Island", "Bridge"};
        Label_Cate_1 = new List<string> { "JangSan", "Island"};
        Label_Cate_2 = new List<string> { "Beach", "BEXCO", "Port", "City", "Bridge"};

        NaviLabel_K = new Sprite[Resources.LoadAll<Sprite>("BEXCO/Sprite/Bora UI_BEXCO_NaviLabel_K").Length];
        NaviLabel_E = new Sprite[Resources.LoadAll<Sprite>("BEXCO/Sprite/Bora UI_BEXCO_NaviLabel_E").Length];

        DetailImage_K = new Sprite[Resources.LoadAll<Sprite>("BEXCO/Sprite/Bora UI_BEXCO_Detail").Length];

        DetailText_K = new Sprite[Resources.LoadAll<Sprite>("BEXCO/Sprite/DetailText_K").Length];
        DetailText_E = new Sprite[Resources.LoadAll<Sprite>("BEXCO/Sprite/DetailText_E").Length];

        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("BEXCO/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("BEXCO/Narration/English").Length];

        NaviLabel_K = Resources.LoadAll<Sprite>("BEXCO/Sprite/Bora UI_BEXCO_NaviLabel_K");
        NaviLabel_E = Resources.LoadAll<Sprite>("BEXCO/Sprite/Bora UI_BEXCO_NaviLabel_E");

        DetailImage_K = Resources.LoadAll<Sprite>("BEXCO/Sprite/Bora UI_BEXCO_Detail");

        DetailText_K = Resources.LoadAll<Sprite>("BEXCO/Sprite/DetailText_K");
        DetailText_E = Resources.LoadAll<Sprite>("BEXCO/Sprite/DetailText_E");
        Narration_K = Resources.LoadAll<AudioClip>("BEXCO/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("BEXCO/Narration/English");
        
        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/BEXCO/Video", "*.mp4");
        //} else if (Application.platform == RuntimePlatform.WindowsPlayer)
        //{
        //    WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/Video", "*.mp4");
        //}

        ModeActive = new bool[4];
        for(int index = 0; index < ModeActive.Length; index++)
        {
            ModeActive[index] = true;
        }
    }
}
