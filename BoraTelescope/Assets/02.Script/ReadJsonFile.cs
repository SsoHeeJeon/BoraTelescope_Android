using Amazon.ElasticMapReduce;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ReadJsonFile : MonoBehaviour
{
    public GameManager gamemanager;
    string Allstr;
    public static string RangePT;
    public static string[] allstr_json;

    string Allstr_rec;
    string GetText;
    public string[] GOTEXT_arr;

    public static List<string> DetailText_K = new List<string>();
    public static List<string> DetailText_E = new List<string>();
    public static List<string> DetailText_C = new List<string>();
    public static List<string> DetailText_J = new List<string>();

    public float MinPan;
    public float MaxPan;
    public float MinTilt;
    public float MaxTilt;
    public float TotalPan;
    public float TotalTilt;
    public uint StartX;
    public uint StartY;

    public List<Vector2> XRModeLabel = new List<Vector2>();

    private void Start()
    {
        Readfile();
    }

    public void Readfile()
    {
        string filepath = null;
        DetailText_K.Clear();
        DetailText_E.Clear();
        DetailText_C.Clear();
        DetailText_J.Clear();
        if (Contentsinfo.ContentsName != "Normal")
        {
            if (!(Contentsinfo.ContentsName == "Demo" || Contentsinfo.ContentsName == "Dora"))
            //if (!(ContentsInfo.ContentsName == "Dora"))
            {
                //Allstr_rec = File.ReadAllText(Application.streamingAssetsPath + ("/DetailText_" + ContentsInfo.ContentsName + ".json"), System.Text.Encoding.UTF8);
                TextAsset targetfile = Resources.Load<TextAsset>(Contentsinfo.ContentsName + "/Text/DetailText_" + Contentsinfo.ContentsName);

                Allstr_rec = targetfile.text;
                if (Allstr_rec.Contains("}"))
                {
                    GOTEXT_arr = Allstr_rec.Split('}');

                    for (int index = -1; index < GOTEXT_arr.Length - 1; index++)
                    {
                        if (index < GOTEXT_arr.Length - 2)
                        {
                            GOTEXT_arr[index + 1] = GOTEXT_arr[index + 1] + "}";
                        }
                        else if (index == GOTEXT_arr.Length - 2)
                        {
                            GetText = GOTEXT_arr[index];
                        }
                    }
                }
                for (int index = 0; index < GOTEXT_arr.Length - 1; index++)
                {
                    GOTEXT_arr[index] = GOTEXT_arr[index].Replace("\r\n", string.Empty);
                    //GOTEXT_arr[index] = GOTEXT_arr[index].Replace(" ","");
                    LabelText pantilt = JsonUtility.FromJson<LabelText>(GOTEXT_arr[index]);
                    DetailText_K.Add(pantilt.Korean);
                    DetailText_E.Add(pantilt.English);
                    DetailText_C.Add(pantilt.Chinese);
                    DetailText_J.Add(pantilt.Japanese);
                    gamemanager.LabelName_K.Add(pantilt.LabelName_K);
                    gamemanager.LabelName_E.Add(pantilt.LabelName_E);
                    gamemanager.LabelName_C.Add(pantilt.LabelName_C);
                    gamemanager.LabelName_J.Add(pantilt.LabelName_J);
                }
                gamemanager.DetailText_K = DetailText_K;
                gamemanager.DetailText_E = DetailText_E;
                gamemanager.DetailText_C = DetailText_C;
                gamemanager.DetailText_J = DetailText_J;

                //#if UNITY_EDITOR
                //#else
                //            filepath = Application.streamingAssetsPath +("/ARModeLabelPosition_" + "BEXCO" + ".json");
                //            UnityWebRequest www2 = UnityWebRequest.Get(filepath);
                //            www2.SendWebRequest();
                //            while(!www2.isDone)
                //            {

                //            }
                //            Allstr = www2.downloadHandler.text;
                //#endif
            }
        }
    }
}
