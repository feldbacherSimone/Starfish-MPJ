using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int objectHealth;
    public int inventoryID; 
    
    public void destroy()
    {
        //instantiate shards and add force to them so they fly away 
        //shards could be saved in a prefab 

        GameObject.Destroy(gameObject);
    }
}
