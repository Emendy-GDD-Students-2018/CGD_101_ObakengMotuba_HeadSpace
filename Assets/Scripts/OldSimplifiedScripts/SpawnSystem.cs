using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    public Transform[] spawnpoint;
    public Transform target;
    public GameObject spawnedObject;
    void Start()
    {
        InvokeRepeating("System", 3.0f, 3.0f);
        
    }

   

    // Update is called once per frame
    void System()
    {
        int spawnPointIndex = Random.Range(0, spawnpoint.Length);

        Instantiate(spawnedObject, spawnpoint[spawnPointIndex].position, spawnpoint[spawnPointIndex].rotation);
        
    }
    
 }


