using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    //public static ItemDatabase instance;
    static bool instanceExists = false;



    private static ItemDatabase _instance;

    public static ItemDatabase instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        if (instanceExists)
        {
            Destroy(gameObject);
        }
        instanceExists = true;
        BuildItemList();
        GameObject.DontDestroyOnLoad(gameObject);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            showItemAmmount(); 
        
    }
    void BuildItemList()
    {
        items = new List<Item>()
        {
            new Item(0, "Oil"),
            new Item(1, "Coral"),
            new Item(2, "Wood"),
            new Item(3, "Seagrass"),
            new Item(4, "Shell"),
            new Item(5, "Zink"),
            new Item(6, "Clay"), 
            new Item( 7, "Sulfur")
        };
    }
    public Item  GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }
    public Item GetItem(string name)
    {
        return items.Find(item => item.name == name);
    }

    public void showItemAmmount()
    {
        foreach (Item item in items)
        {
            print(item.name + " : " + item.amountCollectd);
        }
    }
}
