using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spoonbill : MonoBehaviour
{
    public ClearMode clearmode;

    public Animator MoveAnimal;
    public Animator AnimalAct;

    public void SelectSpoonbill()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
             MoveAnimal.SetBool("Move", true);
        }
    }

    public void Startglide()
    {
        AnimalAct.SetBool("Fly", true);
    }

    //public void ZoomOut()   // 라벨 선택하면 날기 시작하고 조금 있다가
    //{
    //    startMove = true;
    //    startZoomOut = true;

    //    if(startZoomChange == false && Mathf.Abs(clearmode.CameraWindow.transform.parent.gameObject.transform.position.z - 1851)<=0.1f)
    //    {
    //        movezoomt = 0;
    //        startZoomChange = true;
    //    }
    //    else if(startZoomChange == false && Mathf.Abs(clearmode.CameraWindow.transform.parent.gameObject.transform.position.z - 1851) > 0.1f)
    //    {
    //        Invoke("ZoomOut", 0.5f);
    //    }
    //}

    //public void ZoomIn()    // 한바퀴 날고 돌아올때
    //{
    //    movezoomt = 0;
    //    startMove = true;
    //    startZoomOut = false;
    //}

    public void StopSpoonbill_Move()
    {
        MoveAnimal.SetBool("Move", false);
        //startZoomChange = false;
    }

    public void StopSpoonbill_Act()
    {
        AnimalAct.SetBool("Fly", false);
    }
}
