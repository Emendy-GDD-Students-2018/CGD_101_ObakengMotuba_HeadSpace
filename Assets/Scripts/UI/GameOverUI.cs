using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

   


    public void NewRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuGame()
    {
        SceneManager.LoadScene(0);
    }


}
