using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NoticeWindow : MonoBehaviour
{
    public  GameManager gamemanager;
    public  string NoticeState;
    public  Image NoticeIcon;
    public  Text NoticeText;
    public  Font KEfont;
    public  Font CJfont;

    public  GameObject ButType_1;
    public  GameObject ButType_2;

    public Sprite ErrorIcon;
    public Sprite CheckIcon;

    private void ReadytoStart()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        KEfont = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
        CJfont = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
    }

    public  void NoticeWindowOpen(string Window)
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (!gamemanager.endisland_tour.TourMessage.activeSelf)
        {
            gamemanager.endisland_tour.TourMessage.SetActive(true);
        }

        NoticeIcon = gamemanager.endisland_tour.TourMessage.transform.GetChild(0).gameObject.GetComponent<Image>();
        NoticeText = gamemanager.endisland_tour.TourMessage.transform.GetChild(1).gameObject.GetComponent<Text>();
        ButType_1 = gamemanager.endisland_tour.TourMessage.transform.GetChild(2).gameObject;
        ButType_2 = gamemanager.endisland_tour.TourMessage.transform.GetChild(3).gameObject;

        NoticeState = Window;

        //switch (GameManager.langstate)
        //{
        //    case GameManager.LangState.Korea:
        //        NoticeText.font = KEfont;
        //        break;
        //    case GameManager.LangState.English:
        //        NoticeText.font = KEfont;
        //        break;
        //    case GameManager.LangState.Chienses:
        //        NoticeText.font = CJfont;
        //        break;
        //    case GameManager.LangState.Japan:
        //        NoticeText.font = CJfont;
        //        break;
        //}
        Setanything();
        Debug.Log(ButType_1 + " / " + ButType_2);
    }

    public void Setanything()
    {
        switch (NoticeState)
        {
            case "ErrorMessage":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "죄송합니다.\r\n현재 해당 모드를 이용하실 수 없습니다.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "I'm sorry.\r\nYou can't use mode.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "绐您添麻烦子, 真抱歉。 目前不能使用。";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "すみません。 現在のモードは利用できません。";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = ErrorIcon;
                break;
            case "ErrorInternet":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "죄송합니다.\r\n현재 인터넷이 불안정하여 QR코드 제공이 어렵습니다.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "I'm sorry.\r\nYou can't use mode.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "绐您添麻烦子, 真抱歉。 目前不能使用。";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "すみません。 現在のモードは利用できません。";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = ErrorIcon;
                break;
            case "SeasonWaiting":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "죄송합니다.\r\n현재 인터넷이 불안정하여 QR코드 제공이 어렵습니다.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "I'm sorry.\r\nYou can't use mode.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "绐您添麻烦子, 真抱歉。 目前不能使用。";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "すみません。 現在のモードは利用できません。";
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "See360View":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "화면을 터치하여 360 View를\r\n관람해 주세요.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Touch the screen to view 360 photo.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "请按屏幕观看 360 view。";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "画面をタッチして360 Viewをご覧ください。";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "ChangeOperation":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "수동조작 모드로 변경하시겠습니까?";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Do you want to change to manual operation mode?";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "确定要更改为手动操作模式吗？";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "手動操作モードに変更しますか？";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "VisitClickCap":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "사진촬영 기능이 제공되지 않는 모드입니다.\r\n(실시간, XR, 맑은날모드 내에서 사용가능합니다.)";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Mode Not Supported\r\n(Use only for Live, XR and Clear Mode)";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "不支持模式\r\n(仅用于实时、XR和清除模式)";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "モードがサポートされていない\r\n（ライブ、XR、およびクリア モードでのみ使用";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "VisitCancel":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "작성을 취소하시겠습니까?\r\n작성중인 내용은 삭제됩니다.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Are you sure you want to cancel?\r\nType will be deleted.";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_KE;
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "确定要取消吗？\r\n类型将被删除";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "キャンセルしてよろしいですか？\r\nタイプが削除されます";
                        NoticeText.font = gamemanager.GetComponent<LabelMake>().Labelfont_CJ;
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "StopSelfi":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "사진찍기를 그만하시겠습니까?";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "StopSelfiCustom":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "사진꾸미기를 그만하시겠습니까?\r\n해당 사진은 삭제됩니다.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "DontSaveSelfi":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "셀피모드에서 나가시겠습니까?\r\n해당 사진은 삭제됩니다.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "HideArea":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "비공개 영역입니다. 이동해주세요.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "ResetNotice":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = ((int)(60 - GameManager.touchCount)).ToString() + "초 후 초기화면으로 돌아갑니다.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Return to the initial screen after "+ ((int)(60 - GameManager.touchCount)).ToString() + " seconds.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = ((int)(60 - GameManager.touchCount)).ToString() + "秒后回到初始画面";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = ((int)(60 - GameManager.touchCount)).ToString() + "秒後に初期画面に戻ります.";
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "SeeFourSeason":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "사계절 버튼을 선택해 다른 계절의 맑은날 풍경도 감상해보세요!";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Select the four seasons button to enjoy the scenery on a Clear day in other seasons!";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "请选择四季按钮，欣赏其他季节的晴天风景！";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "四季のボタンを選んで他の季節の晴れた日の風景も鑑賞してみてください！";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "PantiltOrigin":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "안내가 정확하지 않다면 잠시 정비할까요?";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "If the instructions are not correct, should we fix it for a while?";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "如果介绍不准确的话，要暂时整顿一下吗？";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "案内が正確でなければ、しばらく整備しましょうか？";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "GoXRMode":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "시야가 좋아서 잘보이네요! XR모드를 이용하여 실시간 풍경을 감상해보세요.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "This place has a good view! Enjoy real-time scenery using XR mode.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "视野很好，看得清楚！ 请使用XR模式实时欣赏风景。";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "視野が良くてよく見えますね！ XRモードを利用してリアルタイムの風景を鑑賞してみてください。";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "GoClearMode":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "시야가 좋지 않아요. 맑은날모드를 이용하여 맑은날 풍경을 감상해보세요.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "The view isn't good here. Use ClearMode to enjoy the scenery on a clear day.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "这里的视野不是很好。 利用晴天模式欣赏晴天的风景。";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "ここは視界がよくありません。 晴れた日モードで晴れた日の風景を鑑賞してみてください。";
                        break;
                }
                ButType_1.SetActive(false);
                ButType_2.SetActive(true);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "SeeSwan":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "고니가 날개짓하는 모습이 백령도와 닮았다고해요.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "The view isn't good here. Use ClearMode to enjoy the scenery on a clear day.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "这里的视野不是很好。 利用晴天模式欣赏晴天的风景。";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "ここは視界がよくありません。 晴れた日モードで晴れた日の風景を鑑賞してみてください。";
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "Tour_360":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "우측 상단에 360° 버튼을 이용하여\r\n다른 풍경을 감상해보세요.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Enjoy different scenery using the 360° button in the upper right corner.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "在右上角用360°按钮欣赏其他风景吧。";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "右上の360°ボタンで他の風景を鑑賞してみてください。";
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
            case "Tour_Video":
                switch (GameManager.langstate)
                {
                    case GameManager.LangState.Korea:
                        NoticeText.text = "우측 상단에 '영상보기'버튼을 이용하여\r\n관련 영상을 감상해보세요.";
                        break;
                    case GameManager.LangState.English:
                        NoticeText.text = "Use the 'View Video' button at the top right to watch the related video.";
                        break;
                    case GameManager.LangState.Chienses:
                        NoticeText.text = "请使用右上角的'查看视频'按钮来欣赏相关视频。";
                        break;
                    case GameManager.LangState.Japan:
                        NoticeText.text = "右上の「映像を見る」ボタンを利用して関連映像を鑑賞してみてください。";
                        break;
                }
                ButType_1.SetActive(true);
                ButType_2.SetActive(false);
                NoticeIcon.sprite = CheckIcon;
                break;
        }
    }

    public void NoticeYes()
    {
        switch (NoticeState)
        {
            case "ErrorMessage":
                break;
            case "ErrorInternet":
                break;
            case "SeasonWaiting":
                break;
            case "See360View":
                break;
            case "ChangeOperation":

                break;
            case "VisitClickCap":
                
                break;
            case "VisitCancel":
                gamemanager.visitmanager.RealOut();
                gamemanager.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "StopSelfi":
                gamemanager.CaptureBtn.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "StopSelfiCustom":
                gamemanager.CaptureBtn.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "DontSaveSelfi":
                gamemanager.CaptureBtn.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case "SeeFourSeason":
                break;
            case "PantiltOrigin":
                break;
            case "GoXRMode":
                gamemanager.Menu(gamemanager.MenuBar.transform.GetChild(0).GetChild(1).gameObject);
                break;
            case "GoClearMode":
                gamemanager.Menu(gamemanager.MenuBar.transform.GetChild(0).GetChild(2).gameObject);
                break;
        }
        gamemanager.endisland_tour.TourMessage.SetActive(false);
        gamemanager.ButtonClickSound();
    }

    public void NoticeNo()
    {
        gamemanager.endisland_tour.TourMessage.SetActive(false);
        gamemanager.ButtonClickSound();
        if(SceneManager.GetActiveScene().name.Contains("TourismMode_EndIsland"))
        {
            if(gamemanager.endisland_tour.See360.activeSelf)
            {
                gamemanager.endisland_tour.Notcie360();
            }
        }
    }
}
