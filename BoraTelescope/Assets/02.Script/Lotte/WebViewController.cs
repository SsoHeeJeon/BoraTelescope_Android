using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuplex.WebView;

public class WebViewController : MonoBehaviour
{
    [SerializeField]
    GameObject WebViewPrefab;
    [SerializeField]
    GameObject BackGround;
    GameObject CurrentWebview;

    GameManager gamemanager;

    private void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnClickBtn(GameObject name)
    {
        if(gamemanager.state == GameManager.State.NoDemo)
        {
            gamemanager.ErrorMessage.gameObject.SetActive(true);
        }
    }

    public void CloseWebView()
    {
        if(CurrentWebview != null)
        {
            BackGround.SetActive(false);
            gamemanager.UI_All.SetActive(true);
            Destroy(CurrentWebview);
            CurrentWebview = null;
        }
    }

}
