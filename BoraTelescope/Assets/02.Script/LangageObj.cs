using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangageObj : MonoBehaviour
{
    public GameObject Kor;
    public GameObject Eng;
    public GameObject Chi;
    public GameObject Jap;

    public List<GameObject> LangList = new List<GameObject>();

    private void Start()
    {
        LangList.Add(Kor);
        LangList.Add(Eng);
        LangList.Add(Chi);
        LangList.Add(Jap);
    }
}
