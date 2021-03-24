using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//this should only contain information/code realted to the world generation 
//thigs like plant distribution and chunk generation need to be handled by different classes 
public class WorldGenerator : MonoBehaviour
{
    public Material matRef;
    public GameObject plane;
    public int chunkSize = 16;
    Dictionary<Vector3Int, Chunk> chunks = new Dictionary<Vector3Int, Chunk>();

    int WorldsizeInChunks { get { return GameData.instance.WorldsizeInChunks; } }
    int WorldHight { get { return GameData.instance.WorldHeight; } }

    private void Start()
    {
        
        Generate();
        HideTiles.instance.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            chunks.Clear();
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject); //Is this gonna get me arrested?
            }

            Generate();
           
        }
    }

    void InstantiateTestPlane(Vector3 chunkPos)
    {
        GameObject newPlane = GameObject.Instantiate(plane);
        newPlane.transform.SetParent(transform);

        newPlane.transform.GetChild(0).gameObject.transform.Rotate(new Vector3(0, 180, 0));
        newPlane.transform.position = chunkPos + new Vector3(0, -5, 0);

        MapDisplay mapDisplay = newPlane.GetComponent<MapDisplay>();
        mapDisplay.textureRenderer = newPlane.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        mapDisplay.textureRenderer.material = new Material(matRef);
        //I should make the whole offset calculation into it's own function as well because I always forget to change the values
        mapDisplay.DrawNoiseMap(GameData.instance.CreateTerrainNoise(new Vector2(chunkPos.x * GameData.instance.offsetScale / GameData.instance.noiseScale * GameData.instance.offsetScale, chunkPos.z / GameData.instance.noiseScale)));
        
    }

    void Generate()
    {
        for (int x = 0; x < WorldsizeInChunks; x++)
        {
            for (int y =0; y < WorldHight; y++)
            {
                for (int z = 0; z < WorldsizeInChunks; z++)
                {
                    Vector3Int chunkPos = new Vector3Int(x * GameData.instance.ChunkWidth, y * GameData.instance.ChunkHeight, z * GameData.instance.ChunkWidth);
                    chunks.Add(chunkPos, new Chunk(chunkPos, WorldHight * chunkSize, WorldsizeInChunks * chunkSize));
                    chunks[chunkPos].chunkObject.transform.SetParent(transform);
                    chunks[chunkPos].chunkObject.tag = "tile";
                    chunks[chunkPos].SpawnObjects( GameData.instance.numberOfCoralls, GameData.instance.corall, chunkPos );

                    //InstantiateTestPlane(chunkPos);
                 
                    print(chunkPos + "chunk position");
                }
            }
        }
        Debug.Log(string.Format("{0} x {0} World Generated", (GameData.instance.ChunkWidth * WorldsizeInChunks)));
    }
}
