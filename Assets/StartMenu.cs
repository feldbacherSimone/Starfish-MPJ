using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{


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
}
