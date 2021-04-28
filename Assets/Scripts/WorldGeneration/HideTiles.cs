using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideTiles : MonoBehaviour
{
    public static HideTiles instance;

    [SerializeField]
    private string tileTag;

    [SerializeField]
    private Vector3 tileSize;

    [SerializeField]
    private int maxDistance;

    [SerializeField]
    private GameObject[] tiles;

    public bool rightScene = false;
    private Scene scene;
    // Use this for initialization

    private void Start()
    {
        Debug.Log(gameObject.name);
        instance = this;
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 2)
            rightScene = true;
        else
            rightScene = false;
    }
    public void Init()
    {
        this.tiles = GameObject.FindGameObjectsWithTag(tileTag);
        DeactivateDistantTiles();
    }

    void DeactivateDistantTiles()
    {
        if (rightScene)
        {

       
        Vector3 playerPosition = this.gameObject.transform.position;

        foreach (GameObject tile in tiles)
        {
            Vector3 tilePosition = tile.gameObject.transform.position + (tileSize / 2f);

            float xDistance = Mathf.Abs(tilePosition.x - playerPosition.x);
            float zDistance = Mathf.Abs(tilePosition.z - playerPosition.z);

            if (xDistance + zDistance > maxDistance)
            {
                tile.SetActive(false);
            }
            else
            {
                tile.SetActive(true);
            }
            }
        }
         
    }

   

    
}