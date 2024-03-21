using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DisablePosition
{
    public string LabelName;
    public float Label_X;
    public float Label_Y;

    public DisablePosition(string labelname, float label_x, float label_y)
    {
        LabelName = labelname;
        Label_X = label_x;
        Label_Y = label_y;
    }
}
public class DisableLabel : LabelName
{
    //json파일 불러오기
    // xrmanager에서 라벨위치 변경가능하게하기
    public GameManager gamemanager;

    public static List<string> HiddenLabelList = new List<string> { "River", "DogogaeM", "Old", "AmsilV", "Quarry", "New", "PromotionV", "Dora", "Gwansanpo", "Dolgoji", "HanR", "Paju" };
    public GameObject[] HiddenObj_s;
    public static GameObject[] HiddenObj;
    public static Vector3[] HiddenLabelPosition = new Vector3[6];
    public static string Allstr;
    public static string[] allstr_json;

    public static List<string> AllLabelPosition = new List<string>();
    public static string[] AllLabelPosition_arr;

    public GameObject[] DisableLabel_Obj;
    public List<Text> DisableLabel_text;

    public void MapLabel()
    {
        if (gamemanager == null)
        {
            gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        DisableLabel_text.Clear();
        for (int index = 0; index < DisableLabel_Obj.Length; index++)
        {
            if (DisableLabel_Obj[index].activeSelf)
            {
                HiddenObj_s = new GameObject[DisableLabel_Obj[index].transform.childCount];
                for (int indexs = 0; indexs < DisableLabel_Obj[index].transform.childCount; indexs++)
                {
                    DisableLabel_text.Add(DisableLabel_Obj[index].transform.GetChild(indexs).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>());
                    HiddenObj_s[indexs] = DisableLabel_Obj[index].transform.GetChild(indexs).gameObject;
                }
                break;
            }
        }

        for (int index = 0; index < DisableLabel_text.Count; index++)
        {
            for (int indexs = 0; indexs < HiddenLabelList.Count; indexs++)
            {
                if (DisableLabel_text[index].gameObject.transform.parent.gameObject.name == HiddenLabelList[indexs])
                {
                    DisableLabel_text[index].gameObject.transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(156, 40);
                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 40); 
                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36, 40);

                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            LabelLanguage(HiddenLabelList[indexs]);
                            DisableLabel_text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                            DisableLabel_text[index].text = Namelist;

                            if (Namelist.Length <= 5)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_Label;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                            }
                            else if (Namelist.Length <= 10 && Namelist.Length > 5)
                            {
                                if (HiddenLabelList[indexs] == "PromotionV")
                                {
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-26, 40);
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(201, LabelMake.LabelSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                                }
                                else
                                {
                                    if (Namelist.Length <= 7)
                                    {
                                        DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong;
                                        DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                        DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                                    }
                                    else
                                    {
                                        DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong;
                                        DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                        DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelMidSize_y);
                                    }
                                }
                            }
                            else if (Namelist.Length > 10)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x, LabelMake.LabelLongSize_y);
                            }
                            DisableLabel_text[index].lineSpacing = 0.8f;
                            DisableLabel_text[index].fontStyle = FontStyle.Normal;
                            break;
                        case GameManager.LangState.English:
                            LabelLanguage(HiddenLabelList[indexs]);
                            DisableLabel_text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                            DisableLabel_text[index].text = Namelist;
                            if (HiddenLabelList[indexs] == "PromotionV")
                            {
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-26, 40);
                            }
                            if (Namelist.Length <= 8)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_Label;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                            }
                            else if (Namelist.Length <= 16 && Namelist.Length > 8)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelMidSize_y);
                            }
                            else if (Namelist.Length <= 22 && Namelist.Length > 16)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + 10, LabelMake.LabelLongSize_y);
                            }
                            else if (Namelist.Length > 22)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x + (DisableLabel_text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + (DisableLabel_text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                            }
                            DisableLabel_text[index].lineSpacing = 0.8f;
                            DisableLabel_text[index].fontStyle = FontStyle.Normal;
                            break;
                        case GameManager.LangState.Chienses:
                            LabelLanguage(HiddenLabelList[indexs]);
                            DisableLabel_text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                            DisableLabel_text[index].text = Namelist;

                            if (Namelist.Length <= 5)
                            {
                                if (Namelist.Length < 5)
                                {
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_Label;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                                }
                                else
                                {
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_Label - 2;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                                }
                            }
                            else if (Namelist.Length <= 9 && Namelist.Length > 5)
                            {
                                if (Namelist.Length <= 7)
                                {
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelMidSize_y);
                                }
                                else
                                {
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelMidSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x, LabelMake.LabelMidSize_y);
                                }
                            }
                            else if (Namelist.Length <= 16 && Namelist.Length > 9)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + 10, LabelMake.LabelLongSize_y);
                            }
                            else if (Namelist.Length > 16)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x + (DisableLabel_text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + (DisableLabel_text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                            }
                            DisableLabel_text[index].lineSpacing = 0.7f;
                            DisableLabel_text[index].fontStyle = FontStyle.Bold;
                            break;
                        case GameManager.LangState.Japan:
                            LabelLanguage(HiddenLabelList[indexs]);
                            DisableLabel_text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                            DisableLabel_text[index].text = Namelist;

                            if (Namelist.Length <= 5)
                            {
                                if (Namelist.Length < 5)
                                {
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_Label;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                                }
                                else
                                {
                                    DisableLabel_text[index].fontSize = LabelMake.fontSize_Label - 2;
                                    DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelSize_y);
                                }
                            }
                            else if (Namelist.Length <= 8 && Namelist.Length > 5)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelTSize_x, LabelMake.LabelMidSize_y);
                            }
                            else if (Namelist.Length <= 12 && Namelist.Length > 8)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + 10, LabelMake.LabelLongSize_y);
                            }
                            else if (Namelist.Length > 12)
                            {
                                DisableLabel_text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                DisableLabel_text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x + (DisableLabel_text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                                DisableLabel_text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + (DisableLabel_text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                            }
                            DisableLabel_text[index].lineSpacing = 0.7f;
                            DisableLabel_text[index].fontStyle = FontStyle.Bold;
                            break;
                    }
                    DisableLabel_text[index].alignment = TextAnchor.MiddleCenter;
                }
            }
        }

    }
}
