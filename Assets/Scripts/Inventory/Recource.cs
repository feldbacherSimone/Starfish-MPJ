using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recource : MonoBehaviour
{
    public string ItemName;

    public void ItemInit(string name, float forceAmmount )
    {
      
        ItemName = name;
        foreach (Item item in ItemDatabase.instance.items)
        {
            if (ItemName == item.name)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * forceAmmount);

            }
          
        }
    }
   
}
