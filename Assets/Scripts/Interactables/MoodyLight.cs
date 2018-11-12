using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodyLight : MonoBehaviour {

    public Light dimLight;
    public float time;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dimLight.enabled = false;
          
        }

        if(!dimLight.enabled)
        {
            StartCoroutine(Lighting());
        }

    }

    IEnumerator Lighting()
    {
        time = GetComponent<Power>().cooldown;
        yield return new WaitForSeconds(time);

        dimLight.enabled = true;
    }

   
}
