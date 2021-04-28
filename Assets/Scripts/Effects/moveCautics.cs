using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class moveCautics : MonoBehaviour
{
    private DecalProjector projector;
    private GameObject player;
    [SerializeField]
    bool debug;
    [SerializeField]
    float scale;

    private void Start()
    { 
        player = GameObject.FindGameObjectWithTag("MainPlayer");
        projector = gameObject.GetComponent<DecalProjector>();
        if (debug)
            player = player.transform.GetChild(1).GetChild(0).gameObject;
    }

    private void Update()
    {
        MoveDecals();
    }
    private void MoveDecals()
    {
        scale = projector.uvScale.x;
        gameObject.transform.position = new Vector3(player.transform.position.x, 50, player.transform.position.z);
        Vector2 offset;
        float offsetX = player.transform.position.x / projector.size.x * scale;
        float offsetY = player.transform.position.z / projector.size.y * scale;
        offset = new Vector2(offsetX, offsetY);
        projector.uvBias = offset;
        
    }
}
