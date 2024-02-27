using UnityEngine;
using UnityEngine.UI;

public class DeviceInformationText : MonoBehaviour
{
    private Text text;

    private float t = 1f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 1f)
        {
            text.text = 
                SystemInfo.operatingSystem + " / " +
                SystemInfo.graphicsDeviceName + " / " +
                Camera.main.pixelWidth + "x" + Camera.main.pixelHeight;
            t = 0f;
        }
    }
}
