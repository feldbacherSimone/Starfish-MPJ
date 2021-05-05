using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{



    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }

        print("collision");
    }
}
