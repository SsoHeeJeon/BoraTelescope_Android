using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set360Pano : MonoBehaviour
{
    public GameManager gamemanager;
    public GameObject SetPano;

    // Start is called before the first frame update
    void Start()
    {
        OffPano();
    }

    public void ReduceLoading()
    {
        //SetPano.SetActive(true);
        //SetPano.transform.parent = gamemanager.clearMode.Clear360Obj.transform;
        //SetPano.transform.localPosition = new Vector3(48068,743,0);
    }

    public void OffPano()
    {
        //SetPano.transform.parent = gamemanager.gameObject.transform;
        //SetPano.transform.localPosition = new Vector3(48066, 0, 0);
        //SetPano.SetActive(false);
    }
}
