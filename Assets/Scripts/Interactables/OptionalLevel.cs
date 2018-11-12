using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OptionalLevel : MonoBehaviour {

    public int scene;
    public int alternate;

	public Canvas warpArea;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.W))
        {
			AlternateLevel();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			warpArea.enabled = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			warpArea.enabled = false;
		}
	}

	void AlternateLevel()
    {
        SceneManager.LoadScene(scene + alternate);
    }
}
