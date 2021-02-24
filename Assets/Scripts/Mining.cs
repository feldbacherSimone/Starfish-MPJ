using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public int toolStrengh = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
           Collectable instance = collision.gameObject.GetComponent<Collectable>();
            instance.objectHealth -= toolStrengh;
            if (instance.objectHealth <= 0)
                instance.destroy();
        }


    }
}
