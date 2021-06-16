using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CraftingDisplay : MonoBehaviour
{
    public List<GameObject> Lines = new List<GameObject>();
    [SerializeField]
    public Ingredient[] ingredients;
    public Crafting crafting;
    public int taskID;

    public GameObject listTemplate;
    public Transform positionRefernce;

    public bool useLocalSpace = false; 
    [SerializeField]
    float offsetammount;

    public bool isFullfilled;
    public bool isTerraian = false;

    int ingredientsgathered = 0;

    private void Update()
    {
        CreateRecipy(); 
    }

  public void CreateRecipy()
    {
        
        float offset = 0; 

        if(Lines.Count > 0)
        {
            foreach (GameObject line in Lines)
            {
                Destroy(line);
            }
        }
        foreach (Ingredient ingredient in ingredients)
        {
            Item item = ItemDatabase.instance.GetItem(ingredient.name);

            GameObject newLine = GameObject.Instantiate(listTemplate, gameObject.transform);
            Lines.Add(newLine);

            if (isTerraian)
            {
                positionRefernce = GameObject.FindGameObjectWithTag("Reference").transform;
            }


            if (useLocalSpace)
            newLine.transform.localPosition = positionRefernce.position + new Vector3( 0, offset, 0);

            else
                newLine.transform.position = positionRefernce.position + new Vector3(0, offset, 0);

            newLine.GetComponent<SpriteRenderer>().sprite = item.sprite;

            newLine.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = ingredient.ammount.ToString();
            newLine.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text = item.amountCollectd.ToString();
            if (item.amountCollectd >= ingredient.ammount)
                ingredientsgathered++;

            
            offset += offsetammount; 
        }
        if (ingredientsgathered == ingredients.Length)
            isFullfilled = true;
     
    }
  public void TryCrafting()
    {
        if (isFullfilled == true)
        {
            print("crafting Sucsessfull");
            crafting.Craft();
            foreach (Ingredient ingredient in ingredients)
            {
                Item item = ItemDatabase.instance.GetItem(ingredient.name);
                item.amountCollectd -= ingredient.ammount;
            }
            GameProgress.instance.tasks[taskID].status = true; 
        }
        else
            print("Crafting Failed"); 
    }

}
