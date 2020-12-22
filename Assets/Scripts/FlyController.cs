using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlyController : MonoBehaviour
{
    public float speed = 1;
    Vector3 moveAmount; 
    public Transform trans;
    public Rigidbody rb;
   // public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Vector2 joystickInput;
 
    public KeyCode schub;
    

    // Start is called before the first frame update
    void Start()
    {
     
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
            TestMovement();
    }


    void movePlayer()
    {
        moveAmount = speed * new Vector3(joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).x, 0,  joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).y);
        trans.position = trans.TransformDirection(moveAmount);
        
    }

    void TestMovement()
    {
        moveAmount = speed * new Vector3(0, 0, 1);
        Vector3 moveAmountlocal = trans.TransformDirection(moveAmount);
        trans.localPosition += moveAmountlocal; 
        

    }
}
