using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Culture_Label : MonoBehaviour
{
    public CultureMode culturemode;

    int index;

    public GameObject BackgroundImage;
    public GameObject[] Object_Highlight = new GameObject[16];

    // 상세설명 이미지
    public Sprite[] DetailInfoSprite_K = new Sprite[16];
    public Sprite[] DetailInfoSprite_E = new Sprite[16];
    public Sprite[] DetailInfoSprite_C = new Sprite[16];
    public Sprite[] DetailInfoSprite_J = new Sprite[16];
    public static Sprite Detailinfo_S;
    public Sprite Detailinfo_default;

    // 상세설명 Text
    public Sprite[] DetailInfoText_K = new Sprite[16];
    public Sprite[] DetailInfoText_E = new Sprite[16];
    public Sprite[] DetailInfoText_C = new Sprite[16];
    public Sprite[] DetailInfoText_J = new Sprite[16];
    public static Sprite Detailinfo_T;

    public static int DetailScroll_S;

    public Image[] posImage = new Image[12];

    public static GameObject Label_Line1_S;
    public static GameObject Label_Line2_S;
    public static bool changeEffect = false;

    public AudioClip[] Detail_audioclip_k = new AudioClip[16];
    public AudioClip[] Detail_audioclip_E = new AudioClip[16];
    public AudioClip[] Detail_audioclip_C = new AudioClip[16];
    public AudioClip[] Detail_audioclip_J = new AudioClip[16];

    // Start is called before the first frame update
    void Start()
    {
        BackgroundImage.gameObject.SetActive(false);

        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                for(int l = 0; l<12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[0].gameObject.SetActive(true);
                posImage[1].gameObject.SetActive(true);
                posImage[2].gameObject.SetActive(true);
                break;
            case GameManager.LangState.English:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[3].gameObject.SetActive(true);
                posImage[4].gameObject.SetActive(true);
                posImage[5].gameObject.SetActive(true);
                break;
            case GameManager.LangState.Chienses:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[6].gameObject.SetActive(true);
                posImage[7].gameObject.SetActive(true);
                posImage[8].gameObject.SetActive(true);
                break;
            case GameManager.LangState.Japan:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[9].gameObject.SetActive(true);
                posImage[10].gameObject.SetActive(true);
                posImage[11].gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[0].gameObject.SetActive(true);
                posImage[1].gameObject.SetActive(true);
                posImage[2].gameObject.SetActive(true);
                break;
            case GameManager.LangState.English:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[3].gameObject.SetActive(true);
                posImage[4].gameObject.SetActive(true);
                posImage[5].gameObject.SetActive(true);
                break;
            case GameManager.LangState.Chienses:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[6].gameObject.SetActive(true);
                posImage[7].gameObject.SetActive(true);
                posImage[8].gameObject.SetActive(true);
                break;
            case GameManager.LangState.Japan:
                for (int l = 0; l < 12; l++)
                {
                    posImage[l].gameObject.SetActive(false);
                }
                posImage[9].gameObject.SetActive(true);
                posImage[10].gameObject.SetActive(true);
                posImage[11].gameObject.SetActive(true);
                break;
        }
    }

    public void Labelstateimage()
    {
        if (culturemode.SelectLabel != null)
        {
            switch (culturemode.SelectLabel.name)
            {
                case "SeonjukBridge":
                    index = 0;
                    break;
                case "Pyochong":
                    index = 1;
                    break;
                case "Parkyeon":
                    index = 2;
                    break;
                case "Manwoar":
                    index = 3;
                    break;
                case "Royaltomb":
                    index = 4;
                    break;
                case "Seventomb":
                    index = 5;
                    break;
                case "koreauniv":
                    index = 6;
                    break;
                case "Suongyangschool":
                    index = 7;
                    break;
                case "Gaeseonghouse":
                    index = 8;
                    break;
                case "Janamsan":
                    index = 9;
                    break;
                case "GaeseongStar":
                    index = 10;
                    break;
                case "GaeseongWall":
                    index = 11;
                    break;
                case "GaeseongSouthDoor":
                    index = 12;
                    break;
                case "GaeseongUnite":
                    index = 13;
                    break;
                case "GaeseongHistory":
                    index = 14;
                    break;
                case "Hwangjini":
                    index = 15;
                    break;
            }

            if (CultureMode.selectLabel == false)
            {
                BackgroundImage.gameObject.SetActive(true);

                for (int k = 0; k < 16; k++)
                {
                    Object_Highlight[k].GetComponent<Image>().color = new Color(1, 1, 1, 0.65f);
                    Object_Highlight[k].transform.parent.gameObject.GetComponent<Image>().enabled = false;
                }
                Object_Highlight[index].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                Object_Highlight[index].transform.parent.gameObject.GetComponent<Image>().enabled = true;

                changeLang();

                ///////////this.GetComponent<LabelDetail>().DetailOpen();
                culturemode.labeldetailstate = CultureMode.LabelDetailState.Opening;
                Invoke("buttonInter", 3.0f);
            }
            else if (CultureMode.selectLabel == true)
            {
                for (int k = 0; k < 32; k++)
                {
                    if (culturemode.Camera_ani.GetParameter(k).name.Contains("See"))
                    {
                        culturemode.Camera_ani.SetBool(culturemode.Camera_ani.GetParameter(k).name, false);
                        culturemode.Camera_ani.GetBool(culturemode.Camera_ani.GetParameter(k).name);
                    }
                }
                
                startcamera_ani();
                /*
                for (int k = 0; k < 16; k++)
                {
                    Object_Highlight[k].GetComponent<Image>().color = new Color(1, 1, 1, 0.65f);

                    changeEffect = false;
                }

                Object_Highlight[index].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                */
                Invoke("reselectlabel", 1.0f);
                Invoke("buttonInter", 3.0f);
            }
        }
        else if (culturemode.SelectLabel == null)
        {
            BackgroundImage.gameObject.SetActive(false);
            for (int k = 0; k < 16; k++)
            {
                Object_Highlight[k].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                Object_Highlight[k].transform.parent.gameObject.GetComponent<Image>().enabled = true;
            }

            ///////////this.GetComponent<LabelDetail>().CloseDetailWindow();
            culturemode.labeldetailstate = CultureMode.LabelDetailState.Closing;
        }
    }

    public void startcamera_ani()
    {
        culturemode.Camera_ani.SetBool("Select" + culturemode.SelectLabel.name, true);
        culturemode.Camera_ani.GetBool("Select" + culturemode.SelectLabel.name);
        culturemode.Camera_ani.SetBool("See" + culturemode.SelectLabel.name, true);
        culturemode.Camera_ani.GetBool("See" + culturemode.SelectLabel.name);

        //this.GetComponent<LabelDetail>().DetailOpen();
        culturemode.labeldetailstate = CultureMode.LabelDetailState.Opening;
    }

    public void buttonInter()
    {
        for (int k = 0; k < 32; k++)
        {
            if (culturemode.Camera_ani.GetParameter(k).name.Contains("Select"))
            {
                culturemode.Camera_ani.SetBool(culturemode.Camera_ani.GetParameter(k).name, false);
                culturemode.Camera_ani.GetBool(culturemode.Camera_ani.GetParameter(k).name);
            }
        }

        if (culturemode.SelectLabel != null)
        {
            culturemode.Camera_ani.SetBool("Select" + culturemode.SelectLabel.name, true);
            culturemode.Camera_ani.GetBool("Select" + culturemode.SelectLabel.name);
        }
    }

    public void reselectlabel()
    {
        ///////////this.GetComponent<LabelDetail>().DetailOpen();
        culturemode.labeldetailstate = CultureMode.LabelDetailState.Opening;
        for (int k = 0; k < 16; k++)
        {
            Object_Highlight[k].GetComponent<Image>().color = new Color(1, 1, 1, 0.65f);
            Object_Highlight[k].transform.parent.gameObject.GetComponent<Image>().enabled = false;
        }

        Object_Highlight[index].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Object_Highlight[index].transform.parent.gameObject.GetComponent<Image>().enabled = true;
        if (culturemode.SelectLabel != null)
        {
            changeLang();
        }
    }

    public void changeLang()
    {
        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                Detailinfo_S = DetailInfoSprite_K[index];
                Detailinfo_T = DetailInfoText_K[index];
                GetComponent<AudioSource>().clip = Detail_audioclip_k[index];
                break;
            case GameManager.LangState.English:
                Detailinfo_S = DetailInfoSprite_E[index];
                Detailinfo_T = DetailInfoText_E[index];
                GetComponent<AudioSource>().clip = Detail_audioclip_E[index];
                break;
            case GameManager.LangState.Chienses:
                Detailinfo_S = DetailInfoSprite_C[index];
                Detailinfo_T = DetailInfoText_C[index];
                GetComponent<AudioSource>().clip = Detail_audioclip_C[index];
                break;
            case GameManager.LangState.Japan:
                Detailinfo_S = DetailInfoSprite_J[index];
                Detailinfo_T = DetailInfoText_J[index];
                GetComponent<AudioSource>().clip = Detail_audioclip_J[index];
                break;
        }
        culturemode.DetailImage_Background.GetComponent<Image>().sprite = Detailinfo_S;
        culturemode.Info.GetComponent<Image>().sprite = Detailinfo_T;

        if (culturemode.Info.GetComponent<Image>())
        {
            culturemode.Info.GetComponent<Image>().SetNativeSize();
            culturemode.Info.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(culturemode.Info.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x, culturemode.Info.GetComponent<RectTransform>().sizeDelta.y);
            //float InfoImageHeight = culturemode.Info.GetComponent<RectTransform>().rect.height + 5;
            //culturemode.Info.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(culturemode.Info.transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x, InfoImageHeight);
            //culturemode.Info.transform.parent.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        //////this.GetComponent<LabelDetail>().ClickLabel();
    }

    public void returnCamera()
    {
        culturemode.Camera_ani.SetBool("SelectRoyaltomb", false);
        culturemode.Camera_ani.GetBool("SelectRoyaltomb");
        culturemode.Camera_ani.SetBool("SelectGaeseongStar", false);
        culturemode.Camera_ani.GetBool("SelectGaeseongStar");
        culturemode.Camera_ani.SetBool("SelectGaeseongSouthDoor", false);
        culturemode.Camera_ani.GetBool("SelectGaeseongSouthDoor");
        culturemode.Camera_ani.SetBool("Selectkoreauniv", false);
        culturemode.Camera_ani.GetBool("Selectkoreauniv");
    }
}
