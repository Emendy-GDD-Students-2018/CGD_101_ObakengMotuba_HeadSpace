using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateShift : MonoBehaviour {




    public void Awake()
    {

	}
    public void SwapEnemy(SpaceShift enemy)
	{
		if (gameObject == null)
		{
			print("Zero Enemies left");
		}

		else
		{
			GetComponent<EnemyState>().LoadEnemyAttackRotation(enemy.enemy);
            GetComponent<EnemyState>().LoadEnemyAttackRotation(enemy.enemy2);
        }
		
	}


}
