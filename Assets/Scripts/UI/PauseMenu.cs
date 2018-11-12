using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenuUI;

    private static bool paused = false;

    

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void MainMenu()
    {

        
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
		pauseMenuUI.enabled = false;
        Time.timeScale = 1;
		paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.enabled = true;
        Time.timeScale = 0;
		paused = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

}
