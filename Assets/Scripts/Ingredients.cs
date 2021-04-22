using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite sprite; 

    public Item(int id, string name, Sprite sprite)
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
   public  Item item;
   public int ammount;
}
