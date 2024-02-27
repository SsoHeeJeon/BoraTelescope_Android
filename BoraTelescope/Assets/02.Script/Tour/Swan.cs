using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swan : MonoBehaviour
{
    public GameObject Island;
    public Animator SwanMove;
    public Animator SwanAni;

    public void StartAni()
    {
        SwanMove.SetBool("Click", true);

        //Invoke("finishAni", 1f);
    }

    public void finishAni()
    {
        SwanMove.SetBool("Click", false);
    }

    public void SeeSwanMove()
    {
        SwanAni.gameObject.SetActive(true);
        SwanAni.SetBool("Flap", true);
        SwanAni.SetBool("Rebirth", false);
    }
    public void SeeSwanGlide()
    {
        SwanAni.SetBool("Glide", true);
        SwanAni.SetBool("Flap", false);
    }

    public void LikeIsland()
    {
        SwanAni.SetBool("Rebirth", true);
        SwanAni.SetBool("Glide", false);
    }

    public void LookIsland()
    {
        Island.SetActive(true);
    }

    public void HideIsland()
    {
        Island.SetActive(false);
        SwanAni.gameObject.SetActive(true);
    }
}
