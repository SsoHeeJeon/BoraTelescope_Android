using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ShipCtroller : MonoBehaviour {

    public Animator BattleShipAnimn;
    public Animator MasterAnimn;
    public Animator LeftWindowAnim;
    public Animator RightWindowAnim;
    public Animator BackWindowsAnim;
    public Animator RudderAnim;

    public float rotationSpeed  = 5f;
    public float moveSpeed = 5f;

    public bool MobileON = false;



    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = 0;
        float inputV = 0;

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        this.BattleShipAnimn.SetFloat("hInput", inputH);
        this.BattleShipAnimn.SetFloat("vInput", inputV);


        float rotY = inputH * Time.deltaTime * this.rotationSpeed;
        float moveZ = inputV * Time.deltaTime * this.moveSpeed;

        this.transform.Rotate(0, rotY, 0, Space.World);
        this.transform.Translate(0, 0, moveZ);
    }
}
