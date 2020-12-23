using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlyController : MonoBehaviour
{
    public float speed = 1;
    Vector3 moveAmount; 
    public Transform trans;
    public SteamVR_Action_Vector2 joystickInput;
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
            TestMovement();
        if (joystickInput.active)
            movePlayer();
    }

    void movePlayer()
    {
        moveAmount = speed * new Vector3(joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).x, 0,  joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).y);
        Vector3 moveAmountlocal = trans.TransformDirection(moveAmount);
        trans.localPosition += moveAmountlocal;
    }

    //For Testing Without a VR headset 
    void TestMovement()
    {
        moveAmount = speed * new Vector3(0, 0, 1);
        Vector3 moveAmountlocal = trans.TransformDirection(moveAmount);
        trans.localPosition += moveAmountlocal; 
        

    }
}
