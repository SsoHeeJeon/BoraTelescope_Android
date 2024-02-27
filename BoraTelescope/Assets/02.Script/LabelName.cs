using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelName : MonoBehaviour
{
    public string Namelist;
    public void LabelLanguage(string name)
    {
        if (Contentsinfo.ContentsName == "Aegibong")
        {
            switch (name)
            {
                case "River":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "예성강 하구";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "The mouth of the Yeseong River";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "礼成江 河口";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "イェソン川河口";
                            break;
                    }
                    break;
                case "DogogaeM":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "도고개산";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Dogogae Mountain";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "东姑盖山";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "トゴゲ山";
                            break;
                    }
                    break;
                case "Old":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "구 탈곡장";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Old Threshing Floor";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "前场打谷场";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "旧脱穀場";
                            break;
                    }
                    break;
                case "AmsilV":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "암실마을";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Amsil Village";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "岩实村";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "アムシル村";
                            break;
                    }
                    break;
                case "Quarry":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "채석장";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Quarry";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "采石场";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "採石場";
                            break;
                    }
                    break;
                case "New":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "신 탈곡장";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "New Threshing Floor";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "新打谷场";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "新脱穀場";
                            break;
                    }
                    break;
                case "PromotionV":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "해물선전마을";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Haemul Promotion Village";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "海穆尔广告村";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "ヘムル広告村";
                            break;
                    }
                    break;
                case "Dora":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "파주 도라전망대";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Paju Dora Observation";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "都罗展望台";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "トラ展望台";
                            break;
                    }
                    break;
                case "Gwansanpo":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "관산반도";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "The Gwansan Peninsula";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "关山半岛";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "クァンサン半島";
                            break;
                    }
                    break;
                case "Dolgoji":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "시암리 습지";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Siam-ri Wetland";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "暹罗里湿地";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "シアム里湿地";
                            break;
                    }
                    break;
                case "HanR":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "한강";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Han River";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "汉江";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "漢江";
                            break;
                    }
                    break;
                case "Paju":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "파주";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Paju";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "坡州";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "坡州";
                            break;
                    }
                    break;
            }
        }
        else if (Contentsinfo.ContentsName == "Typhoon")
        {
            switch (name)
            {
                case "Hinge":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "힌지";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Hinge";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "绞链";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "ヒンジ";
                            break;
                    }
                    break;
                case "Brown":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "갈색";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "BrownKnoll";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "布朗诺尔";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "ブラウン·ノール";
                            break;
                    }
                    break;
                case "Taecy":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "테시";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Tessle";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "泰瑟尔";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "テッスル";
                            break;
                    }
                    break;
                case "Nickey":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "닉키";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Nickie";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "尼基";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "ニッキー";
                            break;
                    }
                    break;
                case "Bubble":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "버블고지";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Bubble Highlands";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "泡泡高地";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "バブル高原";
                            break;
                    }
                    break;
                case "Antia":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "안티아";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Antia";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "安蒂亚";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "アンティア";
                            break;
                    }
                    break;
                case "Park":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "박";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Park";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "Park";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "Park";
                            break;
                    }
                    break;
                case "Queen":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "퀸";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Queen";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "皇后乐队";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "クイーン";
                            break;
                    }
                    break;
            }
        }
        else if (Contentsinfo.ContentsName == "EndIsland")
        {
            switch (name)
            {
                case "Airport":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "백령공항";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Baengnyeong Airport";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "白翎机场";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "白翎空港";
                            break;
                    }
                    break;
                case "Pyongyang":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "개성직할시 방향";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Direction of Gaeseong City";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "開城直割市方向";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "開城直割市方面";
                            break;
                    }
                    break;
                case "Big":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "대청도 방향";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Direction of Daecheongdo Island";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "大青岛方向";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "大靑島方面";
                            break;
                    }
                    break;
                case "Small":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "소청도 방향";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Socheongdo direction";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "小青岛方向";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "小靑島方面";
                            break;
                    }
                    break;
                case "Simchung":
                    switch (GameManager.langstate)
                    {
                        case GameManager.LangState.Korea:
                            Namelist = "심청각 방향";
                            break;
                        case GameManager.LangState.English:
                            Namelist = "Shimcheonggak direction";
                            break;
                        case GameManager.LangState.Chienses:
                            Namelist = "沈清阁方向";
                            break;
                        case GameManager.LangState.Japan:
                            Namelist = "沈清閣方面";
                            break;
                    }
                    break;
            }
        }
    }
}
