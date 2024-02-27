using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
using UnityEditor.UIElements;

public class PinchZoom : MonoBehaviour
{
    [SerializeField]
    GameManager gamemanager;
    [SerializeField]
    RectTransform Zoombar;
    [SerializeField]
    public Text ZoomValue;
    public enum ZoomState
    {
        SmallZoom,
        BigZoom,
        SmallZooming,
        BigZooming,
        None,
    }
    public ZoomState zoomstate = 0;

    private void Update()
    {   if(SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            float value = 0;
            float bar_y = (gamemanager.clearMode.Main.transform.parent.gameObject.transform.position.z - ClearMode.MaxZoomOut) / (ClearMode.MaxZoomIn - ClearMode.MaxZoomOut) * 49 - 18.5f;
            Zoombar.transform.localPosition = new Vector3(0, bar_y, 0);
            //ZoomValue.text = (Mathf.Abs((float)gamemanager.xrMode.GetComponent<ZoomInOut>().zoomFactor) * 5).ToString();
            gamemanager.clearMode.Main.transform.GetChild(0).gameObject.GetComponent<Camera>().orthographicSize = -gamemanager.clearMode.Main.transform.parent.gameObject.transform.position.z + 2516;
            if (Input.touchCount >= 2 && (zoomstate == ZoomState.BigZoom || zoomstate == ZoomState.SmallZoom || zoomstate == ZoomState.None))
            {
                PosValue = (Input.touches[0].position + Input.touches[1].position) / 2;
                Xposvalue = PosValue.x - 960;
                Yposvalue = PosValue.y - 540;
                if (dist != 0)
                {
                    storedist = dist;
                }
                dist = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

                if (storedist != 0)
                {
                    float distspeed = dist - storedist;
                    speed = Mathf.Abs(distspeed / 2f);
                }

                if(Input.touches[0].phase == TouchPhase.Moved || Input.touches[1].phase == TouchPhase.Moved)
                {
                    StartPinchZoom();
                }
            }
            else
            {
                Xposvalue = 0;
                Yposvalue = 0;
                OldTouchDis = 0;
                m_fFieldOfView = 0;
                PosValue = Vector2.zero;
            }
            switch (zoomstate)
            {
                case ZoomState.BigZooming:
                    gamemanager.clearMode.Main.transform.parent.transform.localPosition = 
                        Vector3.Lerp(gamemanager.clearMode.Main.transform.parent.transform.localPosition,
                        new Vector3(gamemanager.clearMode.Main.transform.parent.transform.localPosition.x, 
                        gamemanager.clearMode.Main.transform.parent.transform.localPosition.y, ClearMode.MaxZoomIn), Time.deltaTime*3);

                    gamemanager.clearMode.MoveZoomOut();
                    value = (gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - (ClearMode.MaxZoomOut)) / ((ClearMode.MaxZoomIn - ClearMode.MaxZoomOut) / 100);
                    value = 100 - value;
                    for (int i=0; i< gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
                    {
                        gamemanager.clearMode.AllMapLabels.transform.GetChild(i).localScale = new Vector3(gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value));
                    }

                    if (SceneManager.GetActiveScene().name.Contains("Aegibong"))
                    {
                        for (int i = 0; i < gamemanager.clearMode.disablelabel.HiddenObj_s.Length; i++)
                        {
                            gamemanager.clearMode.disablelabel.HiddenObj_s[i].transform.localScale = new Vector3(gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value));
                        }
                    }

                    if (Mathf.Abs(gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - ClearMode.MaxZoomIn) <= 1f)
                    { 
                        gamemanager.clearMode.Main.transform.parent.transform.localPosition = 
                            new Vector3(gamemanager.clearMode.Main.transform.parent.transform.localPosition.x,
                            gamemanager.clearMode.Main.transform.parent.transform.localPosition.y, ClearMode.MaxZoomIn);
                        zoomstate = ZoomState.BigZoom;
                    }
                    break;
                case ZoomState.SmallZooming:
                    gamemanager.clearMode.Main.transform.parent.transform.localPosition =
                        Vector3.Lerp(gamemanager.clearMode.Main.transform.parent.transform.localPosition, 
                        new Vector3(gamemanager.clearMode.Main.transform.parent.transform.localPosition.x, 
                        gamemanager.clearMode.Main.transform.parent.transform.localPosition.y, ClearMode.MaxZoomOut), Time.deltaTime*3);

                    gamemanager.clearMode.MoveZoomOut();
                    value = (gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - (ClearMode.MaxZoomOut)) / ((ClearMode.MaxZoomIn - ClearMode.MaxZoomOut) / 100);
                    value = 100 - value;
                    for (int i = 0; i < gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
                    {
                        gamemanager.clearMode.AllMapLabels.transform.GetChild(i).localScale = new Vector3(gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value));
                    }

                    if (SceneManager.GetActiveScene().name.Contains("Aegibong"))
                    {
                        for (int i = 0; i < gamemanager.clearMode.disablelabel.HiddenObj_s.Length; i++)
                        {
                            gamemanager.clearMode.disablelabel.HiddenObj_s[i].transform.localScale = new Vector3(gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value));
                        }
                    }

                    if (Mathf.Abs(gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - ClearMode.MaxZoomOut) <= 1f)
                    {
                        gamemanager.clearMode.Main.transform.parent.transform.localPosition = 
                            new Vector3(gamemanager.clearMode.Main.transform.parent.transform.localPosition.x,
                            gamemanager.clearMode.Main.transform.parent.transform.localPosition.y, ClearMode.MaxZoomOut);
                        zoomstate = ZoomState.SmallZoom;
                    }
                    break;
            }
        }
        
    }

    public void ZoomBtn()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            if (zoomstate == ZoomState.SmallZoom)
            {
                zoomstate = ZoomState.BigZooming;
            }
            else if (zoomstate == ZoomState.BigZoom)
            {
                zoomstate = ZoomState.SmallZooming;
            }
            else if(zoomstate == ZoomState.SmallZooming)
            {
                zoomstate = ZoomState.BigZooming;
            }
            else if (zoomstate == ZoomState.BigZooming)
            {
                zoomstate = ZoomState.SmallZooming;
            }
            else if(zoomstate == ZoomState.None)
            {
                zoomstate = ZoomState.SmallZooming;
            }
        }

    }

    Vector2 PosValue;
    float OldTouchDis = 0;
    float m_fFieldOfView = 1851;
    float Xposvalue;
    float Yposvalue;
    public float zoomvalue;
    float x = 0;
    float y = 0;
    float dist;
    float storedist;
    float speed;

    public void StartPinchZoom()
    {
        float TouchDis = (Input.touches[0].position - Input.touches[1].position).sqrMagnitude;  
        float fDis = 0f;
        if(OldTouchDis!=0)
        {
            fDis = TouchDis - OldTouchDis;
            if(SceneManager.GetActiveScene().name.Contains("ClearMode"))
            {
                if(fDis>0)
                {
                    gamemanager.clearMode.Main.transform.parent.transform.localPosition =
                    Vector3.Lerp(gamemanager.clearMode.Main.transform.parent.transform.localPosition,
                    new Vector3(gamemanager.clearMode.Main.transform.parent.transform.localPosition.x,
                    gamemanager.clearMode.Main.transform.parent.transform.localPosition.y, ClearMode.MaxZoomIn), Time.deltaTime * 4);
                }
                else if(fDis<0)
                {
                    gamemanager.clearMode.Main.transform.parent.transform.localPosition =
                    Vector3.Lerp(gamemanager.clearMode.Main.transform.parent.transform.localPosition,
                    new Vector3(gamemanager.clearMode.Main.transform.parent.transform.localPosition.x,
                    gamemanager.clearMode.Main.transform.parent.transform.localPosition.y, ClearMode.MaxZoomOut), Time.deltaTime * 4);
                }

                float value = 0;
                value = (gamemanager.clearMode.Main.transform.parent.transform.localPosition.z - (ClearMode.MaxZoomOut)) / ((ClearMode.MaxZoomIn - ClearMode.MaxZoomOut) / 100);
                value = 100 - value;
                for (int i = 0; i < gamemanager.clearMode.AllMapLabels.transform.childCount; i++)
                {
                    gamemanager.clearMode.AllMapLabels.transform.GetChild(i).localScale = new Vector3(gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value));
                }


                if (SceneManager.GetActiveScene().name.Contains("Aegibong"))
                {
                    for (int i = 0; i < gamemanager.clearMode.disablelabel.HiddenObj_s.Length; i++)
                    {
                        gamemanager.clearMode.disablelabel.HiddenObj_s[i].transform.localScale = new Vector3(gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value), gamemanager.clearMode.MinZoomValue + (gamemanager.clearMode.MaxZoomValue * value));
                    }
                }


                if (zoomstate != ZoomState.BigZooming && zoomstate!=ZoomState.SmallZooming)
                {
                    zoomvalue = (gamemanager.clearMode.Main.transform.parent.gameObject.transform.position.z - 2451) / -600;
                    Xposvalue *= zoomvalue;
                    Yposvalue *= zoomvalue;
                    x = gamemanager.clearMode.Main.transform.position.x + Xposvalue;
                    y = gamemanager.clearMode.Main.transform.position.y + Yposvalue;
                }
                gamemanager.clearMode.Main.transform.localPosition = Vector2.Lerp(gamemanager.clearMode.Main.transform.position, new Vector2(x, y), Time.deltaTime * speed);
                gamemanager.clearMode.Main.transform.localPosition = new Vector3(gamemanager.clearMode.Main.transform.position.x, gamemanager.clearMode.Main.transform.position.y, ClearMode.Cameraz);
                gamemanager.clearMode.MoveZoomOut();  
            }
        }
        OldTouchDis = TouchDis;
    }
}
