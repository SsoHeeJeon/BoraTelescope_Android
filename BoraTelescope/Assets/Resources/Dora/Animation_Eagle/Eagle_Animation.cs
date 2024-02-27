using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_Animation : MonoBehaviour
{
    public Animator Eagle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Eagle.gameObject.transform.localPosition = new Vector3(0,0,0);
        Eagle.gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
        //Eagle.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void Idle()
    {
        Eagle.SetBool("Glide", false);
        Eagle.SetBool("Fly", false);
        Eagle.SetBool("FlyLeft", false);
        Eagle.SetBool("FlyRight", false);
        Eagle.SetBool("Landing", false);
        Eagle.SetBool("TakeOff", false);
    }

    public void Glide_eagle()
    {
        Eagle.SetBool("Glide", true);
        Eagle.SetBool("Fly", false);
        Eagle.SetBool("FlyLeft", false);
        Eagle.SetBool("FlyRight", false);
        Eagle.SetBool("Landing", false);
        Eagle.SetBool("TakeOff", false);
    }

    public void Fly_Eagle()
    {
        Eagle.SetBool("Glide", false);
        Eagle.SetBool("Fly", true);
        Eagle.SetBool("FlyLeft", false);
        Eagle.SetBool("FlyRight", false);
        Eagle.SetBool("TakeOff", false);
        Eagle.SetBool("Landing", false);
    }

    public void FlyLeft_Eagle()
    {
        Eagle.SetBool("Glide", false);
        Eagle.SetBool("Fly", true);
        Eagle.SetBool("FlyLeft", true);
        Eagle.SetBool("FlyRight", false);
    }

    public void FlyRight_Eagle()
    {
        Eagle.SetBool("Glide", false);
        Eagle.SetBool("Fly", true);
        Eagle.SetBool("FlyLeft", false);
        Eagle.SetBool("FlyRight", true);
    }

    public void Landing_Eagle()
    {
        Eagle.SetBool("Landing", true);
        Eagle.SetBool("Fly", false);
        Eagle.SetBool("Glide", false);
    }

    public void TakeOff_Eagle()
    {
        Eagle.SetBool("Glide", false);
        Eagle.SetBool("TakeOff", false);
        Eagle.SetBool("Fly", true);
    }
}
