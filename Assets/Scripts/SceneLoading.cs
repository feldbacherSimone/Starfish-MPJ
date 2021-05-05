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
    private int sceneIdex;

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
            SceneManager.LoadScene(sceneIdex);
            Debug.Log("Scene " + sceneIdex + " has been loaded");
        }
        else
            print("wrong tag");
        
    }

  
        
        
        
    
}
