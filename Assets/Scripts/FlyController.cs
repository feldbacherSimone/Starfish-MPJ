using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlyController : MonoBehaviour
{
    public float swimmspeed = 0.05f;
    public float risespeed = 1;
    public Vector3 moveAmount; 
    public Transform trans;
    public SteamVR_Action_Vector2 joystickInput;
    public SteamVR_Action_Single floatInput;
    
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
            TestMovement();
        if (joystickInput.active)
            movePlayer();
        if (floatInput.active)
            FloatUp();
    }

    void movePlayer()
    {
        moveAmount = swimmspeed * new Vector3(joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).x, 0,  joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).y);
        Vector3 moveAmountlocal = trans.TransformDirection(moveAmount);
        // trans.localPosition += moveAmountlocal;
        gameObject.transform.position += moveAmountlocal;
    }

    void FloatUp()
    {
        float floatamount = floatInput.GetAxis(SteamVR_Input_Sources.LeftHand) * risespeed;
        gameObject.transform.position += new Vector3(0, floatamount, 0);
        
    }

    //For Testing Without a VR headset 
    void TestMovement()
    {
        moveAmount = swimmspeed * new Vector3(0, 0, 1);
        Vector3 moveAmountlocal = trans.TransformDirection(moveAmount);
        trans.localPosition += moveAmountlocal; 
        

    }
}
