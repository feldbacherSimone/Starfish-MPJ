using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour


{
    AudioSource audioSource;
    [SerializeField]
    AudioClip teleportSound;
    [SerializeField]
    private int[] sceneIdex;

    private void Start()
    {
        audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        teleportSound = Resources.Load<AudioClip>("Sounds/TeleportSound");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.tag == "MainPlayer")
        {
            audioSource.clip = teleportSound;
            audioSource.Play();
            if (sceneIdex.Length != 0)
            SceneManager.LoadScene(sceneIdex[0], LoadSceneMode.Single);
           if (sceneIdex.Length > 1)
            {
                for (int i = 1; i < sceneIdex.Length ; i++)
                {
                    SceneManager.LoadScene(sceneIdex[i], LoadSceneMode.Additive);
                }
            }
            Debug.Log("Scene " + sceneIdex + " has been loaded");
        }
        else
            print("wrong tag");
        
    }

  
        
        
        
    
}
