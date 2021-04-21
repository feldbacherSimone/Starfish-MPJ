using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    int id;
    string name;
    Sprite sprite; 

    public Item(int id, string name, Sprite sprite)
    {
        this.id = id;
        this.name = name;
        this.sprite = sprite;
    }

}
[System.Serializable]
public class Ingredient
{
   public  Item item;
   public int ammount;
}
