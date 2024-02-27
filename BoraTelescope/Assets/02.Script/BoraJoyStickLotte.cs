using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoraJoyStickLotte : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50;
    public VariableJoystickLotte variableJoystick;
    public GameManager GM;
    // Update is called once per frame
    private void Start()
    {
        GM = GetComponent<GameManager>();
    }

    Vector3 direction;
    bool Vertical;
    bool Horizontal;

    public bool alreadyPinchZoom = false;



    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

            if (variableJoystick.Horizontal >= 0.2f)
            {
                if (GM.clearMode.Main.transform.localPosition.x <= GetComponent<GameManager>().clearMode.max_x)
                {
                    GM.clearMode.Main.transform.localPosition = new Vector3(GM.clearMode.Main.transform.localPosition.x + (direction.x * speed),
                    GM.clearMode.Main.transform.localPosition.y, GM.clearMode.Main.transform.localPosition.z);
                }
            }
            else if (variableJoystick.Horizontal <= -0.2f)
            {
                if (GM.clearMode.Main.transform.localPosition.x >= GetComponent<GameManager>().clearMode.min_x)
                {
                    GM.clearMode.Main.transform.localPosition = new Vector3(GM.clearMode.Main.transform.localPosition.x + (direction.x * speed),
                    GM.clearMode.Main.transform.localPosition.y, GM.clearMode.Main.transform.localPosition.z);
                }
            }


            if (variableJoystick.Vertical >= 0.2f)
            {
                if (GM.clearMode.Main.transform.localPosition.y <= GetComponent<GameManager>().clearMode.max_y)
                {
                    GM.clearMode.Main.transform.localPosition = new Vector3(GM.clearMode.Main.transform.localPosition.x,
                    GM.clearMode.Main.transform.localPosition.y + (direction.z * speed), GM.clearMode.Main.transform.localPosition.z);
                }
            }
            else if (variableJoystick.Vertical <= -0.2f)
            {
                if (GM.clearMode.Main.transform.localPosition.y >= GetComponent<GameManager>().clearMode.min_y)
                {
                    GM.clearMode.Main.transform.localPosition = new Vector3(GM.clearMode.Main.transform.localPosition.x,
                    GM.clearMode.Main.transform.localPosition.y + (direction.z * speed), GM.clearMode.Main.transform.localPosition.z);
                }

            }
        }
    }
}
