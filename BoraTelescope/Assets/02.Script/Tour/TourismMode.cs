using Amazon.CloudWatchEvidently.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TourismMode : LabelName
{
    public GameManager gamemanager;

    public static List<string> TourList;
    public List<GameObject> TourLabel_list = new List<GameObject>();
    public List<Text> TourLabel_Text;

    // Start is called before the first frame update
    void Start()
    {
        //gamemanager.WriteLog(LogSendServer.NormalLogCode.ChangeMode, "ChangeMode : Finish(" + GameManager.PrevMode + " - " + "TourismMode)", GetType().ToString());
        //GameManager.PrevMode = "TourismMode";
        gamemanager.tourismode = this;
    }

    public void UISetting()
    {
        switch (Contentsinfo.ContentsName)
        {
            case "EndIsland":
                //clearmode = GameObject.FindGameObjectWithTag("ClearMode").GetComponent<ClearMode>();
                //gamemanager.labeldetail = clearmode.GetComponent<LabelDetail>();
                gamemanager.UI_All.gameObject.SetActive(true);
                for (int index = 0; index < gamemanager.UI_All.transform.childCount; index++)
                {
                    gamemanager.UI_All.transform.GetChild(index).gameObject.SetActive(false);
                }
                gamemanager.MenuBar.SetActive(true);
                if (GameManager.AnyError == true)
                {
                    gamemanager.MenuBar.gameObject.GetComponent<Image>().enabled = true;
                    for (int index = 0; index < gamemanager.MenuBar.gameObject.transform.childCount; index++)
                    {
                        gamemanager.MenuBar.transform.GetChild(index).gameObject.SetActive(true);
                    }
                }
                gamemanager.Arrow.SetActive(false);
                gamemanager.NavigationBar.gameObject.SetActive(false);
                gamemanager.LanguageBar.gameObject.SetActive(true);
                gamemanager.NavigationBar.transform.GetChild(0).gameObject.SetActive(true);
                gamemanager.MiniMap_Background.transform.parent.gameObject.SetActive(false);
                gamemanager.MiniMap_Background.gameObject.SetActive(false);
                gamemanager.Zoombtn.gameObject.SetActive(false);
                gamemanager.ErrorMessage.transform.parent.gameObject.SetActive(true);

                for (int index = 0; index < gamemanager.MenuBar.transform.GetChild(0).transform.childCount; index++)
                {
                    if (gamemanager.MenuBar.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform.childCount != 0)
                    {
                        gamemanager.MenuBar.transform.GetChild(0).gameObject.transform.GetChild(index).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
                for (int index = 0; index < gamemanager.MenuBar.transform.GetChild(1).transform.childCount; index++)
                {
                    if (gamemanager.MenuBar.transform.GetChild(1).GetChild(index).gameObject.activeSelf)
                    {
                        if (gamemanager.MenuBar.transform.GetChild(1).gameObject.transform.GetChild(index).gameObject.transform.childCount != 0)
                        {
                            gamemanager.MenuBar.transform.GetChild(1).gameObject.transform.GetChild(index).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
                }
                gamemanager.MenuBar.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gamemanager.navibarstate = GameManager.NavibarState.Opening;
                gamemanager.Homebtn.SetActive(false);
                break;
        }
    }

    
    public void MapLabel()
    {
        if (gamemanager == null)
        {
            gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        TourLabel_Text.Clear();
        for (int index = 0; index < TourLabel_list.Count-1; index++)
        {
            if (TourLabel_list[index].activeSelf)
            {
                TourLabel_Text.Add(TourLabel_list[index].transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>());
            }
        }
        print("TourLabel_Text.Count = " + TourLabel_Text.Count);
        for (int index = 0; index < TourLabel_Text.Count; index++)
        {
            for (int indexs = 0; indexs < TourList.Count; indexs++)
            {
                if (TourLabel_Text[index].gameObject.transform.parent.parent.gameObject.name == TourList[indexs])
                {
                    TourLabel_Text[index].gameObject.transform.parent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(156, 40);
                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, 40);
                    if(TourLabel_Text[index].gameObject.name.Contains("1"))
                    {
                        TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    }
                    else
                    {
                        TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(32, 0);
                    }

                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            //TourLabelLanguage(TourList[indexs]);
                            TourLabel_Text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                            TourLabel_Text[index].text = gamemanager.LabelName_K[index];
                            print(1);
                            if (TourLabel_Text[index].text.Length <= 5)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_Label;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length <= 10 && TourLabel_Text[index].text.Length > 5)
                            {
                                if (TourList[indexs] == "PromotionV")
                                {
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-26, 40);
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(201, LabelMake.LabelSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                                }
                                else
                                {
                                    if (TourLabel_Text[index].text.Length <= 7)
                                    {
                                        TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong;
                                        TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                        TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                                    }
                                    else
                                    {
                                        TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong;
                                        TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                        TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelMidSize_y);
                                    }
                                }
                            }
                            else if (TourLabel_Text[index].text.Length > 10)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x, LabelMake.LabelLongSize_y);
                            }
                            TourLabel_Text[index].lineSpacing = 0.8f;
                            TourLabel_Text[index].fontStyle = FontStyle.Normal;
                            break;
                        case GameManager.LangState.English:
                            //TourLabelLanguage(TourList[indexs]);
                            TourLabel_Text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                            TourLabel_Text[index].text = gamemanager.LabelName_E[index];
                            if (TourList[indexs] == "PromotionV")
                            {
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().localPosition = new Vector2(-26, 40);
                            }
                            if (TourLabel_Text[index].text.Length <= 8)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_Label;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length <= 16 && TourLabel_Text[index].text.Length > 8)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelMidSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length <= 22 && TourLabel_Text[index].text.Length > 16)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + 10, LabelMake.LabelLongSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length > 22)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x + (TourLabel_Text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + (TourLabel_Text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                            }
                            TourLabel_Text[index].lineSpacing = 0.8f;
                            TourLabel_Text[index].fontStyle = FontStyle.Normal;
                            break;
                        case GameManager.LangState.Chienses:
                            //TourLabelLanguage(TourList[indexs]);
                            TourLabel_Text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                            TourLabel_Text[index].text = gamemanager.LabelName_C[index];

                            if (TourLabel_Text[index].text.Length <= 5)
                            {
                                if (TourLabel_Text[index].text.Length < 5)
                                {
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_Label;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                                }
                                else
                                {
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_Label - 2;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                                }
                            }
                            else if (TourLabel_Text[index].text.Length <= 9 && TourLabel_Text[index].text.Length > 5)
                            {
                                if (TourLabel_Text[index].text.Length <= 7)
                                {
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelMidSize_y);
                                }
                                else
                                {
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelMidSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x, LabelMake.LabelMidSize_y);
                                }
                            }
                            else if (TourLabel_Text[index].text.Length <= 16 && TourLabel_Text[index].text.Length > 9)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + 10, LabelMake.LabelLongSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length > 16)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x + (TourLabel_Text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + (TourLabel_Text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                            }
                            TourLabel_Text[index].lineSpacing = 0.7f;
                            TourLabel_Text[index].fontStyle = FontStyle.Bold;
                            break;
                        case GameManager.LangState.Japan:
                            //TourLabelLanguage(TourList[indexs]);
                            TourLabel_Text[index].font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                            TourLabel_Text[index].text = gamemanager.LabelName_J[index];

                            if (TourLabel_Text[index].text.Length <= 5)
                            {
                                if (TourLabel_Text[index].text.Length < 5)
                                {
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_Label;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                                }
                                else
                                {
                                    TourLabel_Text[index].fontSize = LabelMake.fontSize_Label - 2;
                                    TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelSize_y);
                                    TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelSize_y);
                                }
                            }
                            else if (TourLabel_Text[index].text.Length <= 8 && TourLabel_Text[index].text.Length > 5)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelSize_x, LabelMake.LabelMidSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(123, LabelMake.LabelMidSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length <= 12 && TourLabel_Text[index].text.Length > 8)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x, LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + 10, LabelMake.LabelLongSize_y);
                            }
                            else if (TourLabel_Text[index].text.Length > 12)
                            {
                                TourLabel_Text[index].fontSize = LabelMake.fontSize_LabelLong - 2;
                                TourLabel_Text[index].gameObject.transform.parent.gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongSize_x + (TourLabel_Text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                                TourLabel_Text[index].gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(LabelMake.LabelLongTSize_x + (TourLabel_Text[index].text.Length * 2), LabelMake.LabelLongSize_y);
                            }
                            TourLabel_Text[index].lineSpacing = 0.7f;
                            TourLabel_Text[index].fontStyle = FontStyle.Bold;
                            break;
                    }
                    TourLabel_Text[index].alignment = TextAnchor.MiddleCenter;
                }
            }
        }
        gamemanager.endisland_tour.FoodLang();
    }

    public void SelectLabel(string Label)
    {
        for (int index = 0; index < gamemanager.endisland_tour.Tourlist.Length; index++)
        {
            if (gamemanager.endisland_tour.Tourlist[index].name == Label)
            {
                gamemanager.endisland_tour.DetailImage.sprite = gamemanager.DetailImage_K[index];
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        gamemanager.endisland_tour.DetailTitleText.text = gamemanager.LabelName_K[index];
                        gamemanager.endisland_tour.DetailTitleText.fontSize = 30;
                        gamemanager.endisland_tour.DetailSubTitleText.text = gamemanager.LabelName_E[index];
                        gamemanager.endisland_tour.DetailTitleText.font = gamemanager.GetComponent<LabelMake>().font_KE;
                        gamemanager.endisland_tour.DetailSubTitleText.font = gamemanager.GetComponent<LabelMake>().font_KE;
                        if (gamemanager.endisland_tour.DetailSubTitleText.text.Length < 25)
                        {
                            gamemanager.endisland_tour.DetailSubTitleText.fontSize = 24;
                        }
                        else if (gamemanager.LabelName_K[index].Length >= 25)
                        {
                            gamemanager.endisland_tour.DetailSubTitleText.fontSize = 20;
                        }
                        gamemanager.endisland_tour.DetailText.text = gamemanager.DetailText_K[index];
                        gamemanager.ad.clip = gamemanager.Narration_K[index];
                        gamemanager.endisland_tour.DetailText.font = gamemanager.GetComponent<LabelMake>().font_KE;
                        break;
                    case GameManager.LangState.English:
                        gamemanager.endisland_tour.DetailTitleText.text = gamemanager.LabelName_E[index];
                        gamemanager.endisland_tour.DetailSubTitleText.text = gamemanager.LabelName_K[index];
                        gamemanager.endisland_tour.DetailSubTitleText.fontSize = 24;
                        //gamemanager.labeldetail.TitleDetail.font = gamemanager.label.Titlefont_KE;
                        //gamemanager.endisland_tour.SubTitleDetail.font = gamemanager.label.Titlefont_KE;
                        if (gamemanager.endisland_tour.DetailTitleText.text.Length < 25)
                        {
                            gamemanager.endisland_tour.DetailTitleText.fontSize = 30;
                        }
                        else if (gamemanager.LabelName_E[index].Length >= 25)
                        {
                            gamemanager.endisland_tour.DetailTitleText.fontSize = 26;
                        }

                        gamemanager.endisland_tour.DetailText.text = gamemanager.DetailText_E[index];
                        gamemanager.ad.clip = gamemanager.Narration_E[index];
                        //gamemanager.labeldetail.InfoHeight.GetComponent<Text>().font = gamemanager.label.Detailfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        gamemanager.endisland_tour.DetailTitleText.text = gamemanager.LabelName_C[index];
                        gamemanager.endisland_tour.DetailTitleText.fontSize = 30;
                        gamemanager.endisland_tour.DetailSubTitleText.text = gamemanager.LabelName_E[index];
                        //gamemanager.labeldetail.TitleDetail.font = gamemanager.label.Titlefont_CJ;
                        //gamemanager.labeldetail.SubTitleDetail.font = gamemanager.label.Titlefont_KE;
                        if (gamemanager.DetailText_E[index].Length < 25)
                        {
                             gamemanager.endisland_tour.DetailSubTitleText.fontSize = 24;
                        }
                        else if (gamemanager.DetailText_E[index].Length >= 25)
                        {
                            gamemanager.endisland_tour.DetailSubTitleText.fontSize = 20;
                        }
                        gamemanager.endisland_tour.DetailText.text = gamemanager.DetailText_C[index];
                        gamemanager.ad.clip = gamemanager.Narration_C[index];
                        //gamemanager.labeldetail.InfoHeight.GetComponent<Text>().font = gamemanager.label.Detailfont_CJ;
                        break;  
                    case GameManager.LangState.Japan:
                        gamemanager.endisland_tour.DetailTitleText.text = gamemanager.LabelName_J[index];
                        //gamemanager.labeldetail.TitleDetail.font = gamemanager.label.Titlefont_CJ;
                        if (gamemanager.DetailText_J[index].Length < 15)
                        {
                            gamemanager.endisland_tour.DetailTitleText.fontSize = 30;
                        }
                        else if (gamemanager.DetailText_J[index].Length >= 15)
                        {
                            gamemanager.endisland_tour.DetailTitleText.fontSize = 22;
                        }
                        gamemanager.endisland_tour.DetailSubTitleText.text = gamemanager.DetailText_E[index];
                        //gamemanager.endisland_tour.DetailSubTitleText.font = gamemanager.label.Titlefont_KE;
                        if (gamemanager.DetailText_E[index].Length < 25)
                        {
                            gamemanager.endisland_tour.DetailSubTitleText.fontSize = 24;
                        }
                        else if (gamemanager.DetailText_E[index].Length >= 25)
                        {
                            gamemanager.endisland_tour.DetailSubTitleText.fontSize = 20;
                        }
                        gamemanager.endisland_tour.DetailText.text = gamemanager.DetailText_J[index];
                        gamemanager.ad.clip = gamemanager.Narration_J[index];
                        //gamemanager.labeldetail.InfoHeight.GetComponent<Text>().font = gamemanager.label.Detailfont_CJ;
                        break;
                }
            }
        }

        Canvas.ForceUpdateCanvases();
        gamemanager.ad.Play();
        Invoke("LabelDetailSizeSetting", 0.1f);
    }

    void LabelDetailSizeSetting()
    {
        gamemanager.endisland_tour.DetailTextContent.anchoredPosition = new Vector2(gamemanager.endisland_tour.DetailTextContent.anchoredPosition.x, 0);
        gamemanager.endisland_tour.DetailTextContent.sizeDelta = new Vector2(gamemanager.endisland_tour.DetailTextContent.sizeDelta.x, gamemanager.endisland_tour.DetailText.GetComponent<RectTransform>().sizeDelta.y + 5);
    }
}
