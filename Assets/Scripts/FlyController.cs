using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FlyController : MonoBehaviour
{
    float speed;
    float moveAmount; 
    public Transform trans;
    public Rigidbody rb;
   // public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Vector2 joystickInput;
 
    public KeyCode schub;
    

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.transform; 
        rb = GetComponent<Rigidbody>();
    }

   
    void movePlayer()
    {
        moveAmount = speed * joystickInput.GetAxis(SteamVR_Input_Sources.LeftHand).y;
        
        rb.AddForce(moveForce);
    }
}
