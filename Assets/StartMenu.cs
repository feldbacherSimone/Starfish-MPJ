using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class StartMenu : MonoBehaviour
{
    float currentVolume;
    float minVol = -20;
    float maxVol = 20;
    public AudioMixerGroup mixerGroup;
    public void StartGame(int sceneIndex)
    {
       
        SceneManager.LoadScene(sceneIndex);
        print("Loading StartScene"); 
    }
    public void SettingsMenu()
    {
        print("Loading Settings Menu"); 
    }
    public void QuitGame()
    {
        Application.Quit();
        print("QuitGame");
    }

    public void SoundVolume( int addAmmount)
    {
        mixerGroup.audioMixer.GetFloat("masterVol", out currentVolume);

        mixerGroup.audioMixer.SetFloat("masterVol", currentVolume + addAmmount);
    }
}
