using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XRLabelSettingManager : MonoBehaviour
{
    public List<Vector3> ClearPos = new List<Vector3>();
    public List<Vector3> XRPos = new List<Vector3>(); 
    GameManager gamemanager;

    public float ValueXMin;
    public float ValueXMax;
    public float ValueYMin;
    public float ValueYMax;

    public float ClearXMin;
    public float ClearXMax;
    public float ClearYMin;
    public float ClearYMax;

    public float ValueX;
    public float ValueY;
    private void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ValueX = gamemanager.GetComponent<ReadJsonFile>().TotalPan;
        ValueY = gamemanager.GetComponent<ReadJsonFile>().TotalTilt;
    }

    public void OnClickClearLabelPos()
    {
        if(SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            ClearPos.Clear();
            for(int i =0; i< gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
            {
                ClearPos.Add(gamemanager.clearMode.AllMapLabels.transform.GetChild(i).transform.position); 
            }
            ClearXMin = gamemanager.clearMode.min_x;
            ClearXMax = gamemanager.clearMode.max_x;
            ClearYMin = gamemanager.clearMode.min_y;
            ClearYMax = gamemanager.clearMode.max_y;
        }

        SetiingX = Math.Abs(ClearXMax - ClearXMin) / Math.Abs(gamemanager.GetComponent<ReadJsonFile>().MaxPan - gamemanager.GetComponent<ReadJsonFile>().MinPan);
        SetiingY = Math.Abs(ClearYMax - ClearYMin) / Math.Abs(gamemanager.GetComponent<ReadJsonFile>().MaxTilt - gamemanager.GetComponent<ReadJsonFile>().MinTilt);
    }

    public void CalValue(GameObject obj)
    {
        switch(obj.name)
        {
            case "ValueX":
                ValueX = 1920 / Mathf.Abs(ValueXMax - ValueXMin);
                break;

            case "ValueY":
                ValueY = 1080 / Mathf.Abs(ValueYMax - ValueYMin);
                break;
        }
    }

    public void SettingXPlus()
    {
        SetiingX += 0.1f;
    }

    public void SettingXMinus()
    {
        SetiingX -= 0.1f;
    }

    public void SettingYPlus()
    {
        SetiingY += 0.1f;
    }

    public void SettingYMinus()
    {
        SetiingY -= 0.1f;
    }

    public float SetiingX;
    public float SetiingY;
    public void SettingWhole()
    {
        XRPos.Clear();

        for (int i=0; i<ClearPos.Count; i++)
        {
            float Xpos = Math.Abs((ClearPos[i].x - ClearXMin) / SetiingX);
            float xpos = gamemanager.GetComponent<ReadJsonFile>().MinPan + Xpos;

            float Ypos = Math.Abs((ClearPos[i].y - ClearYMin) / SetiingY);
            float ypos = gamemanager.GetComponent<ReadJsonFile>().MinTilt + Ypos;

            XRPos.Add(new Vector3(xpos, ypos, 0));
        }

    }
}
