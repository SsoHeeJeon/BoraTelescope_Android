using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Langague : MonoBehaviour
{
    [SerializeField]
    Image obj;

    public Sprite[] sp = new Sprite[4];

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.langstate)
        {
            case GameManager.LangState.Korea:
                obj.sprite = sp[0];
                break;
            case GameManager.LangState.English:
                obj.sprite = sp[1];
                break;
            case GameManager.LangState.Chienses:
                obj.sprite = sp[2];
                break;
            case GameManager.LangState.Japan:
                obj.sprite = sp[3];
                break;
        }
        obj.SetNativeSize();
    }
}
