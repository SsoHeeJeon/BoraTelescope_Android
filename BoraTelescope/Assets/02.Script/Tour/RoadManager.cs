using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Car;
    public List<GameObject> Dumujin = new List<GameObject>();
    public List<GameObject> Tower = new List<GameObject>();
    public List<GameObject> Nampori = new List<GameObject>();
    public List<GameObject> Dragon = new List<GameObject>();
    public List<GameObject> Kongdol = new List<GameObject>();
    public List<GameObject> Sagoj = new List<GameObject>();
    public List<GameObject> Dock = new List<GameObject>();
    public List<GameObject> Observation = new List<GameObject>();
    public List<GameObject> SealRock = new List<GameObject>();
    public List<GameObject> Simchung = new List<GameObject>();
    public List<GameObject> Lion = new List<GameObject>();

    public void OffRoad()
    {
        y = -85;
        for (int i = 0; i < Dumujin.Count; i++)
        {
            Dumujin[i].SetActive(false);
        }

        for (int i = 0; i < Tower.Count; i++)
        {
            Tower[i].SetActive(false);
        }

        for (int i = 0; i < Nampori.Count; i++)
        {
            Nampori[i].SetActive(false);
        }

        for (int i = 0; i < Kongdol.Count; i++)
        {
            Kongdol[i].SetActive(false);
        }

        for (int i = 0; i < Sagoj.Count; i++)
        {
            Sagoj[i].SetActive(false);
        }

        for (int i = 0; i < Dock.Count; i++)
        {
            Dock[i].SetActive(false);
        }

        for (int i = 0; i < Observation.Count; i++)
        {
            Observation[i].SetActive(false);
        }

        for (int i = 0; i < SealRock.Count; i++)
        {
            SealRock[i].SetActive(false);
        }

        for (int i = 0; i < Simchung.Count; i++)
        {
            Simchung[i].SetActive(false);
        }

        for (int i = 0; i < Lion.Count; i++)
        {
            Lion[i].SetActive(false);
        }

        for (int i = 0; i < Dragon.Count; i++)
        {
            Dragon[i].SetActive(false);
        }
    }

    public DirectionManager directionmanager;
    int num;
    public static bool[] AlreadyDraw = { false, false , false , false };

    public void SeeRoad(string Start, string End, string time)
    {
        if (Start == "끝섬전망대")
        {
            switch (directionmanager.Posnamelist.Count)
            {
                case 1:
                    AlreadyDraw[0] = true;
                    AlreadyDraw[1] = false;
                    AlreadyDraw[2] = false;
                    AlreadyDraw[3] = false;
                    break;
                case 2:
                    AlreadyDraw[0] = true;
                    AlreadyDraw[1] = true;
                    AlreadyDraw[2] = false;
                    AlreadyDraw[3] = false;
                    break;
                case 3:
                    AlreadyDraw[0] = true;
                    AlreadyDraw[1] = true;
                    AlreadyDraw[2] = true;
                    AlreadyDraw[3] = false;
                    break;
                case 4:
                    AlreadyDraw[0] = true;
                    AlreadyDraw[1] = true;
                    AlreadyDraw[2] = true;
                    AlreadyDraw[3] = true;
                    break;
            }
        } 

        if(Start == "Dumujin" || Start == "头武津" || Start == "ドゥムジン")
        {
            Start = "두무진";
        }
        else if (Start == "Cheonan Warship Memorial Tower" || Start == "天安舰慰灵塔" || Start == "天安艦慰霊塔")
        {
            Start = "천안함46용사위령탑";
        }
        else if (Start == "Fold Structure in Nampori" || Start == "南浦里湿谷构造" || Start == "南浦里湿谷構造")
        {
            Start = "남포리습곡구조";
        }
        else if (Start == "Yongteurimbawi Rock" || Start == "龙升天岩" || Start == "ヨントリム岩")
        {
            Start = "용트림바위";
        }
        else if (Start == "Kongdolhaean Coast" || Start == "豆石海边" || Start == "コンドル海岸")
        {
            Start = "콩돌해안";
        }
        else if (Start == "Sagothaebyon Beach" || Start == "沙串海边" || Start == "沙串海岸")
        {
            Start = "사곶해변";
        }
        else if (Start == "Yonggipo Port" || Start == "集装箱码头" || Start == "竜騎砲船着場")
        {
            Start = "용기포선착장";
        }
        else if (Start == "The End Island Observatory" || Start == "尾岛瞭望台" || Start == "端島展望台")
        {
            Start = "끝섬전망대";
        }
        else if (Start == "The Seal Rock" || Start == "海豹岩" || Start == "アザラシ岩")
        {
            Start = "물범바위";
        }
        else if (Start == "Shimcheonggak" || Start == "沈清阁" || Start == "沈清閣")
        {
            Start = "심청각";
        }
        else if (Start == "The Lion Rock" || Start == "狮岩" || Start == "獅子岩")
        {
            Start = "사자바위";
        }

        if (End == "Dumujin" || End == "头武津" || End == "ドゥムジン")
        {
            End = "두무진";
        }
        else if (End == "Cheonan Warship Memorial Tower" || End == "天安舰慰灵塔" || End == "天安艦慰霊塔")
        {
            End = "천안함46용사위령탑";
        }
        else if (End == "Fold Structure in Nampori" || End == "南浦里湿谷构造" || End == "南浦里湿谷構造")
        {
            End = "남포리습곡구조";
        }
        else if (End == "Yongteurimbawi Rock" || End == "龙升天岩" || End == "ヨントリム岩")
        {
            End = "용트림바위";
        }
        else if (End == "Kongdolhaean Coast" || End == "豆石海边" || End == "コンドル海岸")
        {
            End = "콩돌해안";
        }
        else if (End == "Sagothaebyon Beach" || End == "沙串海边" || End == "沙串海岸")
        {
            End = "사곶해변";
        }
        else if (End == "Yonggipo Port" || End == "集装箱码头" || End == "竜騎砲船着場")
        {
            End = "용기포선착장";
        }
        else if (End == "The End Island Observatory" || End == "尾岛瞭望台" || End == "端島展望台")
        {
            End = "끝섬전망대";
        }
        else if (End == "The Seal Rock" || End == "海豹岩" || End == "アザラシ岩")
        {
            End = "물범바위";
        }
        else if (End == "Shimcheonggak" || End == "沈清阁" || End == "沈清閣")
        {
            End = "심청각";
        }
        else if (End == "The Lion Rock" || End == "狮岩" || End == "獅子岩")
        {
            End = "사자바위";
        }

        switch (Start)
        {
            case "두무진":
                switch (End)
                {
                    case "천안함46용사위령탑":
                        num = 0;
                        break;
                    case "용트림바위":
                        num = 2;
                        break;
                    case "콩돌해안":
                        num = 3;
                        break;
                    case "사곶해변":
                        num = 4;
                        break;
                    case "용기포선착장":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                    case "남포리습곡구조":
                        num = 1;
                        break;
                }
                Dumujin[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Dumujin[num], time));
                break;
            case "천안함46용사위령탑":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "남포리습곡구조":
                        num = 1;
                        break;
                    case "용트림바위":
                        num = 2;
                        break;
                    case "콩돌해안":
                        num = 3;
                        break;
                    case "사곶해변":
                        num = 4;
                        break;
                    case "용기포선착장":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Tower[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Tower[num], time));
                break;
            case "남포리습곡구조":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "용트림바위":
                        num = 2;
                        break;
                    case "콩돌해안":
                        num = 3;
                        break;
                    case "사곶해변":
                        num = 4;
                        break;
                    case "용기포선착장":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Nampori[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Nampori[num], time));
                break;
            case "용트림바위":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "콩돌해안":
                        num = 3;
                        break;
                    case "사곶해변":
                        num = 4;
                        break;
                    case "용기포선착장":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Dragon[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Dragon[num], time));
                break;
            case "콩돌해안":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "사곶해변":
                        num = 4;
                        break;
                    case "용기포선착장":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Kongdol[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Kongdol[num], time));
                break;
            case "사곶해변":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "콩돌해안":
                        num = 4;
                        break;
                    case "용기포선착장":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Sagoj[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Sagoj[num], time));
                break;
            case "용기포선착장":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "콩돌해안":
                        num = 4;
                        break;
                    case "사곶해변":
                        num = 5;
                        break;
                    case "끝섬전망대":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Dock[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Dock[num], time));
                break;
            case "끝섬전망대":
                print(2323);
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "콩돌해안":
                        num = 4;
                        break;
                    case "사곶해변":
                        num = 5;
                        break;
                    case "용기포선착장":
                        num = 6;
                        break;
                    case "물범바위":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Observation[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Observation[num], time));
                break;
            case "물범바위":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "콩돌해안":
                        num = 4;
                        break;
                    case "사곶해변":
                        num = 5;
                        break;
                    case "용기포선착장":
                        num = 6;
                        break;
                    case "끝섬전망대":
                        num = 7;
                        break;
                    case "심청각":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                SealRock[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(SealRock[num], time));
                break;
            case "심청각":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "콩돌해안":
                        num = 4;
                        break;
                    case "사곶해변":
                        num = 5;
                        break;
                    case "용기포선착장":
                        num = 6;
                        break;
                    case "끝섬전망대":
                        num = 7;
                        break;
                    case "물범바위":
                        num = 8;
                        break;
                    case "사자바위":
                        num = 9;
                        break;
                }
                Simchung[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Simchung[num], time));
                break;
            case "사자바위":
                switch (End)
                {
                    case "두무진":
                        num = 0;
                        break;
                    case "천안함46용사위령탑":
                        num = 1;
                        break;
                    case "남포리습곡구조":
                        num = 2;
                        break;
                    case "용트림바위":
                        num = 3;
                        break;
                    case "콩돌해안":
                        num = 4;
                        break;
                    case "사곶해변":
                        num = 5;
                        break;
                    case "용기포선착장":
                        num = 6;
                        break;
                    case "끝섬전망대":
                        num = 7;
                        break;
                    case "물범바위":
                        num = 8;
                        break;
                    case "심청각":
                        num = 9;
                        break;
                }
                Lion[num].gameObject.SetActive(true);
                StartCoroutine(SeeCreateRoad(Lion[num], time));
                break;
        }
    }
    public float y = -85;
    IEnumerator SeeCreateRoad(GameObject Road, string time)
    {
        y -= 95;
        try
        {
            Road.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = time;
        }
        catch
        {

        }
        for (int index = 0; index < Road.transform.childCount; index++)
        {
            while (Road.transform.GetChild(index).gameObject.GetComponent<Image>().fillAmount != 1)
            {
                Road.transform.GetChild(index).gameObject.GetComponent<Image>().fillAmount += 0.1f;
                float x = 530 + (index*(365/ Road.transform.childCount) + (365/Road.transform.childCount * Road.transform.GetChild(index).gameObject.GetComponent<Image>().fillAmount));
                Car.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
                yield return new WaitForSeconds(0.03f);
            }
        }

        switch (directionmanager.Posnamelist.Count)
        {
            case 1:
                AlreadyDraw[0] = false;
                break;
            case 2:
                if(AlreadyDraw[0]== true && AlreadyDraw[1] == true)
                {
                    AlreadyDraw[0] = false;
                    SeeRoad(directionmanager.Posnamelist[1], directionmanager.Posnamelist[0], directionmanager.ResultPrefablist[1].transform.GetChild(1).GetComponent<Text>().text);
                } else if(AlreadyDraw[0] == false && AlreadyDraw[1] == true)
                {
                    AlreadyDraw[1] = false;
                }
                break;
            case 3:
                if (AlreadyDraw[0] == true && AlreadyDraw[1] == true && AlreadyDraw[2] == true)
                {
                    AlreadyDraw[0] = false;
                    SeeRoad(directionmanager.Posnamelist[1], directionmanager.Posnamelist[2], directionmanager.ResultPrefablist[1].transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (AlreadyDraw[0] == false && AlreadyDraw[1] == true && AlreadyDraw[2] == true)
                {
                    AlreadyDraw[1] = false;
                    SeeRoad(directionmanager.Posnamelist[2], directionmanager.Posnamelist[0], directionmanager.ResultPrefablist[2].transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (AlreadyDraw[0] == false && AlreadyDraw[1] == false && AlreadyDraw[2] == true)
                {
                    AlreadyDraw[2] = false;
                }
                break;
            case 4:
                if (AlreadyDraw[0] == true && AlreadyDraw[1] == true && AlreadyDraw[2] == true && AlreadyDraw[3] == true)
                {
                    AlreadyDraw[0] = false;
                    SeeRoad(directionmanager.Posnamelist[1], directionmanager.Posnamelist[2], directionmanager.ResultPrefablist[1].transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (AlreadyDraw[0] == false && AlreadyDraw[1] == true && AlreadyDraw[2] == true && AlreadyDraw[3] == true)
                {
                    AlreadyDraw[1] = false;
                    SeeRoad(directionmanager.Posnamelist[2], directionmanager.Posnamelist[3], directionmanager.ResultPrefablist[2].transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (AlreadyDraw[0] == false && AlreadyDraw[1] == false && AlreadyDraw[2] == true && AlreadyDraw[3] == true)
                {
                    AlreadyDraw[2] = false;
                    SeeRoad(directionmanager.Posnamelist[3], directionmanager.Posnamelist[0], directionmanager.ResultPrefablist[3].transform.GetChild(1).GetComponent<Text>().text);
                }
                else if (AlreadyDraw[0] == false && AlreadyDraw[1] == false && AlreadyDraw[2] == false && AlreadyDraw[3] == true)
                {
                    AlreadyDraw[3] = false;
                }
                break;
        }
    }
}
