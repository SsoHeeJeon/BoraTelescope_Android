using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceManager : MonoBehaviour
{
    enum State
    {
        Picture,
        Nothing,
    }
    State state = 0;
    [SerializeField]
    GameObject SpaceNothing;
    [SerializeField]
    GameObject SpacePicture;

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

        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gamemanager.UI_All.SetActive(false);
    }


    public void OnClickLotteBtn()
    {
        gamemanager.OnClickLotte();
    }

    public void Chagne(GameObject obj)
    {
        if(state == State.Picture)
        {
            obj.transform.GetChild(0).gameObject.SetActive(false);
            SpacePicture.SetActive(false);
            SpaceNothing.SetActive(true);
            state = State.Nothing;
        }
        else
        {
            obj.transform.GetChild(0).gameObject.SetActive(true);
            SpacePicture.SetActive(true);
            SpaceNothing.SetActive(false);
            state = State.Picture;
        }
    }
}
