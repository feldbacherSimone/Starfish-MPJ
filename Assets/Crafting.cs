using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
   
    public GameObject result;
    public Transform position;

    public void Craft()
    {
        
            GameObject.Instantiate(result, position.position, Quaternion.Euler(0,26,-90));
            
        
           
    }
}
