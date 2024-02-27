using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootConDolphin : MonoBehaviour
{
    public Animator Dolphin;
    public Animator Dolphin_1;
    public Animator Dolphin_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dolphin.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        Dolphin.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        Dolphin_1.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        Dolphin_1.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

        Dolphin_2.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        Dolphin_2.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //Dolphin.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }
    /*
    public void Idle()
    {
        Dolphin.SetBool("Swim", false);
        Dolphin.SetBool("Jump", false);
        Dolphin.SetBool("HIgh", false);
        Dolphin.SetBool("Turn", false);
        Dolphin.SetBool("Verticle", false);
        Dolphin.SetBool("Back", false);
    }
    */
    public void Dolphin_Swim()
    {
        Dolphin.SetBool("Swim", true);
        Dolphin.SetBool("Jump", false);
        Dolphin.SetBool("HIgh", false);
        Dolphin.SetBool("Turn", false);
        Dolphin.SetBool("Verticle", false);
        Dolphin.SetBool("Back", false);

        Dolphin_1.SetBool("Swim", true);
        Dolphin_1.SetBool("Jump", false);
        Dolphin_1.SetBool("HIgh", false);
        Dolphin_1.SetBool("Turn", false);
        Dolphin_1.SetBool("Verticle", false);
        Dolphin_1.SetBool("Back", false);

        Dolphin_2.SetBool("Swim", true);
        Dolphin_2.SetBool("Jump", false);
        Dolphin_2.SetBool("HIgh", false);
        Dolphin_2.SetBool("Turn", false);
        Dolphin_2.SetBool("Verticle", false);
        Dolphin_2.SetBool("Back", false);
    }

    public void Dolphin_Jump()
    {
        Dolphin.SetBool("Swim", true);
        Dolphin.SetBool("Jump", true);
        Dolphin.SetBool("HIgh", false);
        Dolphin.SetBool("Turn", false);
        Dolphin.SetBool("Verticle", false);
        Dolphin.SetBool("Back", false);

        Dolphin_1.SetBool("Swim", true);
        Dolphin_1.SetBool("Jump", true);
        Dolphin_1.SetBool("HIgh", false);
        Dolphin_1.SetBool("Turn", false);
        Dolphin_1.SetBool("Verticle", false);
        Dolphin_1.SetBool("Back", false);

        Dolphin_2.SetBool("Swim", true);
        Dolphin_2.SetBool("Jump", true);
        Dolphin_2.SetBool("HIgh", false);
        Dolphin_2.SetBool("Turn", false);
        Dolphin_2.SetBool("Verticle", false);
        Dolphin_2.SetBool("Back", false);
    }

    public void Dolphin_JumpHigh()
    {
        Dolphin.SetBool("Swim", true);
        Dolphin.SetBool("Jump", false);
        Dolphin.SetBool("HIgh", true);
        Dolphin.SetBool("Turn", false);
        Dolphin.SetBool("Verticle", false);
        Dolphin.SetBool("Back", false);

        Dolphin_1.SetBool("Swim", true);
        Dolphin_1.SetBool("Jump", false);
        Dolphin_1.SetBool("HIgh", true);
        Dolphin_1.SetBool("Turn", false);
        Dolphin_1.SetBool("Verticle", false);
        Dolphin_1.SetBool("Back", false);

        Dolphin_2.SetBool("Swim", true);
        Dolphin_2.SetBool("Jump", false);
        Dolphin_2.SetBool("HIgh", true);
        Dolphin_2.SetBool("Turn", false);
        Dolphin_2.SetBool("Verticle", false);
        Dolphin_2.SetBool("Back", false);
    }

    public void Dolphin_Turn()
    {
        Dolphin.SetBool("Swim", true);
        Dolphin.SetBool("Jump", false);
        Dolphin.SetBool("HIgh", false);
        Dolphin.SetBool("Turn", true);
        Dolphin.SetBool("Verticle", false);
        Dolphin.SetBool("Back", false);

        Dolphin_1.SetBool("Swim", true);
        Dolphin_1.SetBool("Jump", false);
        Dolphin_1.SetBool("HIgh", false);
        Dolphin_1.SetBool("Turn", true);
        Dolphin_1.SetBool("Verticle", false);
        Dolphin_1.SetBool("Back", false);

        Dolphin_2.SetBool("Swim", true);
        Dolphin_2.SetBool("Jump", false);
        Dolphin_2.SetBool("HIgh", false);
        Dolphin_2.SetBool("Turn", true);
        Dolphin_2.SetBool("Verticle", false);
        Dolphin_2.SetBool("Back", false);
    }

    public void Dolphin_Verticle()
    {
        Dolphin.SetBool("Swim", true);
        Dolphin.SetBool("Jump", false);
        Dolphin.SetBool("HIgh", false);
        Dolphin.SetBool("Turn", false);
        Dolphin.SetBool("Verticle", true);
        Dolphin.SetBool("Back", false);

        Dolphin_1.SetBool("Swim", true);
        Dolphin_1.SetBool("Jump", false);
        Dolphin_1.SetBool("HIgh", false);
        Dolphin_1.SetBool("Turn", false);
        Dolphin_1.SetBool("Verticle", true);
        Dolphin_1.SetBool("Back", false);

        Dolphin_2.SetBool("Swim", true);
        Dolphin_2.SetBool("Jump", false);
        Dolphin_2.SetBool("HIgh", false);
        Dolphin_2.SetBool("Turn", false);
        Dolphin_2.SetBool("Verticle", true);
        Dolphin_2.SetBool("Back", false);
    }

    public void Dolphin_Back()
    {
        Dolphin.SetBool("Swim", true);
        Dolphin.SetBool("Jump", false);
        Dolphin.SetBool("HIgh", false);
        Dolphin.SetBool("Turn", false);
        Dolphin.SetBool("Verticle", false);
        Dolphin.SetBool("Back", true);

        Dolphin_1.SetBool("Swim", true);
        Dolphin_1.SetBool("Jump", false);
        Dolphin_1.SetBool("HIgh", false);
        Dolphin_1.SetBool("Turn", false);
        Dolphin_1.SetBool("Verticle", false);
        Dolphin_1.SetBool("Back", true);

        Dolphin_2.SetBool("Swim", true);
        Dolphin_2.SetBool("Jump", false);
        Dolphin_2.SetBool("HIgh", false);
        Dolphin_2.SetBool("Turn", false);
        Dolphin_2.SetBool("Verticle", false);
        Dolphin_2.SetBool("Back", true);
    }
}
