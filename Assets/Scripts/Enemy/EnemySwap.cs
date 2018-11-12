using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySwap : MonoBehaviour
{
    public EnemyAttackRotation shifted;
    public EnemyAttackRotation reverted;
   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="PowerUp")
        {
            StartCoroutine(EnemyUp(other));
            
            
        }
    }
    IEnumerator EnemyUp(Collider enemy)
    {
        enemy.GetComponent<EnemyState>().LoadEnemyAttackRotation(shifted);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
        enemy.GetComponent<EnemyState>().LoadEnemyAttackRotation(reverted);

    }


}