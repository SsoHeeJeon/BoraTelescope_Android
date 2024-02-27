using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangaugeText : MonoBehaviour
{
    [SerializeField][TextArea]
    string Kor;
    [SerializeField][TextArea]
    string Eng;
    [SerializeField][TextArea]
    string Chi;
    [SerializeField][TextArea]
    string Jap;
        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                GetComponent<Text>().text = Kor;
                break;
            case GameManager.LangState.English:
                GetComponent<Text>().text = Eng;
                break;
            case GameManager.LangState.Chienses:
                GetComponent<Text>().text = Chi;
                break;
            case GameManager.LangState.Japan:
                GetComponent<Text>().text = Jap;
                break;
        }
    }
}
