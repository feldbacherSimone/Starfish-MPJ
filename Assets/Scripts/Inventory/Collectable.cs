using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int objectHealth;
    public string itemName;
    public GameObject shardTemplate;
    public int itemCount = 3;

    [SerializeField] public static float itemForce = 0.1f;
    public virtual void destroy(bool destroyItem)
        
    {
        //instantiate shards and add force to them so they fly away 
        //shards could be saved in a prefab 

        for (int i = 0; i < itemCount; i++)
        {
            GameObject shard = GameObject.Instantiate(shardTemplate);
            shard.transform.position = gameObject.transform.position; 
            shard.GetComponent<Recource>().ItemInit(itemName, itemForce);
        }
        if (destroyItem)
        GameObject.Destroy(gameObject);
    }
}
