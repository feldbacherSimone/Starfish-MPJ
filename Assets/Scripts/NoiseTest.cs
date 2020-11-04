using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTest : MonoBehaviour
{

public  float terrainSurface = 0.4f; // also acts as density threshhold
public  int ChunkWidth = 16;
public  int ChunkHeight = 16;

    public static NoiseTest instance;

public  float noiseX = 16f;
public  float noiseY = 3f;
public  float noiseScale = 0.05f;


public  float gameBaseHight = 60f;
public  float terrainHightRange = 10f;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        GameData.terrainSurface = terrainSurface;
        GameData.ChunkWidth = ChunkWidth;
        GameData.ChunkHeight = ChunkHeight;

        GameData.noiseX = noiseX;
        GameData.noiseY = noiseY;
        GameData.noiseScale = noiseScale;

        GameData.gameBaseHight = gameBaseHight;
        GameData.terrainHightRange = terrainHightRange;
    }
}
