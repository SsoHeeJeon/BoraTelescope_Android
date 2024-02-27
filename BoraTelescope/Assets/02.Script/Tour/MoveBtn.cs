using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Linq;

public class MoveBtn : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    DirectionManager dir;

    public List<GameObject> WholeList = new List<GameObject>();
    public float y;

    // Start is called before the first frame update
    public void OnBeginDrag(PointerEventData eventData)
    {
        WholeList.Clear();
        WholeList.Add(dir.GoalPosText);
        for (int i = 0; i < dir.WayPosTextlist.Count; i++)
        {
            WholeList.Add(dir.WayPosTextlist[i]);
        }
        y = transform.parent.GetComponent<RectTransform>().anchoredPosition.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.localPosition = new Vector3(transform.parent.localPosition.x, eventData.position.y, 0);
        transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(24, Mathf.Clamp(transform.parent.GetComponent<RectTransform>().anchoredPosition.y, (dir.Posnamelist.Count * -62) - 32, -92));

        for(int i=0; i< WholeList.Count; i++)
        {
            if(gameObject.transform.parent.gameObject != WholeList[i])
            {
                float distance = Mathf.Abs(WholeList[i].GetComponent<RectTransform>().anchoredPosition.y - transform.parent.GetComponent<RectTransform>().anchoredPosition.y);
                if(distance<2)
                {
                    float yy = WholeList[i].GetComponent<RectTransform>().anchoredPosition.y;
                    WholeList[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(WholeList[i].GetComponent<RectTransform>().anchoredPosition.x, y);
                    y = yy;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(transform.parent.GetComponent<RectTransform>().anchoredPosition.x, y);
        for(int i=0; i<WholeList.Count-1; i++)
        {
            for(int j = i+1; j< WholeList.Count; j++) 
            {
                if (WholeList[i].GetComponent<RectTransform>().anchoredPosition.y < WholeList[j].GetComponent<RectTransform>().anchoredPosition.y)
                {
                    GameObject obj = WholeList[i];
                    WholeList[i] = WholeList[j];
                    WholeList[j] = obj;
                }
            }
        }

        int index = -1;
        for(int i=0; i<WholeList.Count; i++)
        {
            if(dir.GoalPosText == WholeList[i])
            {
                index = i;
                break;
            }
        }

        float yy = WholeList[index].GetComponent<RectTransform>().anchoredPosition.y;
        string txt = WholeList[index].transform.GetChild(0).GetComponent<Text>().text;
        WholeList[index].GetComponent<RectTransform>().anchoredPosition = WholeList[WholeList.Count - 1].GetComponent<RectTransform>().anchoredPosition;
        WholeList[index].transform.GetChild(0).GetComponent<Text>().text = WholeList[WholeList.Count - 1].transform.GetChild(0).GetComponent<Text>().text;
        WholeList[WholeList.Count - 1].GetComponent<RectTransform>().anchoredPosition = new Vector2(WholeList[WholeList.Count - 1].GetComponent<RectTransform>().anchoredPosition.x, yy);
        WholeList[WholeList.Count - 1].transform.GetChild(0).GetComponent<Text>().text = txt;

        GameObject obj2 = WholeList[index];
        WholeList[index] = WholeList[WholeList.Count - 1];
        WholeList[WholeList.Count - 1] = obj2;

        List<string> Lait = new List<string>();
        List<string> Long = new List<string>();
        List<string> Name = new List<string>();

        int[] Check = new int[WholeList.Count];
        for(int i=0; i<WholeList.Count; i++)
        {
            for(int j=0; j<dir.Posnamelist.Count; j++)
            {
                if(WholeList[i].transform.GetChild(0).GetComponent<Text>().text == dir.Posnamelist[j])
                {
                    Check[i] = j;
                }
            }
        }

        for(int i=0; i<WholeList.Count;i++)
        {
            Lait.Add(dir.laitudelist[Check[i]]);
            Long.Add(dir.longitudelist[Check[i]]);
            Name.Add(dir.Posnamelist[Check[i]]);
        }
        string goal = Name[Name.Count - 1];
        string goallong = Long[Long.Count-1];
        string goallait = Lait[Lait.Count-1];
        for(int i= Name.Count-1; i>0; i--)
        {
            Name[i] = Name[i-1];
            Long[i] = Long[i-1];
            Lait[i] = Lait[i - 1]; 
        }
        Name[0] = goal;
        Long[0] = goallong;
        Lait[0] = goallait;


        dir.laitudelist = Lait;
        dir.longitudelist = Long;
        dir.Posnamelist= Name;
    }


}
