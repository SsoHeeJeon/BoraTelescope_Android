using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seal : MonoBehaviour
{
    public Animator SealMove;
    public Animator Seal_ani;

    public void IdlePlay()
    {
        Seal_ani.SetBool("Idle", true);
        Seal_ani.SetBool("Up", false);
    }

    public void ClickLabel()
    {
        SealMove.SetBool("Click", true);
        Seal_ani.SetBool("Click", true);
        Seal_ani.SetBool("Idle", false);
    }

    public void DownRock()
    {
        Seal_ani.SetBool("Down", true);
    }

    public void JumpSeal()
    {
        SealMove.SetBool("Click", false);
        Seal_ani.SetBool("Jump", true);
        Seal_ani.SetBool("Down", false);
        Seal_ani.SetBool("Click", false);

        Invoke("FinishJump", 1f);
    }

    public void FinishJump()
    {
        Seal_ani.SetBool("Jump", false);
    }

    public void UpRock()
    {
        Seal_ani.SetBool("Up", true);
        Seal_ani.SetBool("Jump", false);
        Seal_ani.SetBool("Idle", true);
    }
}
