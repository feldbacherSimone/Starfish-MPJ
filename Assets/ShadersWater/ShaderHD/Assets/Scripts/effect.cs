using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine;


public class effect : MonoBehaviour
{

    public float fps = 30.0f;         //footage fps
    public Texture2D[] frames;      //caustics images

    private int frameIndex;
    [SerializeField]
    private DecalProjector projector;    //Projector GameObject

    // Start is called before the first frame update
    void Start()
    {
        projector = GetComponent<DecalProjector>();
        NextFrame();
        InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
    }

    void NextFrame()
    {
        projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }

}
