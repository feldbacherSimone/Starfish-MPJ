using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite sprite;
    public int amountCollectd = 2; 

    public Item(int id, string name )
    {
        this.id = id;
        this.name = name;
        this.sprite = Resources.Load<Sprite>("Sprites/" + name);
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.name = item.name;
        this.sprite = Resources.Load<Sprite>("Sprites/" + item.name);
    }

}
[System.Serializable]
public class Ingredient
{
   public string name;
   public int ammount;
}
