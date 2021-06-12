using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DoorGrabable : Throwable
{
    public Transform handler;
    public override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);

        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;

        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;

        Rigidbody rbHandler = handler.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;
        transform.SetParent(handler);
    }
   
    
}
