using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject playerTemplate;
   

    //private void OnLevelWasLoaded(int level)
   // {

      //  spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        //player = GameObject.FindGameObjectWithTag("MainPlayer");
        //player.transform.position = spawnPoint.position;
   // }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        player = GameObject.FindGameObjectWithTag("MainPlayer");
        if (player == null)
            player = GameObject.Instantiate(playerTemplate, spawnPoint);
        player.transform.position = spawnPoint.position;
    }
}
