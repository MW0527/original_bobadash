using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true); //pause menu appears
        Time.timeScale = 0f; //game is stopped
    }
    public void Restart(int sceneID) //sceneID is the index of the main game scene
    {
        Time.timeScale = 1f; //game is running
        SceneManager.LoadScene(sceneID); //load main game scene

    }
    public void Resume()
    {
        pauseMenu.SetActive(false); //pause menu disappears
        Time.timeScale = 1f; //game is resumed
    }

    public  void Home(int sceneID) //sceneID is the index of the main menu
    {
        Time.timeScale = 1f; //game is resumed
        SceneManager.LoadScene(sceneID); //load main menu
    }

}
