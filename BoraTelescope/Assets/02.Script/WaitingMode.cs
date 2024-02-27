using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class WaitingMode : MonoBehaviour
{
    GameManager gamemanager;

    private void Start()
    {
        foreach (Process process in Process.GetProcesses())
        {
            if (process.ProcessName.StartsWith("XRTeleSpinCam"))
            {
                process.Kill();
            }
        }

        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //gamemanager.GetComponent<PantiltMove>().SendMessage("o");
        gamemanager.waitingcheckstate = WaitingCheckState.Check;

    }



    public void OnClickBtn()
    {
        if(gamemanager.state == State.NoDemo)
        {
            gamemanager.OnClickLotte();
        }
    }
}
