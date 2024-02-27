using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falcon : MonoBehaviour
{
    private Animator falcon;
    public GameObject MainCamera;

	void Start ()
    {
        falcon = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if ((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.F))||(Input.GetKeyUp(KeyCode.X))||(Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.D)))
        {
            falcon.SetBool("idle", true);
            falcon.SetBool("walk", false);
            falcon.SetBool("glide", false);
            falcon.SetBool("fly", true);
            falcon.SetBool("hunt", false);
            falcon.SetBool("attack", false);
            falcon.SetBool("flyleft", false);
            falcon.SetBool("flyright", false);
            falcon.SetBool("turnleft", false);
            falcon.SetBool("turnright", false);
        }
        if (falcon.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            falcon.SetBool("takeoff", false);
            falcon.SetBool("landing", false);
            falcon.SetBool("fly", false);
            falcon.SetBool("hunt", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            falcon.SetBool("walk", true);
            falcon.SetBool("idle", false);
            falcon.SetBool("turnleft", false);
            falcon.SetBool("turnright", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            falcon.SetBool("takeoff", true);
            falcon.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            falcon.SetBool("landing", true);
            falcon.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            falcon.SetBool("glide", true);
            falcon.SetBool("fly", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            falcon.SetBool("hunt", true);
            falcon.SetBool("fly", false);
            falcon.SetBool("glide", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            falcon.SetBool("fly", false);
            falcon.SetBool("attack", true);
            falcon.SetBool("turnright", false);
            falcon.SetBool("walk", true);
            falcon.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            falcon.SetBool("flyleft", true);
            falcon.SetBool("fly", false);
            falcon.SetBool("turnleft", true);
            falcon.SetBool("walk", false);
            falcon.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            falcon.SetBool("flyright", true);
            falcon.SetBool("fly", false);
            falcon.SetBool("turnright", true);
            falcon.SetBool("walk", false);
            falcon.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            MainCamera.GetComponent<CameraFollow>().enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            MainCamera.GetComponent<CameraFollow>().enabled = true;
        }
	}
}
