using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class See360Pos : MonoBehaviour
{
    public ClearMode clearmode;
    public GameObject PosObj;

    float posx;
    float posy;
    float sizex;

    private void Start()
    {
        clearmode = GetComponent<ClearMode>();
    }

    // Update is called once per frame
    void Update()
    {
        posx = (clearmode.Main.transform.position.x - 45563) / 97376 * 360;
        PosObj.transform.rotation = Quaternion.Euler(0, 0, -posx);

        posy = (clearmode.Main.transform.position.y + 6120) / 17700 * 45 + 10;
        PosObj.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, posy);

        sizex = 1 - (clearmode.Main.transform.parent.transform.position.z - 1851) / 5220 * 1.5f;
        PosObj.transform.GetChild(0).gameObject.transform.localScale = new Vector3(sizex, sizex, sizex);
    }
}
