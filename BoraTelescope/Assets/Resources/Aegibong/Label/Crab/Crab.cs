using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crab : MonoBehaviour
{
    GameManager gamemanager;
    public Animator MoveCrab;
    public Animator Crab_ani;

    public Vector3 Startposition;

    bool movestop = false;
    bool ResetSet = false;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            Crab_ani.SetBool("Move", true);
        } else if (SceneManager.GetActiveScene().name.Contains("XRMode"))
        {
            MoveCrab.SetBool("XR", true);
        }
    }

    public void WalkRight()
    {
        Crab_ani.SetBool("Left", false);
        Crab_ani.SetBool("Right", true);
        Crab_ani.SetBool("Move", true);
    }

    public void WalkLeft()
    {
        Crab_ani.SetBool("Right", false);
        Crab_ani.SetBool("Left", true);
        Crab_ani.SetBool("Move", true);
    }

    public void SitEat()
    {
        Crab_ani.SetBool("Right", false);
        Crab_ani.SetBool("Left", false);
        Crab_ani.SetBool("Move", false);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (movestop == false)
        {
            if (gamemanager.labeldetail.SeeLabelDetail == true && gamemanager.labeldetail.SeeDetail_Open == true)
            {
                if (SceneManager.GetActiveScene().name.Contains("XRMode"))
                {
                    if (gamemanager.xrmode.SelectLabel.name == "Crab")
                    {
                        SelectCrab();
                    }
                    else
                    {
                        FinishSelect();
                    }
                }
                else if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
                {
                    if (gamemanager.clearmode.clicknaviobj.name == "Crab")
                    {
                        SelectCrab();
                    }
                    else
                    {
                        FinishSelect();
                    }
                }
            }
            else
            {
                FinishSelect();
            }
        }

        if (ResetSet == true)
        {
            if(Vector3.Distance(Crab_ani.gameObject.transform.position, Startposition) <= 0.5f)
            {
                WalkLR();
            }
        }
    }

    public void SelectCrab()
    {
        movestop = true;
        MoveCrab.SetBool("Move",false);
        MoveCrab.GetBool("Move");
    }

    public void FinishSelect()
    {
        movestop = false;
        MoveCrab.SetBool("Move", true);
        MoveCrab.GetBool("Move");

        Crab_ani.gameObject.transform.position = Startposition;
        ResetSet = true;
    }

    public void WalkLR()
    {

    }*/
}
