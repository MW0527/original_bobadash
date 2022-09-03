using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1); //main game scene

    }
    public void General(int sceneID) //can load any scene by specifying its index
    {
        SceneManager.LoadScene(sceneID); 
    }
    public void Home()
    {
        SceneManager.LoadScene(0); //main menu scene
    }

    public void Controls()
    {
        SceneManager.LoadScene(3); //game controls scene
    }

    public void Information()
    {
        SceneManager.LoadScene(4); //game object descriptions scene
    }
}
