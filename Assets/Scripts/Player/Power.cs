using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Power : MonoBehaviour
{
    public SpaceShift shifted;
    public SpaceShift reverted;

   
	public float cooldown;

	
   


void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            StartCoroutine(PowerUp(other));
        }

        
    }

    
    IEnumerator PowerUp(Collider player)
    {

        
        player.GetComponent<PlayerMovement2>().LoadSpaceShift(shifted);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(cooldown);
        Destroy(gameObject);
        player.GetComponent<PlayerMovement2>().LoadSpaceShifted(reverted);
        
    }

   
}