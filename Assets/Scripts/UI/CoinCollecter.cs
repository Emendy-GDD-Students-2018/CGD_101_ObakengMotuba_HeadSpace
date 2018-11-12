using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollecter : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            CoinCount.Instance.PickUP();


        }


    }
}
