using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;



public class MenuUI : MonoBehaviour
{ 
    public AudioClip back;
public AudioClip click;

public AudioSource uiButton;

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame ()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void EnterClick()
    {
        uiButton.PlayOneShot(click);
    }

    public void ExitClick()
    {
        uiButton.PlayOneShot(back);
    }
}
