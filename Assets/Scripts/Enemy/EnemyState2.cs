using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState2 : MonoBehaviour
{

	public EnemyAttackRotation enemy2;
	private float speed;

   


	public float timeout;
	public Transform enemySpawn;
	public Transform enemyRotation;
	public Transform target;
	public GameObject enemyHead;
	public GameObject spherePrefab;
    public Transform enemyTransform;

    public Transform weaponSpawn;
	public Transform weaponRotation;
	public GameObject axePrefab;
	private float bulletSpeed;
	private float axeSpeed;
    private float followDistance;
    private float fireDistance;
    private float stopDistance;

	Vector2 find;
	// Use this for initialization

	


	private void Update()
	{
		FollowPlayer();
	}

	private void OnTriggerEnter(Collider gamespace)
	{
		SpotObject();
	}

	void SpotObject()
	{

	}


	public void LoadEnemyAttackRotation(EnemyAttackRotation enemy2)
	{
		if (enemy2 == null) return;

		this.enemy2 = enemy2;

		Destroy(enemyHead);
		speed = enemy2.moveSpeed;


		
		bulletSpeed = enemy2.bulletSpeed;
		axeSpeed = enemy2.axeSpeed;
        followDistance = enemy2.followDistance;
        fireDistance = enemy2.fireDistance;
        stopDistance = enemy2.stopDistance;
        enemyRotation = enemy2.rotation;
        enemyTransform = enemy2.scale;

       
		//fill this in

		enemyHead = Instantiate(enemy2.charecter, enemySpawn.position, enemyRotation.rotation,transform);

        Vector3 enemyScale = enemyTransform.localScale;
        


        enemyHead.transform.localScale = enemyScale;

		timeout = enemy2.attackCooldown;

	}

	void FollowPlayer()
	{
		Vector3 targetPosition = target.transform.position;

		float distance = Vector3.Distance(targetPosition, this.transform.position);



		if (distance < followDistance && distance> stopDistance)
		{
			find = (target.position - transform.position) ;
			transform.Translate(find.normalized * Time.deltaTime * speed);
		}

		if (distance < fireDistance && distance > stopDistance)
		{
			Shoot();
		}

		if (distance < stopDistance)
		{
			Melee();
		}
	}
	void Shoot()
	{

		timeout -= Time.deltaTime;
		if (timeout < 0)
		{
			var bullet = Instantiate(spherePrefab, weaponSpawn.position, weaponRotation.rotation);
			bullet.GetComponent<Rigidbody>().velocity = find * bulletSpeed;


			Destroy(bullet, 2f);

			timeout = enemy2.attackCooldown;
		}


	}
	void Melee()
	{

		timeout -= Time.deltaTime;
		if (timeout < 0)
		{
			var axe = Instantiate(axePrefab, weaponSpawn.position, weaponRotation.rotation);
			axe.GetComponent<Rigidbody>().velocity = find * axeSpeed;


			Destroy(axe, 2f);

			timeout = enemy2.attackCooldown;
		}


	}
}
