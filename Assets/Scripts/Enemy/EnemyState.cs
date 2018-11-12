using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{

	public EnemyAttackRotation enemy;
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

	public void Start()
	{
		LoadEnemyAttackRotation(enemy);
		print("Enemy: " + enemy.charecter);
	}


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


	public void LoadEnemyAttackRotation(EnemyAttackRotation enemy)
	{
		if (enemy == null) return;

		this.enemy = enemy;

		Destroy(enemyHead);
		speed = enemy.moveSpeed;

;
		bulletSpeed = enemy.bulletSpeed;
		axeSpeed = enemy.axeSpeed;
        followDistance = enemy.followDistance;
        fireDistance = enemy.fireDistance;
        stopDistance = enemy.stopDistance;
        enemyRotation = enemy.rotation;
        enemyTransform = enemy.scale;

       
		//fill this in

		enemyHead = Instantiate(enemy.charecter, enemySpawn.position, enemyRotation.rotation,transform);

        Vector3 enemyScale = enemyTransform.localScale;
        


        enemyHead.transform.localScale = enemyScale;

		timeout = enemy.attackCooldown;

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

			timeout = enemy.attackCooldown;
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

			timeout = enemy.attackCooldown;
		}


	}
}
