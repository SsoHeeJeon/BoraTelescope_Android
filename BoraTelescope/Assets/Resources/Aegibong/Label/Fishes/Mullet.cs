using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mullet : MonoBehaviour
{
    public Animator Action;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("XRMode"))
        {
            Action.SetBool("XR", true);
        } else if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            Action.SetBool("XR", false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpFish()
    {
        Action.SetBool("Jump", true);
    }

    public void SwimFish()
    {
        Action.SetBool("Jump", false);
    }
}
