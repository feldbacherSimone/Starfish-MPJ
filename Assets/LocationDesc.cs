using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationDesc : MonoBehaviour
{
    GameObject player;
    public float distance;
    public GameObject[] arrows;
    string text; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = gameObject.GetComponent<TextMeshProUGUI>().text;
   
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < distance)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = null;
            StartCoroutine(ShowArrows());
        }

        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = text;
            foreach (GameObject arrow in arrows)
            {
                arrow.SetActive(false); 
            }
        }
            print("distance = " + Vector3.Distance(player.transform.position, gameObject.transform.position));

    }

    IEnumerator ShowArrows()
    {
        int i = 0; 
        while (i < arrows.Length)
        {
            arrows[i].SetActive(true);
            i++;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
    }
}
