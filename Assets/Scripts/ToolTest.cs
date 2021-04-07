using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTest : MonoBehaviour
{
    public void OnTriggerEnter(Collider x)
    {
        Debug.Log(x.gameObject.name);
    }
}
