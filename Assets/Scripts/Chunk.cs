using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk 
{

    

    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    public GameObject chunkObject;
    public WorldGenerator worldGen;
    
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    Mesh mesh;

    Vector3Int chunkPosition;

    float[,,] terrainMap;
    float[,,] noise3d;
    //int _configIndex = -1;


    
  


    public Chunk (Vector3Int _position, int _height, int worldSize )
    {


        chunkObject = new GameObject();
        chunkObject.name = string.Format("Chunk {0}, {1}", _position.x, _position.z);

        chunkPosition = _position;
        chunkObject.transform.position = chunkPosition;       

        meshFilter = chunkObject.AddComponent<MeshFilter>();
        meshRenderer = chunkObject.AddComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("Materials/TerrainMAT");
        meshCollider = chunkObject.AddComponent<MeshCollider>();
        
        //Create float array to store hight onformation in 
        terrainMap = new float[width +1, height+1, width+1];

        GameData.instance.CreateTerrainNoise(new Vector2(chunkPosition.x  , chunkPosition.z* GameData.instance.offsetScale));

        Debug.Log(chunkPosition.x * GameData.instance.offsetScale);
        //float[,,] noise3d = Noise3d(_height);
        PopulateTerrainMap(_position, worldSize, noise3d);
        CreateMeshdata();
        meshCollider.sharedMesh = mesh;
        

    }

    int width { get { return GameData.instance.ChunkWidth; } }
    int height { get { return GameData.instance.ChunkHeight; } }
    float terrainSurface { get { return GameData.instance.terrainSurface; } }

    

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

    void PopulateTerrainMap(Vector3Int pos, int worldheight, float[,,] noise3d)
    {
        // The data points for terrain are stored at the corners of our "cubes", so the terrainMap needs to be 1 larger
        // than the width/height of our mesh.
        for (int x = 0; x < width +1  ; x++)
        {       
            for (int z = 0; z < width +1 ; z++)
                {
                for (int y = 0; y < height +1 ; y++)
                {
                    //get height value from our layerd noise function 
                    float thisHeight = GameData.instance.getHeight(x , z );
                    
                    terrainMap[x, y, z] = (float)y - thisHeight;
                 
                    
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

                if (GameData.instance.smoothTerrain)
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
