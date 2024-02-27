using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class see360Btn : MonoBehaviour
{
    public GameObject obj360;
    [SerializeField]
    Material Video360;
    public int count = 0;
    public List<Sprite> splist = new List<Sprite>();
    public void OnClickBtn()
    {
        Video360.SetTexture("_MainTex", splist[count].texture);
        SetRotation(splist[count].texture.name);
        if (count >= splist.Count - 1)
        {
            count = 0;
        }
        else
        {
            count++;
        }
    }

    public void SetRotation(string name)
    {
        switch (name)
        {
            case "1.Front":
                obj360.transform.rotation = Quaternion.Euler(357, 220, 0);
                break;
            case "2.Back":
                obj360.transform.rotation = Quaternion.Euler(357, 140, 0);
                break;
            case "11_1. 심청각_앞_오전":
                obj360.transform.rotation = Quaternion.Euler(5, 185, 0);
                break;
            case "11_2. 심청각_앞_오후":
                obj360.transform.rotation = Quaternion.Euler(0, 180, 352.5f);
                break;
            case "11_3. 심청각_뒤_오후":
                obj360.transform.rotation = Quaternion.Euler(357, 120, 0);
                break;
        }
        GameManager gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

}
