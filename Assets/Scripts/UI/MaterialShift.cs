using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShift : MonoBehaviour
{

	public static MaterialShift Instance;

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
	public void SwapMaterial(SpaceShift materialshift)
	{
		GetComponent<Image>().color = materialshift.colo;
	}
}
