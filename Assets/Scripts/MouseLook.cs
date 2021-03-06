﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    Vector3 mouseLook;
    Vector3 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    
    GameObject character;

    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        character = this.transform.parent.gameObject;
        rb = character.GetComponent<Rigidbody>();
    }
	
    // Update is called once per frame
    void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);      
       
        
        //Invert mouslook x and rotation when on ceiling
        if (CitySwap.OnWhite)
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            //character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            character.transform.localEulerAngles = new Vector3(character.transform.localEulerAngles.x, mouseLook.x,
                0);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            //character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            character.transform.localEulerAngles = new Vector3(character.transform.localEulerAngles.x, -mouseLook.x,
                180);
          

        }
    }
}