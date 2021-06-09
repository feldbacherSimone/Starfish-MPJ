using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
   public CraftingDisplay recipy;
    public GameObject result;
    public Transform position;

    private void Update()
    {
        if (recipy.isFullfilled)
        {
            GameObject.Instantiate(result, position.position, Quaternion.Euler(0,26,-90));
            Destroy(GetComponent<Crafting>());
        }
           
    }
}
