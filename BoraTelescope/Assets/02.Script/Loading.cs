using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public enum CheckState
    {
        None,
        check,
        Move,
        MoveCheckgt,
        MoveCheckgp,
    }
    public CheckState checstate = 0;

    public static string nextScene;

    public Thread ReadThread;
    public static Thread staticReadThread;
   


    GameManager gamemanager;
    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gamemanager.UI_All.SetActive(false);
        if(nextScene == null)
        {
            nextScene = "ClearModeLotte";
        }
        LoadScene(nextScene);
        gamemanager.modeonoff.CultureOut();
        
    }


    public void LoadScene(string Scene)
    {
        StartCoroutine(RealMove(Scene));
    }

    IEnumerator RealMove(string scene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }
}
