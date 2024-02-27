using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LabelMake : MonoBehaviour
{
    public GameManager gamemanager;

    public List<Image> MapLabel_Icon = new List<Image>();
    public List<Text> Navilabel_Text = new List<Text>();
    public List<Image> Navilabel_Icon = new List<Image>();
    public List<Text> XR_MapLabel = new List<Text>();
    public List<Text> Clear_MapLabel = new List<Text>();

    public static int fontSize_Quick = 24;
    public static int fontSize_QuickLong = 22;
    public static int fontSize_Label = 22;
    public static int fontSize_LabelLong = 20;

    public static int LabelSize_x = 156;
    public static int LabelLongSize_x = 188;
    public static int LabelTSize_x = 108;
    public static int LabelLongTSize_x = 124;
    public static int LabelSize_y = 40;
    public static int LabelMidSize_y = 44;
    public static int LabelLongSize_y = 48;
    public static int ClearLabelSize_y = 100;
    public static int ClearLabelMidSize_y = 104;
    public static int ClearLabelLongSize_y = 108;
    public static int Icon_x = 0;
    public static int IconMid_x = 2;
    public static int IconLong_x = 4;

    public Font font_KE;
    public Font font_CJ;
    public Font Labelfont_KE;
    public Font Labelfont_CJ;

    // Start is called before the first frame update
    public void ReadytoStart()
    {
        Clear_MapLabel.Clear();
        MapLabel_Icon.Clear();
        for (int index = 0; index < gamemanager.clearMode.AllMapLabels.transform.childCount; index++)
        {
            if(Contentsinfo.ContentsName == "Apsan")
            {
                Clear_MapLabel.Add(gamemanager.clearMode.AllMapLabels.transform.GetChild(index).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>());
                MapLabel_Icon.Add(gamemanager.clearMode.AllMapLabels.transform.GetChild(index).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>());
            }
            else if(Contentsinfo.ContentsName == "Aegibong")
            {
                Clear_MapLabel.Add(gamemanager.clearMode.AllMapLabels.transform.GetChild(index).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>());
                MapLabel_Icon.Add(gamemanager.clearMode.AllMapLabels.transform.GetChild(index).gameObject.transform.GetChild(2).gameObject.GetComponent<Image>());
            }
        }  
    }

    public void MapLabel()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            for (int index = 0; index < gamemanager.clearMode.AllMapLabels.transform.childCount; index++)
            {
                for (int indexs = 0; indexs < gamemanager.Label_total.Count; indexs++)
                {
                    if (gamemanager.clearMode.AllMapLabels.transform.GetChild(index).gameObject.name == gamemanager.Label_total[indexs])
                    {
                        MapLabel_Icon[index].sprite = gamemanager.MapLabel[index];
                        switch (GameManager.langstate)
                        {
                            case GameManager.LangState.Korea:
                                Clear_MapLabel[index].font = Labelfont_KE;
                                Clear_MapLabel[index].text = gamemanager.LabelName_K[indexs];

                                Clear_MapLabel[index].gameObject.transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(156, 100);
                                Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 40);

                                if (gamemanager.LabelName_K[indexs].Length <= 5)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_Label;
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                }
                                else if (gamemanager.LabelName_K[indexs].Length <= 10 && gamemanager.LabelName_K[indexs].Length > 5)
                                {
                                    if (gamemanager.LabelName_K[indexs].Length <= 7)
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_LabelLong;
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                    }
                                    else
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_LabelLong;
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconMid_x, 100 - IconMid_x);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelMidSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelMidSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelMidSize_y);
                                    }
                                }
                                else if (gamemanager.LabelName_K[indexs].Length > 10)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong;
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x, LabelLongSize_y);
                                }
                                Clear_MapLabel[index].fontStyle = FontStyle.Normal;
                                Clear_MapLabel[index].lineSpacing = 0.8f;
                                break;
                            case GameManager.LangState.English:
                                Clear_MapLabel[index].font = Labelfont_KE;
                                Clear_MapLabel[index].text = gamemanager.LabelName_E[indexs];
                                Debug.Log(gamemanager.LabelName_E[indexs] + " / " + gamemanager.LabelName_E[indexs].Length);    

                                Clear_MapLabel[index].gameObject.transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(156, 100);
                                Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 40);

                                if (gamemanager.LabelName_E[indexs].Length <= 10)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_Label - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                }
                                else if (gamemanager.LabelName_E[indexs].Length <= 16 && gamemanager.LabelName_E[indexs].Length > 10)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconMid_x, 100 - IconMid_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelMidSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelMidSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelMidSize_y);
                                }
                                else if (gamemanager.LabelName_E[indexs].Length <= 22 && gamemanager.LabelName_E[indexs].Length > 16)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x + 10, LabelLongSize_y);
                                }
                                else if (gamemanager.LabelName_E[indexs].Length > 22)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x + ((gamemanager.LabelName_E[indexs].Length + 1) * 2), ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x + ((gamemanager.LabelName_E[indexs].Length + 1) * 2), LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x + ((gamemanager.LabelName_E[indexs].Length + 1) * 2), LabelLongSize_y);

                                    if (Contentsinfo.ContentsName == "Aegibong" && Clear_MapLabel[index].gameObject.transform.parent.gameObject.name == "Daesungdong")
                                    {
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(193, LabelLongSize_y);
                                    }
                                }
                                Clear_MapLabel[index].fontStyle = FontStyle.Normal;
                                Clear_MapLabel[index].lineSpacing = 0.8f;
                                break;
                            case GameManager.LangState.Chienses:
                                Clear_MapLabel[index].font = Labelfont_CJ;
                                Clear_MapLabel[index].text = gamemanager.LabelName_C[indexs];

                                Debug.Log(gamemanager.LabelName_C[indexs] + " / " + gamemanager.LabelName_C[indexs].Length);

                                Clear_MapLabel[index].gameObject.transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(156, 100);
                                Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 40);

                                if (gamemanager.LabelName_C[indexs].Length <= 5)
                                {
                                    if (gamemanager.LabelName_C[indexs].Length < 5)
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_Label;
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                    }
                                    else
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_Label - 2;
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                    }
                                }
                                else if (gamemanager.LabelName_C[indexs].Length <= 9 && gamemanager.LabelName_C[indexs].Length > 5)
                                {
                                    if (gamemanager.LabelName_C[indexs].Length <= 7)
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconMid_x, 100 - IconMid_x);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelMidSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelMidSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelMidSize_y);
                                    }
                                    else
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_LabelLong;
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconMid_x, 100);
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconMid_x, 100 - IconMid_x);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, ClearLabelMidSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, LabelMidSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x, LabelMidSize_y);

                                        if (Contentsinfo.ContentsName == "Aegibong" && (Clear_MapLabel[index].gameObject.transform.parent.gameObject.name == "Daesungdong" || Clear_MapLabel[index].gameObject.transform.parent.gameObject.name == "Gijungdong"))
                                        {
                                            Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                        }
                                    }
                                }
                                else if (gamemanager.LabelName_C[indexs].Length <= 16 && gamemanager.LabelName_C[indexs].Length > 9)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x + 10, LabelLongSize_y);
                                }
                                else if (gamemanager.LabelName_C[indexs].Length > 16)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x + (gamemanager.LabelName_C[indexs].Length * 2), ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x + (gamemanager.LabelName_C[indexs].Length * 2), LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x + (gamemanager.LabelName_C[indexs].Length * 2), LabelLongSize_y);
                                }
                                Clear_MapLabel[index].fontStyle = FontStyle.Bold;
                                Clear_MapLabel[index].lineSpacing = 0.7f;
                                break;
                            case GameManager.LangState.Japan:
                                Clear_MapLabel[index].font = Labelfont_CJ;
                                Clear_MapLabel[index].text = gamemanager.LabelName_J[indexs];

                                Debug.Log(gamemanager.LabelName_J[indexs] + " / " + gamemanager.LabelName_J[indexs].Length);

                                Clear_MapLabel[index].gameObject.transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(156, 100);
                                Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 40);

                                if (gamemanager.LabelName_J[indexs].Length <= 5)
                                {
                                    if (gamemanager.LabelName_J[indexs].Length < 5)
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_Label;
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                    }
                                    else
                                    {
                                        Clear_MapLabel[index].fontSize = fontSize_Label - 2;
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                        MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + Icon_x, 100 - Icon_x);
                                        Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelSize_y);
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelSize_y);
                                    }
                                }
                                else if (gamemanager.LabelName_J[indexs].Length <= 8 && gamemanager.LabelName_J[indexs].Length > 5)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + Icon_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconMid_x, 100 - IconMid_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, ClearLabelMidSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelSize_x, LabelMidSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelTSize_x, LabelMidSize_y);
                                }
                                else if (gamemanager.LabelName_J[indexs].Length <= 12 && gamemanager.LabelName_J[indexs].Length > 8)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x, LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x + 10, LabelLongSize_y);
                                }
                                else if (gamemanager.LabelName_J[indexs].Length > 12)
                                {
                                    Clear_MapLabel[index].fontSize = fontSize_LabelLong - 2;
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-36 + IconLong_x, 100);
                                    MapLabel_Icon[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-78 + IconLong_x, 100 - IconLong_x);
                                    Clear_MapLabel[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x + (gamemanager.LabelName_J[indexs].Length * 2), ClearLabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.parent.GetChild(0).gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongSize_x + (gamemanager.LabelName_J[indexs].Length * 2), LabelLongSize_y);
                                    Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelLongTSize_x + (gamemanager.LabelName_J[indexs].Length * 2), LabelLongSize_y);
                                    if (Contentsinfo.ContentsName == "Aegibong" && Clear_MapLabel[index].gameObject.transform.parent.gameObject.name == "Gijungdong")
                                    {
                                        Clear_MapLabel[index].fontSize = 16;
                                    }
                                    else if (Contentsinfo.ContentsName == "Aegibong" && Clear_MapLabel[index].gameObject.transform.parent.gameObject.name == "Daesungdong")
                                    {
                                        Clear_MapLabel[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(164, LabelLongSize_y);
                                    }
                                }                       
                                Clear_MapLabel[index].fontStyle = FontStyle.Bold;
                                Clear_MapLabel[index].lineSpacing = 0.7f;
                                break;
                        }
                        Clear_MapLabel[index].alignment = TextAnchor.MiddleCenter;
                    }
                }
            }
        }

        if(Contentsinfo.ContentsName == "Aegibong")
        {
            gamemanager.clearMode.disablelabel.MapLabel();
        }
    }

    public void NavigationText()
    {
        for (int index = 0; index < Navilabel_Text.Count; index++)
        {
            for (int indexs = 0; indexs < gamemanager.Label_total.Count; indexs++)
            {
                if (Navilabel_Text[index].gameObject.transform.parent.gameObject.name == gamemanager.Label_total[indexs])
                {
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Navilabel_Text[index].font = font_KE;
                            Navilabel_Text[index].lineSpacing = 1;
                            if (gamemanager.LabelName_K[indexs].Length <= 18)
                            {
                                Navilabel_Text[index].fontSize = fontSize_Quick;
                            }
                            else if (gamemanager.LabelName_K[indexs].Length > 18)
                            {
                                Navilabel_Text[index].fontSize = fontSize_LabelLong;
                            }
                            break;
                        case GameManager.LangState.English:
                            Navilabel_Text[index].font = font_KE;
                            Navilabel_Text[index].lineSpacing = 1;
                            if (gamemanager.LabelName_E[indexs].Length <= 18)
                            {
                                Navilabel_Text[index].fontSize = fontSize_Quick;
                            }
                            else if (gamemanager.LabelName_E[indexs].Length > 18)
                            {
                                Navilabel_Text[index].fontSize = fontSize_Quick;
                            }
                            break;
                        case GameManager.LangState.Chienses:
                            Navilabel_Text[index].font = font_CJ;
                            Navilabel_Text[index].lineSpacing = 1;
                            if (gamemanager.LabelName_C[indexs].Length <= 20)
                            {
                                Navilabel_Text[index].fontSize = fontSize_Quick;
                            }
                            else if (gamemanager.LabelName_C[indexs].Length > 20)
                            {
                                Navilabel_Text[index].fontSize = fontSize_Quick;
                            }
                            break;
                        case GameManager.LangState.Japan:
                            Navilabel_Text[index].font = font_CJ;

                            Navilabel_Text[index].lineSpacing = 0.7f;
                            if (gamemanager.LabelName_J[indexs].Length <= 20)
                            {
                                Navilabel_Text[index].fontSize = fontSize_Quick;
                            }
                            else if (gamemanager.LabelName_J[indexs].Length > 20)
                            {
                                Navilabel_Text[index].fontSize = fontSize_QuickLong;
                            }
                            break;
                    }
                }
            }
        }
    }

    public void NavigationTextObj(Text txt)
    {
        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                txt.font = font_KE;
                txt.lineSpacing = 1;
                if (txt.text.Length <= 18)
                {
                    txt.fontSize = fontSize_Quick;
                }
                else if (txt.text.Length > 18)
                {
                    txt.fontSize = fontSize_LabelLong;
                }
                break;
            case GameManager.LangState.English:
                txt.font = font_KE;
                txt.lineSpacing = 1;
                if (txt.text.Length <= 18)
                {
                    txt.fontSize = fontSize_Quick;
                }
                else if (txt.text.Length > 18)
                {
                    txt.fontSize = fontSize_Quick; ;
                }
                break;
            case GameManager.LangState.Chienses:

                txt.font = font_CJ;
                txt.lineSpacing = 1;
                if (txt.text.Length <= 20)
                {
                    txt.fontSize = fontSize_Quick;
                }
                else if (txt.text.Length > 20)
                {
                    txt.fontSize = fontSize_Quick; ;
                }
                break;
            case GameManager.LangState.Japan:

                txt.font = font_CJ;
                txt.lineSpacing = 0.7f;
                if (txt.text.Length <= 20)
                {
                    txt.fontSize = fontSize_Quick;
                }
                else if (txt.text.Length > 20)
                {
                    txt.fontSize = fontSize_QuickLong; ;
                }
                break;
        }
    }
}
