using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExplainMode : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite JamsilbaseballparkImg;
    public Sprite CoexParkImg;
    public Sprite ArthallImg;
    [SerializeField]
    Text Titletxt;
    [SerializeField]
    Image JamsilImg;
    [SerializeField]
    Image CoexImg;
    [SerializeField]
    Image ArtImg;

    public bool Drag;


    public WebViewController webview;


    public GameObject[] obj;
    public GameObject ExplainBtn;
    public GameObject WebViewBtn;

    GameManager gamemanager;

    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        JamsilbaseballparkImg = Resources.Load<Sprite>("Explain/baseball");
        CoexParkImg = Resources.Load<Sprite>("Explain/baseball");
        ArthallImg = Resources.Load<Sprite>("Explain/baseball");
    }

    public void OnClickExplainBtn()
    {
        gamemanager.ErrorMessage.SetActive(true);
    }

    public void OnClcikWebViewBtn()
    {
        switch (Titletxt.text)
        {
            case "잠실종합운동장":
                GameObject obj = new GameObject();
                obj.name = "https://english.visitkorea.or.kr/svc/contents/contentsView.do?menuSn=351&vcontsId=90297";
                webview.OnClickBtn(obj);
                break;
            case "Seoul Sports Complex":
                GameObject jobj1 = new GameObject();
                jobj1.name = "https://english.visitkorea.or.kr/svc/contents/contentsView.do?menuSn=351&vcontsId=90297";
                webview.OnClickBtn(jobj1);
                break;
            case "蚕室综合运动场":
                GameObject jobj2 = new GameObject();
                jobj2.name = "https://english.visitkorea.or.kr/svc/contents/contentsView.do?menuSn=351&vcontsId=90297";
                webview.OnClickBtn(jobj2);
                break;
            case "蚕室総合運動場":
                GameObject jobj3 = new GameObject();
                jobj3.name = "https://english.visitkorea.or.kr/svc/contents/contentsView.do?menuSn=351&vcontsId=90297";
                webview.OnClickBtn(jobj3);
                break;

            case "코엑스":
                GameObject obj2 = new GameObject();
                obj2.name = "https://www.coexcenter.com/";
                webview.OnClickBtn(obj2);
                break;
            case "Coex":
                GameObject Eobj2 = new GameObject();
                Eobj2.name = "https://www.coexcenter.com/";
                webview.OnClickBtn(Eobj2);
                break;

            case "예술의전당":
                GameObject obj3 = new GameObject();
                obj3.name = "https://www.sac.or.kr/site/main/home";
                webview.OnClickBtn(obj3);
                break;
            case "Seoul Arts Center":
                GameObject Aobj3 = new GameObject();
                Aobj3.name = "https://www.sac.or.kr/site/main/home";
                webview.OnClickBtn(Aobj3);
                break;
            case "艺术的殿堂":
                GameObject Aobj2 = new GameObject();
                Aobj2.name = "https://www.sac.or.kr/site/main/home";
                webview.OnClickBtn(Aobj2);

                break;
            case "芸術の殿堂":
                GameObject Aobj1 = new GameObject();
                Aobj1.name = "https://www.sac.or.kr/site/main/home";
                webview.OnClickBtn(Aobj1);
                break;

        }
    }

    public void DragWebviewStart()
    {
        Drag = true;
        print("start!!");
    }

    public void DragWebviewEnd()
    {
        Drag = false;
    }
}
