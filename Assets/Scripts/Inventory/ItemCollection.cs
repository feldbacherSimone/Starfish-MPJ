using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public AudioClip pickUpSoubd;
    public CraftingDisplay display; 

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            //Destroy(collision.gameObject);

            Recource recource = collision.gameObject.GetComponent<Recource>();

            AddItemToInventory(recource);

            collision.gameObject.SetActive(false);
        }

        print("collision");
    }


    void AddItemToInventory(Recource recource)
    {

        foreach (Item item in ItemDatabase.instance.items)
        {
            if (recource.ItemName == item.name)
            {
                item.amountCollectd++;
                print(item.name + "was collected");
                ItemDatabase.instance.showItemAmmount();
                GetComponent<AudioSource>().clip = pickUpSoubd;
                GetComponent<AudioSource>().Play();
                display.CreateRecipy();
            }
      
        }
    }
}
