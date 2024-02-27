using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pos : MonoBehaviour
{
    public string longitude;
    public string latitude;
    public string PosName;
    [SerializeField]
    Text Currenttxt;
    DirectionManager Dir;
    private void Update()
    {
        if (Currenttxt.text != transform.GetChild(0).GetChild(0).GetComponent<Text>().text)
        {
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Currenttxt.text;
            transform.GetChild(0).GetChild(0).GetComponent<Text>().font = Currenttxt.font;
            if (transform.GetChild(0).GetChild(0).GetComponent<Text>().alignment == TextAnchor.MiddleRight)
            {
                transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = Currenttxt.GetComponent<RectTransform>().anchoredPosition - new Vector2(25, 0);
                transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta = Currenttxt.GetComponent<RectTransform>().sizeDelta;
                if(Currenttxt.text == "Cheonan Warship Memorial Tower")
                {
                    transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(-118, 6);
                }
                else if(Currenttxt.text == "The End Island Observatory")
                {
                    transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(118, -59);
                }
                else
                {
                    transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Currenttxt.transform.parent.GetComponent<RectTransform>().anchoredPosition;
                }
                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = Currenttxt.transform.parent.GetComponent<RectTransform>().sizeDelta;
            }
            else
            {
                transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().anchoredPosition = Currenttxt.GetComponent<RectTransform>().anchoredPosition;
                transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta = Currenttxt.GetComponent<RectTransform>().sizeDelta;
                if (Currenttxt.text == "Cheonan Warship Memorial Tower")
                {
                    transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(-118, 6);
                }
                else if (Currenttxt.text == "The End Island Observatory")
                {
                    transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector3(118, -59);
                }
                else
                {
                    transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Currenttxt.transform.parent.GetComponent<RectTransform>().anchoredPosition;
                }
                transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = Currenttxt.transform.parent.GetComponent<RectTransform>().sizeDelta;
            }

            if (Dir != null)
            {
                for (int i = 0; i < Dir.WayPosTextlist.Count; i++)
                {
                    if (Dir.WayPosTextlist[i].transform.GetChild(0).gameObject.GetComponent<Text>().text == PosName)
                    {
                        Dir.WayPosTextlist[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = Currenttxt.text;
                    }
                }
                for (int j = 0; j < Dir.Posnamelist.Count; j++)
                {
                    if (Dir.Posnamelist[j] == PosName)
                    {
                        Dir.Posnamelist[j] = Currenttxt.text;
                    }
                }

                if (Dir.GoalPosText.transform.GetChild(0).GetComponent<Text>().text == PosName)
                {
                    Dir.GoalPosText.transform.GetChild(0).GetComponent<Text>().text = Currenttxt.text;
                    Dir.Posnamelist[0] = Currenttxt.text;
                }
            }
            PosName = Currenttxt.text;
        }
    }

    public void OnClickDirBtn(DirectionManager dir)
    {
        Dir = dir;
        if(dir.gameObject.activeSelf)
        {
            if (dir.longitudelist.Count == 0)
            {
                //for (int index = 0; index < transform.parent.childCount; index++)
                //{
                //    if (transform.parent.GetChild(index).gameObject.name != "Observation")
                //    {
                //        transform.parent.GetChild(index).GetChild(1).GetChild(0).gameObject.SetActive(true);
                //    }
                //}
                dir.longitudelist.Add(longitude);
                dir.laitudelist.Add(latitude);
                dir.Posnamelist.Add(PosName);
                dir.GoalPosText.transform.GetChild(0).GetComponent<Text>().text = PosName;
                dir.GoalPosText.transform.GetChild(1).gameObject.SetActive(false);

                transform.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                dir.WayImg.SetActive(false);
                dir.GoalPosText.GetComponent<RectTransform>().anchoredPosition = new Vector2(24, -94);


            }
            else
            {
                for (int i=0; i<dir.longitudelist.Count; i++) 
                {
                    if (dir.longitudelist[i] == longitude && dir.laitudelist[i] == latitude)
                    {
                        transform.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                        dir.longitudelist.RemoveAt(i);
                        dir.laitudelist.RemoveAt(i);
                        dir.Posnamelist.RemoveAt(i);
                        if(i==0)
                        {
                            if(dir.longitudelist.Count!=0)
                            {
                                Destroy(dir.WayPosTextlist[0]);
                                dir.WayPosTextlist.RemoveAt(0);
                                dir.GoalPosText.transform.GetChild(0).GetComponent<Text>().text = dir.Posnamelist[0];
                            }
                            else
                            {
                                dir.GoalPosText.transform.GetChild(0).GetComponent<Text>().text = "";
                                dir.GoalPosText.transform.GetChild(1).gameObject.SetActive(true);
                            }
                        }
                        else
                        {
                            if(dir.WayPosTextlist.Count>=1)
                            {
                                Destroy(dir.WayPosTextlist[i-1]);
                                dir.WayPosTextlist.RemoveAt(i-1);
                            }
                            else
                            {
                                dir.GoalPosText.transform.GetChild(0).GetComponent<Text>().text = "";
                                dir.GoalPosText.transform.GetChild(1).gameObject.SetActive(true);
                            }
                        }
                        break;
                    }
                    else
                    {
                        if(dir.WayPosTextlist.Count<3)
                        {
                            if(i == dir.longitudelist.Count-1)
                            {
                                transform.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                                dir.longitudelist.Add(longitude);
                                dir.laitudelist.Add(latitude);
                                dir.Posnamelist.Add(PosName);
                                GameObject obj = Instantiate(dir.WayPosTextPrefab);
                                dir.WayPosTextlist.Add(obj);
                                obj.transform.parent = dir.WayPosTextPrefab.transform.parent;
                                obj.SetActive(true);
                                obj.transform.GetChild(0).gameObject.GetComponent<Text>().text = PosName;
                                break;
                            }
                        }
                    }
                }
            }

            float y = -94;
            for(int i=0; i<dir.WayPosTextlist.Count; i++)
            {
                dir.WayPosTextlist[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(24, y);
                y -= 62;
            }
            dir.GoalPosText.GetComponent<RectTransform>().anchoredPosition = new Vector2(24, y);

            //if(dir.longitude == "")   
            //{
            //    dir.longitude= longitude;
            //    dir.laitude= latitude;
            //}
            //else if(dir.longitude == longitude)
            //{
            //    dir.longitude = "";
            //    dir.laitude = "";
            //}
            //else
            //{
            //    dir.goallaitude= latitude;
            //    dir.goallongitude= longitude;
            //}
        }
    }

    //public void CheckLabel(GameObject label)
    //{
    //    if (label.name != "Observation")
    //    {
    //        label.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
    //    }
    //}
}
