using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DirectionManager : MonoBehaviour
{
    public class Goal
    {
        public List<double> location { get; set; }
        public int dir { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public int pointIndex { get; set; }
    }

    public class Guide
    {
        public int pointIndex { get; set; }
        public int type { get; set; }
        public string instructions { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
    }

    public class Root
    {
        public int code { get; set; }
        public string message { get; set; }
        public DateTime currentDateTime { get; set; }
        public Route route { get; set; }
    }

    public class Route
    {
        public List<Trafast> trafast { get; set; }
    }

    public class Section
    {
        public int pointIndex { get; set; }
        public int pointCount { get; set; }
        public int distance { get; set; }
        public string name { get; set; }
        public int congestion { get; set; }
        public int speed { get; set; }
    }

    public class Start1
    {
        public List<double> location { get; set; }
    }

    public class Summary
    {
        public Start1 start { get; set; }
        public Goal goal { get; set; }
        public List<Waypoint> waypoints { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public int etaServiceType { get; set; }
        public DateTime departureTime { get; set; }
        public List<List<double>> bbox { get; set; }
        public int tollFare { get; set; }
        public int taxiFare { get; set; }
        public int fuelPrice { get; set; }
    }

    public class Trafast
    {
        public Summary summary { get; set; }
        public List<List<double>> path { get; set; }
        public List<Section> section { get; set; }
        public List<Guide> guide { get; set; }
    }

    public class Waypoint
    {
        public List<double> location { get; set; }
        public int dir { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public int pointIndex { get; set; }
    }


    [Header("정보 입력")]
    public string strBasURL = "";
    public List<string> laitudelist = new List<string>();
    public List<string> longitudelist = new List<string>();
    public List<string> Posnamelist = new List<string>();
    public string laitude = "";
    public string longitude = "";
    public string goallaitude = "";
    public string goallongitude = "";
    private string strAPIKey = "lxs6g7f2lp";
    private string secretKey = "HbLlHWVtGrDQErhwu6rS2NH23o1SPZ3hhfC5isvX";

    public GameObject RoadMapLabel;

    public GameObject GoalPosText;
    public GameObject WayPosTextPrefab;
    public List<GameObject> WayPosTextlist = new List<GameObject>();
    public GameObject ResultPrefab;
    public List<GameObject> ResultPrefablist = new List<GameObject>();
    public GameObject Info;

    [SerializeField]
    RoadManager road;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator Loader()
    {
        string waypoint = "";
        if (laitudelist.Count >= 2)
        {
            waypoint = "&waypoints=";
            for (int i = 1; i < laitudelist.Count; i++)
            {
                if (i != laitudelist.Count - 1)
                {
                    waypoint += (longitudelist[i] + "," + laitudelist[i] + "|");
                }
                else
                {
                    waypoint += (longitudelist[i] + "," + laitudelist[i]);
                }
            }
        }

        string str = "https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving?start=" + "124.744" + "," + "37.9595" + "&goal=" + longitudelist[0] + "," + laitudelist[0] + waypoint + "&option=trafast";

        print(str);
        UnityWebRequest request = UnityWebRequest.Get(str);

        request.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", strAPIKey);
        request.SetRequestHeader("X-NCP-APIGW-API-KEY", secretKey);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            print("Error");
        }
        else
        {
            print(request.downloadHandler.text);
            string Starttext = "";
            string MinText = "";
            string TaxiText = "";
            string FuelText = "";
            char WonText = ' ';
            switch (GameManager.langstate)
            {
                case GameManager.LangState.Korea:
                    Starttext = "끝섬전망대";
                    MinText = "분";
                    TaxiText = "택시비 ";
                    FuelText = "연료비 ";
                    WonText = '원';
                    break;
                case GameManager.LangState.English:
                    Starttext = "The End Island Observatory";
                    MinText = "min";
                    TaxiText = "Taxi ";
                    FuelText = "Fuel ";
                    WonText = '₩';
                    break;
                case GameManager.LangState.Chienses:
                    Starttext = "尾岛瞭望台";
                    MinText = "min";
                    TaxiText = "Taxi ";
                    FuelText = "Fuel ";
                    WonText = '₩';
                    break;
                case GameManager.LangState.Japan:
                    Starttext = "端島展望台";
                    MinText = "min";
                    TaxiText = "Taxi ";
                    FuelText = "Fuel ";
                    WonText = '₩';
                    break;
            }
            float y = GoalPosText.GetComponent<RectTransform>().anchoredPosition.y - 62;
            Root Distance = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);
            try
            {
                for (int i = 0; i < Distance.route.trafast[0].summary.waypoints.Count; i++)
                {
                    GameObject obj = Instantiate(ResultPrefab);
                    obj.SetActive(true);
                    obj.transform.parent = ResultPrefab.transform.parent;
                    y -= 100;
                    ResultPrefablist.Add(obj);
                    if (i == 0)
                    {
                        //road.SeeRoad("끝섬전망대", Posnamelist[i + 1]);
                        obj.transform.GetChild(0).GetComponent<Text>().text = Starttext;
                        obj.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Posnamelist[i + 1];
                        obj.transform.GetChild(1).GetComponent<Text>().text = (Distance.route.trafast[0].summary.waypoints[i].duration / 60000) + MinText;
                        obj.transform.GetChild(2).GetComponent<Text>().text = Math.Round((Double)Distance.route.trafast[0].summary.waypoints[i].distance / 1000) + "km";
                    }
                    else
                    {
                        //road.SeeRoad(Posnamelist[i], Posnamelist[i + 1]);
                        obj.transform.GetChild(0).GetComponent<Text>().text = Posnamelist[i];
                        obj.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Posnamelist[i + 1];
                        obj.transform.GetChild(1).GetComponent<Text>().text = (Distance.route.trafast[0].summary.waypoints[i].duration / 60000) + MinText;
                        obj.transform.GetChild(2).GetComponent<Text>().text = Math.Round((Double)Distance.route.trafast[0].summary.waypoints[i].distance / 1000) + "km";
                    }
                }
            }
            catch
            {

            }
            GameObject obj1 = Instantiate(ResultPrefab);
            obj1.SetActive(true);
            obj1.transform.parent = ResultPrefab.transform.parent;
            y -= 100;
            ResultPrefablist.Add(obj1);
            try
            {
                //road.SeeRoad(Posnamelist[Distance.route.trafast[0].summary.waypoints.Count], Posnamelist[0]);
                obj1.transform.GetChild(0).GetComponent<Text>().text = Posnamelist[Distance.route.trafast[0].summary.waypoints.Count];
                obj1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Posnamelist[0];
                obj1.transform.GetChild(1).GetComponent<Text>().text = (Distance.route.trafast[0].summary.goal.duration / 60000) + MinText;
                obj1.transform.GetChild(2).GetComponent<Text>().text = Math.Round((Double)Distance.route.trafast[0].summary.goal.distance / 1000) + "km";
            }
            catch
            {
                //road.SeeRoad("끝섬전망대", Posnamelist[0]);
                obj1.transform.GetChild(0).GetComponent<Text>().text = Starttext;
                obj1.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = Posnamelist[0];
                obj1.transform.GetChild(1).GetComponent<Text>().text = (Distance.route.trafast[0].summary.duration / 60000) + MinText;
                obj1.transform.GetChild(2).GetComponent<Text>().text = Math.Round((Double)Distance.route.trafast[0].summary.distance / 1000) + "km";
            }

            //print(Posnamelist[Distance.route.trafast[0].summary.waypoints.Count] + " -> " + Posnamelist[0] + "거리 = " + Distance.route.trafast[0].summary.goal.distance);
            //print(Posnamelist[Distance.route.trafast[0].summary.waypoints.Count] + " -> " + Posnamelist[0] + "시간 = " + Distance.route.trafast[0].summary.goal.duration);


            Info.SetActive(true);
            //Info.GetComponent<RectTransform>().anchoredPosition = new Vector2(Info.GetComponent<RectTransform>().anchoredPosition.x, y);
            Info.transform.GetChild(0).GetComponent<Text>().text = (Distance.route.trafast[0].summary.duration / 60000).ToString();
            Info.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = MinText;
            Info.transform.GetChild(1).GetComponent<Text>().text = Math.Round((Double)Distance.route.trafast[0].summary.distance / 1000) + "km";
            Info.transform.GetChild(2).GetComponent<Text>().text = TaxiText + Distance.route.trafast[0].summary.taxiFare + WonText;
            Info.transform.GetChild(3).GetComponent<Text>().text = FuelText + Distance.route.trafast[0].summary.fuelPrice + WonText;

            float yy = -540;
            for (int i = 0; i < ResultPrefablist.Count; i++)
            {
                ResultPrefablist[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, yy);
                yy -= 92;
            }
        }

        for (int index = 0; index < road.gameObject.transform.childCount; index++)
        {
            for (int indexs = 0; indexs < road.gameObject.transform.GetChild(index).childCount; indexs++)
            {
                for (int indext = 0; indext < road.gameObject.transform.GetChild(index).GetChild(indexs).childCount; indext++)
                {
                    road.gameObject.transform.GetChild(index).GetChild(indexs).GetChild(indext).gameObject.GetComponent<Image>().fillAmount = 0;
                }
            }
        }
        if (Posnamelist.Count != 1)
        {
            road.SeeRoad("끝섬전망대", Posnamelist[1], ResultPrefablist[0].transform.GetChild(1).GetComponent<Text>().text);
        } else if (Posnamelist.Count == 1)
        {
            road.SeeRoad("끝섬전망대", Posnamelist[0], ResultPrefablist[0].transform.GetChild(1).GetComponent<Text>().text);
        }

    }

    string FindRoad;
    string SelectName;

    public void OnClickDirectionBtn()
    {
        FindRoad = "";
        road.OffRoad();
        for(int i=0; i< ResultPrefablist.Count; i++)
        {
            Destroy(ResultPrefablist[i]);
        }
        ResultPrefablist.Clear();

        for (int index = 0; index < this.gameObject.transform.childCount; index++)
        {
            for (int indexs = 0; indexs < road.gameObject.transform.GetChild(index).childCount; indexs++)
            {
                for (int indext = 0; indext < road.gameObject.transform.GetChild(index).GetChild(indexs).childCount; indext++)
                {
                    road.gameObject.transform.GetChild(index).GetChild(indexs).GetChild(indext).gameObject.GetComponent<Image>().fillAmount = 0;
                }
            }
        }

        FindRoad = "끝섬전망대_";
        if (Posnamelist.Count != 1)
        {
            for (int index = 1; index < Posnamelist.Count; index++)
            {
                SelectName = Posnamelist[index];

                if (SelectName == "Dumujin" || SelectName == "头武津" || SelectName == "ドゥムジン")
                {
                    SelectName = "두무진";
                }
                else if (SelectName == "Cheonan Warship Memorial Tower" || SelectName == "天安舰慰灵塔" || SelectName == "天安艦慰霊塔")
                {
                    SelectName = "천안함46용사위령탑";
                }
                else if (SelectName == "Fold Structure in Nampori" || SelectName == "南浦里湿谷构造" || SelectName == "南浦里湿谷構造")
                {
                    SelectName = "남포리습곡구조";
                }
                else if (SelectName == "Yongteurimbawi Rock" || SelectName == "龙升天岩" || SelectName == "ヨントリム岩")
                {
                    SelectName = "용트림바위";
                }
                else if (SelectName == "Kongdol Coast" || SelectName == "豆石海边" || SelectName == "コンドル海岸")
                {
                    SelectName = "콩돌해안";
                }
                else if (SelectName == "Sagot Sand Beach" || SelectName == "沙串海边" || SelectName == "沙串海岸")
                {
                    SelectName = "사곶해변";
                }
                else if (SelectName == "Yonggipo Port" || SelectName == "集装箱码头" || SelectName == "竜騎砲船着場")
                {
                    SelectName = "용기포선착장";
                }
                else if (SelectName == "The End Island Observatory" || SelectName == "尾岛瞭望台" || SelectName == "端島展望台")
                {
                    SelectName = "끝섬전망대";
                }
                else if (SelectName == "The Seal Rock" || SelectName == "海豹岩" || SelectName == "アザラシ岩")
                {
                    SelectName = "물범바위";
                }
                else if (SelectName == "Shimcheonggak" || SelectName == "沈清阁" || SelectName == "沈清閣")
                {
                    SelectName = "심청각";
                }
                else if (SelectName == "The Lion Rock" || SelectName == "狮岩" || SelectName == "獅子岩")
                {
                    SelectName = "사자바위";
                }

                FindRoad += SelectName + "_";
            }
            SelectName = Posnamelist[0];
            if (SelectName == "Dumujin" || SelectName == "头武津" || SelectName == "ドゥムジン")
            {
                SelectName = "두무진";
            }
            else if (SelectName == "Cheonan Warship Memorial Tower" || SelectName == "天安舰慰灵塔" || SelectName == "天安艦慰霊塔")
            {
                SelectName = "천안함46용사위령탑";
            }
            else if (SelectName == "Fold Structure in Nampori" || SelectName == "南浦里湿谷构造" || SelectName == "南浦里湿谷構造")
            {
                SelectName = "남포리습곡구조";
            }
            else if (SelectName == "Yongteurimbawi Rock" || SelectName == "龙升天岩" || SelectName == "ヨントリム岩")
            {
                SelectName = "용트림바위";
            }
            else if (SelectName == "Kongdol Coast" || SelectName == "豆石海边" || SelectName == "コンドル海岸")
            {
                SelectName = "콩돌해안";
            }
            else if (SelectName == "Sagot Sand Beach" || SelectName == "沙串海边" || SelectName == "沙串海岸")
            {
                SelectName = "사곶해변";
            }
            else if (SelectName == "Yonggipo Port" || SelectName == "集装箱码头" || SelectName == "竜騎砲船着場")
            {
                SelectName = "용기포선착장";
            }
            else if (SelectName == "The End Island Observatory" || SelectName == "尾岛瞭望台" || SelectName == "端島展望台")
            {
                SelectName = "끝섬전망대";
            }
            else if (SelectName == "The Seal Rock" || SelectName == "海豹岩" || SelectName == "アザラシ岩")
            {
                SelectName = "물범바위";
            }
            else if (SelectName == "Shimcheonggak" || SelectName == "沈清阁" || SelectName == "沈清閣")
            {
                SelectName = "심청각";
            }
            else if (SelectName == "The Lion Rock" || SelectName == "狮岩" || SelectName == "獅子岩")
            {
                SelectName = "사자바위";
            }
            FindRoad += SelectName;
        } else if (Posnamelist.Count == 1)
        {
            SelectName = Posnamelist[0];
            if (SelectName == "Dumujin" || SelectName == "头武津" || SelectName == "ドゥムジン")
            {
                SelectName = "두무진";
            }
            else if (SelectName == "Cheonan Warship Memorial Tower" || SelectName == "天安舰慰灵塔" || SelectName == "天安艦慰霊塔")
            {
                SelectName = "천안함46용사위령탑";
            }
            else if (SelectName == "Fold Structure in Nampori" || SelectName == "南浦里湿谷构造" || SelectName == "南浦里湿谷構造")
            {
                SelectName = "남포리습곡구조";
            }
            else if (SelectName == "Yongteurimbawi Rock" || SelectName == "龙升天岩" || SelectName == "ヨントリム岩")
            {
                SelectName = "용트림바위";
            }
            else if (SelectName == "Kongdol Coast" || SelectName == "豆石海边" || SelectName == "コンドル海岸")
            {
                SelectName = "콩돌해안";
            }
            else if (SelectName == "Sagot Sand Beach" || SelectName == "沙串海边" || SelectName == "沙串海岸")
            {
                SelectName = "사곶해변";
            }
            else if (SelectName == "Yonggipo Port" || SelectName == "集装箱码头" || SelectName == "竜騎砲船着場")
            {
                SelectName = "용기포선착장";
            }
            else if (SelectName == "The End Island Observatory" || SelectName == "尾岛瞭望台" || SelectName == "端島展望台")
            {
                SelectName = "끝섬전망대";
            }
            else if (SelectName == "The Seal Rock" || SelectName == "海豹岩" || SelectName == "アザラシ岩")
            {
                SelectName = "물범바위";
            }
            else if (SelectName == "Shimcheonggak" || SelectName == "沈清阁" || SelectName == "沈清閣")
            {
                SelectName = "심청각";
            }
            else if (SelectName == "The Lion Rock" || SelectName == "狮岩" || SelectName == "獅子岩")
            {
                SelectName = "사자바위";
            }
            FindRoad += SelectName;
        }

        GameManager gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(Loader());
    }

    [SerializeField]
    GameObject RoadAllMapLabel;
    [SerializeField]
    public GameObject WayImg;
    public void OnclickXBtn(GameObject obj)
    {
        if(!GoalPosText.transform.GetChild(1).gameObject.activeSelf)
        {
            for (int i = 0; i < Posnamelist.Count; i++)
            {
                if (Posnamelist[i] == obj.transform.GetChild(0).gameObject.GetComponent<Text>().text)
                {
                    for(int j=0; j< RoadAllMapLabel.transform.childCount; j++)
                    {
                        if(Posnamelist[i] == RoadAllMapLabel.transform.GetChild(j).GetComponent<Pos>().PosName)
                        {
                            RoadAllMapLabel.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                        }
                    }
                    longitudelist.RemoveAt(i);
                    laitudelist.RemoveAt(i);
                    Posnamelist.RemoveAt(i);
                    if (i == 0)
                    {
                        if (longitudelist.Count != 0)
                        {
                            Destroy(WayPosTextlist[0]);
                            WayPosTextlist.RemoveAt(0);
                            GoalPosText.transform.GetChild(0).GetComponent<Text>().text = Posnamelist[0];
                        }
                        else
                        {
                            GoalPosText.transform.GetChild(0).GetComponent<Text>().text = "";
                            GoalPosText.transform.GetChild(1).gameObject.SetActive(true);
                            WayImg.SetActive(true);
                            GoalPosText.GetComponent<RectTransform>().anchoredPosition = new Vector2(24, -156);
                        }
                    }
                    else
                    {
                        if (WayPosTextlist.Count >= 1)
                        {
                            Destroy(WayPosTextlist[i - 1]);
                            WayPosTextlist.RemoveAt(i - 1);
                        }
                        else
                        {
                            GoalPosText.transform.GetChild(0).GetComponent<Text>().text = "";
                            GoalPosText.transform.GetChild(1).gameObject.SetActive(true);
                            WayImg.SetActive(true);
                            GoalPosText.GetComponent<RectTransform>().anchoredPosition = new Vector2(24, -156);
                        }
                    }
                    break;
                }
            }

            float y = -94;
            for (int i = 0; i < WayPosTextlist.Count; i++)
            {
                WayPosTextlist[i].transform.GetChild(0).GetComponent<Text>().text = Posnamelist[i + 1];
                WayPosTextlist[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(24, y);
                y -= 62;
            }
            if(Posnamelist.Count!=0)
            {
                GoalPosText.transform.GetChild(0).GetComponent<Text>().text = Posnamelist[0];
                GoalPosText.GetComponent<RectTransform>().anchoredPosition = new Vector2(24, y);
            }
        }
    }

    public void Reset()
    {
        for(int i = 0; i < WayPosTextlist.Count; i++)
        {
            Destroy(WayPosTextlist[i]);
        }
        WayPosTextlist.Clear();
        for(int i=0; i<ResultPrefablist.Count; i++)
        {
            Destroy(ResultPrefablist[i]);
        }
        ResultPrefablist.Clear();
        road.OffRoad();
        laitudelist.Clear();
        longitudelist.Clear();
        Posnamelist.Clear();
        GoalPosText.GetComponent<RectTransform>().anchoredPosition= new Vector2(24, -153);
        WayImg.SetActive(true);
        GoalPosText.transform.GetChild(0).GetComponent<Text>().text = "";
        GoalPosText.transform.GetChild(1).gameObject.SetActive(true);
        Info.SetActive(false);
        road.Car.GetComponent<RectTransform>().anchoredPosition = new Vector2(894, -465);
            
    }
}
