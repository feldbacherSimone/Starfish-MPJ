using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            chunks.Clear();
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Generate();
        }
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

                    GameObject newPlane = GameObject.Instantiate(plane);
                    newPlane.transform.SetParent(transform);
                    newPlane.transform.position = chunkPos + new Vector3(0, -5, 0);
                    MapDisplay mapDisplay = newPlane.GetComponent<MapDisplay>();
                    mapDisplay.textureRenderer = newPlane.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
                    mapDisplay.textureRenderer.material = new Material(matRef);
                    mapDisplay.DrawNoiseMap(GameData.instance.CreateTerrainNoise(new Vector2(chunkPos.x , chunkPos.z)));
                    print(chunkPos + "chunk position");

                    

                }
            }
        }
        Debug.Log(string.Format("{0} x {0} World Generated", (GameData.instance.ChunkWidth * WorldsizeInChunks)));
    }
}
