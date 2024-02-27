using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class VariableJoystickLotte : Joystick
{
    public BoraJoyStickLotte joystick;
    GameManager GM;
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;
    [SerializeField] private JoystickType joystickType = JoystickType.Fixed;

    private Vector2 fixedPosition = Vector2.zero;

    public void SetMode(JoystickType joystickType)
    {
        this.joystickType = joystickType;
        if (joystickType == JoystickType.Fixed)
        {
            background.anchoredPosition = fixedPosition;
            background.gameObject.SetActive(true);
        }
        else
            background.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();
        fixedPosition = background.anchoredPosition;
        SetMode(joystickType);
        joystick = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BoraJoyStickLotte>();
        GM = joystick.gameObject.GetComponent<GameManager>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(SceneManager.GetActiveScene().name.Contains("ClearMode"))
        {
            GM.clearMode.labeldetailstate = ClearMode.LabelDetailState.Closing;
        }

        for (int i=0; i<GM.Arrow.transform.childCount; i++)
        {
            if(i!=0)
            {
                GM.Arrow.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
        }

        if (joystick.GM.MiniMap_CameraGuide.activeSelf)
        {
            joystick.GM.MiniMap_CameraGuide.gameObject.SetActive(false);
        }
        for (int index = 1; index < joystick.GM.Arrow.transform.childCount; index++)
        {
            joystick.GM.Arrow.transform.GetChild(index).gameObject.SetActive(false);
        }
        joystick.enabled = true;
        if (joystickType != JoystickType.Fixed)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
        }
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        for (int i = 0; i < GM.Arrow.transform.childCount; i++)
        {
            if (i != 0)
            {
                GM.Arrow.transform.GetChild(i).GetComponent<Image>().enabled = true;
            }
        }

        for (int index = 1; index < joystick.GM.Arrow.transform.childCount; index++)
        {
            joystick.GM.Arrow.transform.GetChild(index).gameObject.SetActive(true);
        }
        joystick.GM.Arrow.transform.GetChild(0).transform.localPosition = Vector3.zero;
        joystick.enabled = false;
        if (joystickType != JoystickType.Fixed)
            background.gameObject.SetActive(false);

        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (joystickType == JoystickType.Dynamic && magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}

public enum JoystickType { Fixed, Floating, Dynamic }