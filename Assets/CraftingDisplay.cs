using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingDisplay : MonoBehaviour
{
    [SerializeField]
    public Ingredient[] ingredients;

    public GameObject listTemplate;

      private  void CreateRecipy()
    {
        foreach (Ingredient ingredient in ingredients)
        {

        }
    }
}
