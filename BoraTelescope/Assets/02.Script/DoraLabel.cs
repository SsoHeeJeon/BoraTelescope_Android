using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DoraLabel : MonoBehaviour
{
    public static  string ContentsVersion = "2.5.8";

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
    public static Sprite[] DetailText_K;
    public static Sprite[] DetailText_E;
    public static Sprite[] DetailText_C;
    public static Sprite[] DetailText_J;

    public static AudioClip[] Narration_K;
    public static AudioClip[] Narration_E;
    public static AudioClip[] Narration_C;
    public static AudioClip[] Narration_J;

    public static VideoClip[] WaitingVideo;

    public static bool[] ModeActive;

    public static void LoadLabelInfo()
    {
        Label_total = new List<string> {"PyongYang", "Office", "GP1", "Otter", "JangDan", "GunJang", "Farm", "CheondeokMountain", "Lab", "Crane","Guard", "MDL", "Villiage", "SacheonBridge",
                                        "DeokmulMountain", "GP212", "Tunnel", "JinBong", "SNcommunication", "Factory", "PanmoonStation", "Transmission", "River", "Gary", "Gaeseoung", "Burreed",
                                        "Statues" , "SongakMountain", "Tongil", "Gijeongdong", "Northflag","Wcrane", "Peak", "Daeseoung", "Taegeukgi", "PanMoon", "GP2", "UNGP", "Geumgangsan", "Baekdu"};
        Label_Cate_1 = new List<string> {"Otter", "GunJang", "CheondeokMountain", "Crane","DeokmulMountain", "JinBong", "River", "Gary", "Burreed", "SongakMountain", "Wcrane", "Peak", "Geumgangsan", "Baekdu"};
        Label_Cate_2 = new List<string> {"PyongYang", "Office", "GP1", "JangDan", "Farm", "Lab", "Guard", "MDL", "Villiage", "SacheonBridge",
                                        "GP212", "Tunnel", "SNcommunication", "Factory", "PanmoonStation", "Transmission", "Gaeseoung",
                                        "Statues" , "Tongil", "Gijeongdong", "Northflag", "Daeseoung", "Taegeukgi", "PanMoon", "GP2", "UNGP"};

        NaviLabel_K = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_K").Length];
        NaviLabel_E = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_E").Length];
        NaviLabel_C = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_C").Length];
        NaviLabel_J = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_J").Length];
        DetailImage_K = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailImage_K").Length];
        DetailImage_C = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailImage_C").Length];
        DetailImage_J = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailImage_J").Length];
        DetailText_K = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_K").Length];
        DetailText_E = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_E").Length];
        DetailText_C = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_C").Length];
        DetailText_J = new Sprite[Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_J").Length];
        Narration_K = new AudioClip[Resources.LoadAll<AudioClip>("Dora/Narration/Korea").Length];
        Narration_E = new AudioClip[Resources.LoadAll<AudioClip>("Dora/Narration/English").Length];
        Narration_C = new AudioClip[Resources.LoadAll<AudioClip>("Dora/Narration/Chinese").Length];
        Narration_J = new AudioClip[Resources.LoadAll<AudioClip>("Dora/Narration/Japanese").Length];

        NaviLabel_K = Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_K");
        NaviLabel_E = Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_E");
        NaviLabel_C = Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_C");
        NaviLabel_J = Resources.LoadAll<Sprite>("Dora/Sprite/NavigationLabel_J");

        DetailImage_K = Resources.LoadAll<Sprite>("Dora/Sprite/DetailImage_K");
        DetailImage_C = Resources.LoadAll<Sprite>("Dora/Sprite/DetailImage_C");
        DetailImage_J = Resources.LoadAll<Sprite>("Dora/Sprite/DetailImage_J");

        DetailText_K = Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_K");
        DetailText_E = Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_E");
        DetailText_C = Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_C");
        DetailText_J = Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_J");

        print(DetailText_K.Length);

        /*
        for (int index = 0; index < DetailText_K.Length; index++)
        {
            if (index < Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_K_1").Length)
            {
                Sprite[] sprites = Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_K_1");
                for (int sindex = 0; sindex < sprites.Length; sindex++)
                {
                    if (index == sindex)
                    {
                        DetailText_K[index] = sprites[sindex];
                    }
                }
            }
            else if (index >= Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_K_1").Length)
            {
                Sprite[] sprites = Resources.LoadAll<Sprite>("Dora/Sprite/DetailText_K_2");
                for (int sindex = 0; sindex < sprites.Length; sindex++)
                {
                    if (index - sprites.Length - 1 == sindex)
                    {
                        DetailText_K[index] = sprites[sindex];
                    }
                }
            }
        }
        */

        Narration_K = Resources.LoadAll<AudioClip>("Dora/Narration/Korea");
        Narration_E = Resources.LoadAll<AudioClip>("Dora/Narration/English");
        Narration_C = Resources.LoadAll<AudioClip>("Dora/Narration/Chinese");
        Narration_J = Resources.LoadAll<AudioClip>("Dora/Narration/Japanese");

        WaitingVideo = Resources.LoadAll<VideoClip>("Dora/Video");

        ModeActive = new bool[4];
        
        for(int index = 0; index < ModeActive.Length; index++)
        {
            ModeActive[index] = true;
        }
    }
}
