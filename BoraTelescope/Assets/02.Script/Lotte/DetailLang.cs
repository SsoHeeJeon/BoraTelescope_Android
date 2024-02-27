using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailLang : MonoBehaviour
{
    [SerializeField]
    GameObject EObj;
    void Update()
    {
        if(GameManager.langstate == GameManager.LangState.English)
        {
            EObj.GetComponent<Image>().enabled = true;
        }
        else
        {
            EObj.GetComponent<Image>().enabled = false;
        }
    }
}
