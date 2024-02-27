using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class High1Label : MonoBehaviour
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
        Label_total = new List<string> { "MountainHub", "Shasta", "Betula", "Windy" };
        Label_Cate_1 = new List<string> { "Shasta", "Betula" };
        Label_Cate_2 = new List<string> { "MountainHub", "Windy" };

        NaviLabel_K = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_K").Length];
        NaviLabel_E = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_E").Length];
        NaviLabel_C = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_C").Length];
        NaviLabel_J = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_J").Length];
        DetailImage_K = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/DetailImage_K").Length];
        DetailImage_C = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/DetailImage_C").Length];
        DetailImage_J = new Sprite[Resources.LoadAll<Sprite>("High1/Sprite/DetailImage_J").Length];
        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("High1/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("High1/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("High1/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("High1/Narration/Japanese").Length];

        NaviLabel_K = Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_K");
        NaviLabel_E = Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_E");
        NaviLabel_C = Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_C");
        NaviLabel_J = Resources.LoadAll<Sprite>("High1/Sprite/NavigationLabel_J");

        DetailImage_K = Resources.LoadAll<Sprite>("High1/Sprite/DetailImage_K");
        DetailImage_C = Resources.LoadAll<Sprite>("High1/Sprite/DetailImage_C");
        DetailImage_J = Resources.LoadAll<Sprite>("High1/Sprite/DetailImage_J");
        
        Tip = Resources.Load<Sprite>("High1/Sprite/Tip");

        Narration_K = Resources.LoadAll<AudioClip>("High1/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("High1/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("High1/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("High1/Narration/Japanese");

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/High1/Video", "*.mp4");
            print(WaitingVideo_path.Length);
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            WaitingVideo_path = Directory.GetFiles(Application.dataPath + "/Resources/High1/Video", "*.mp4");
        }

        ModeActive = new bool[3];

        for (int index = 0; index < ModeActive.Length; index++)
        {
            ModeActive[index] = true;
        }
    }
}
