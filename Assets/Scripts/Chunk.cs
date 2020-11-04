using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk 
{

    public bool smoothTerrain = true;

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    public GameObject chunkObject;
    
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    Mesh mesh;

    Vector3Int chunkPosition;

    float[,,] terrainMap;

    //int _configIndex = -1;

  /*  private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            terrainMap = new float[width + 1, hight + 1, width + 1];

            Destroy(mesh);

            PopulateTerrainMap();
            CreateMeshdata();
        }
    }*/

    public Chunk (Vector3Int _position, int _height )
    {
        chunkObject = new GameObject();
        chunkObject.name = string.Format("Chunk {0}, {1}", _position.x, _position.z);

        chunkPosition = _position;
        chunkObject.transform.position = chunkPosition;       

        meshFilter = chunkObject.AddComponent<MeshFilter>();
        meshRenderer = chunkObject.AddComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("Materials/TerrainMAT");
        meshCollider = chunkObject.AddComponent<MeshCollider>();
        

        terrainMap = new float[width +1, height+1, width+1];

        PopulateTerrainMap(_position, _height);
        CreateMeshdata();
        meshCollider.sharedMesh = mesh;

    }

    int width { get { return GameData.ChunkWidth; } }
    int height { get { return GameData.ChunkHeight; } }
    float terrainSurface { get { return GameData.terrainSurface; } }

    float SampleTerrain (Vector3Int point)
    {
        return terrainMap[point.x, point.y, point.z];
    }

    void CreateMeshdata()
    {
        ClearMeshData();

        for (int x = 0; x < width ; x++)
        {
            for (int y = 0; y < height ; y++)
            {
                for (int z = 0; z < width ; z++)
                {
                   
                    MarchCubes(new Vector3Int(x, y, z));
                }
            }
        }
        BuildMesh();
    }

    void PopulateTerrainMap(Vector3Int pos, int worldheight)
    {
        for (int x = 0; x < width + 1; x++)
        {
            for (int y = 0; y < height + 1; y++)
            {
                for (int z = 0; z < width + 1; z++)
                {
                    float thisHeight;
          
                        thisHeight = GameData.GetDensity(x + chunkPosition.x, y + chunkPosition.y, z + chunkPosition.z);                        
                        terrainMap[x, y, z] = thisHeight ;                    
                      
                }
            }
        }
    }

    int getCubeConfig(float[] cube)
    {
        int configerationIndex = 0;

        for (int i = 0; i < 8; i++)
        {
            if (cube[i] > terrainSurface)
            {
                configerationIndex |= 1 << i;
            }

        }
        return configerationIndex;
    }

    void MarchCubes(Vector3Int position)
    {
        float[] cube = new float[8];
        for (int i = 0; i < 8; i++)
        {
            cube[i] = SampleTerrain(position + GameData.CornerTable[i]);
        }

        int configIndex = getCubeConfig(cube);

        if (configIndex == 0 || configIndex == 255)
            return;

        int edgeIndex = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int p = 0; p < 3; p++)
            {
                int indice = GameData.TriangleTable[configIndex, edgeIndex];

                if (indice == -1)
                    return;

                Vector3 vert1 = position + GameData.CornerTable[GameData.EdgeIndexes[indice, 0]];
                Vector3 vert2 = position + GameData.CornerTable[GameData.EdgeIndexes[indice, 1]];

                Vector3 vertPosition;

                if (smoothTerrain)
                {
                    float vert1Sample = cube[GameData.EdgeIndexes[indice, 0]];
                    float vert2Sample = cube[GameData.EdgeIndexes[indice, 1]];

                    float difference = vert2Sample - vert1Sample;

                    if (difference == 0)
                        difference = terrainSurface;
                    else
                        difference = (terrainSurface - vert1Sample )/ difference;

                    vertPosition = vert1 + ((vert2 - vert1) * difference);

                }
                else
                {
                    vertPosition = (vert1 + vert2) / 2f;
                }

                vertices.Add(vertPosition);
                triangles.Add(vertices.Count - 1);
                edgeIndex++;

            }
        }

    }


    void ClearMeshData()
    {
        vertices.Clear();
        triangles.Clear();
    }

    void BuildMesh()
    {
        mesh = new Mesh();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;

    }

   
}
