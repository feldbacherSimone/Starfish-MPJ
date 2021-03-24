using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int objectHealth;
    public int inventoryID; 
    
    public void destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
