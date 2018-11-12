using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageShifter : MonoBehaviour {

	public static ImageShifter Instance;

	public void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	public void SwapImage(SpaceShift imagecooldown)
	{
		GetComponent<Image>().sprite = imagecooldown.uiImage;
	}
}
