using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelScale : MonoBehaviour
{
    [SerializeField]
    ClearMode clearMode;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float value = 0;
        value = (clearMode.Main.transform.parent.transform.localPosition.z + 3369) / 52.2f;
        value = 100 - value;
        transform.localScale = new Vector3(1 + (0.035f * value), 1 + (0.035f * value), 1 + (0.035f * value));
    }
}
