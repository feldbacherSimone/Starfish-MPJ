using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public int toolStrengh = 10;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] miningSounds;
    [SerializeField]
    AudioClip[] breakSounds; 


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            playSound((miningSounds[Random.Range(0, miningSounds.Length - 1)]));
            Collectable instance = collision.gameObject.GetComponent<Collectable>();
            instance.objectHealth -= toolStrengh;
            if (instance.objectHealth <= 0)
            {
                playSound((breakSounds[Random.Range(0, breakSounds.Length - 1)]));
                instance.destroy();
            }
              
        }


    }
    void playSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
