using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpawner : MonoBehaviour {

	public GameObject [] powerupPrefab;
	// Use this for initialization
	void Start () {

		Instantiate(powerupPrefab[Random.Range(0, 2)],transform.position,transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
