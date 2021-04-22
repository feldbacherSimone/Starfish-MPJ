using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CraftingDisplay : MonoBehaviour
{
    [SerializeField]
    public Ingredient[] ingredients;

    public GameObject listTemplate;
    public Transform positionRefernce;

    [SerializeField]
    float offsetammount;

    private void Start()
    {
        CreateRecipy(); ;
    }

    private  void CreateRecipy()
    {

        float offset = 0; 
        foreach (Ingredient ingredient in ingredients)
        {
            GameObject newLine = GameObject.Instantiate(listTemplate, positionRefernce.transform);
            newLine.transform.position = positionRefernce.position + new Vector3( 0, offset, 0);
            newLine.GetComponent<SpriteRenderer>().sprite = ingredient.item.sprite;
            newLine.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = ingredient.ammount.ToString();
            offset += offsetammount; 
        }
    }
}
