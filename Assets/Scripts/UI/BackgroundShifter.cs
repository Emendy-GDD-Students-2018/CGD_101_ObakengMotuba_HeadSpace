using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShifter : MonoBehaviour
{
	public static BackgroundShifter Instance;

	public void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	public void SwapBackground(SpaceShift charecter)
	{
		GetComponent<MeshRenderer>().material = charecter.background;
	}
}

	