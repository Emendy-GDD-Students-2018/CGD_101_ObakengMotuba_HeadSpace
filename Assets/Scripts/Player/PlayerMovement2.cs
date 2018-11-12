using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHealthUI))]
public class PlayerMovement2 : SkillController
{
	public Rigidbody Player;
	private GameObject currentHead;
	public float moveSpeed;
	public float jump;
	public int attack;

    public bool isFacingRight =false;
	public SpaceShift[] player;
	public GameObject projectilePrefab;
    public GameObject meleePrefab;

    private List<EnemyState> enemies;
    private List<EnemyState2> enemies2;

    public Transform playerSpawn;
	public Transform playerRotation;

	public float bulletSpeed = 8.0f;
    public float meleeSpeed = 4.0f;

    protected PlayerHealthUI healthUI;
    public Transform playerScale;
    
    public Transform lookAtPos;
	public Transform firePoint;

    public float currentAmmo;
    public float maxAmmo;

    public float reloadtime;
    public bool isReloading = false;


    public Image currentPhaseshiftImage;
	public Image cooldownshiftImage;
	public Image pauseMenuImage;
	public Image pauseMenuColor;
    public Image bloodLust;


	public bool isShifted = false;
	public void Start()
	{
		healthUI = GetComponent<PlayerHealthUI>();
		enemies = FindObjectsOfType<EnemyState>().ToList();
        enemies2 = FindObjectsOfType<EnemyState2>().ToList();
        currentAmmo = maxAmmo;
		LoadSpaceShift(player[0]);
		isShifted = false;
        isFacingRight = true;
    }

	void Update()
	{

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector2 horizontalmovement = new Vector3(horizontal, 0f, 0f);
		transform.Translate(horizontalmovement * Time.deltaTime * moveSpeed);


		if (Input.GetMouseButtonDown(1) && currentAmmo>0)
		{
            currentAmmo--;
			Fired();
		}

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) && currentAmmo <= 0)
        {
            Melee();
        }
    



		if (isShifted)
		{

			imageCoolDown.fillAmount += 1 / cooldown * Time.deltaTime;
			if (imageCoolDown.fillAmount >= 1)
			{
				imageCoolDown.fillAmount = 0;
				isShifted = false;
			}


		}


		if (GetComponent<Power>().reverted == isActiveAndEnabled)
		{
			isShifted = false;
		}

        if(Input.GetKeyUp(KeyCode.A))
        {
            isFacingRight = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            isFacingRight = true;

        }


        if (!isFacingRight)
        {
            firePoint.eulerAngles = new Vector3(0, -90, 0);
            firePoint.localPosition = new Vector3(-0.4f, 0f, 0f);
            lookAtPos.eulerAngles = new Vector3(0, 180, 0);
            
        }
        else
        {
            firePoint.eulerAngles = new Vector3(0, 90, 0);
            firePoint.localPosition = new Vector3(0.4f, 0f, 0f);
            lookAtPos.eulerAngles = new Vector3(0, 0, 0);
            
        }

        if(currentAmmo<=0)
        {
            StartCoroutine(Reload());
        }


    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadtime);

        if (currentAmmo < maxAmmo)
        {

            currentAmmo = Mathf.MoveTowards(currentAmmo, maxAmmo, reloadtime * Time.deltaTime);
           
        }

        if(currentAmmo==maxAmmo)
        {
            isReloading = false;
        }
        
            
    }

    public virtual void Move(Vector2 movementVector)
	{
		lookAtPos.position = transform.position + Vector3.right * movementVector.x;
		transform.LookAt(lookAtPos);
	}

	private void OnTriggerEnter(Collider other)
	{
		var damage = other.GetComponent<PlayerDamage>();
		if (damage != null)
		{
			//Health -= other.damage
			healthUI.currentHealth -= damage.damage;
			healthUI.UpdateHealthImage();
			Destroy(other.gameObject);
		}
	}




	void Fired()
	{

       
		GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
		Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();


		if (bulletBody != null)
		{
			bulletBody.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

			Destroy(bullet.gameObject, 4f);
		}



		Destroy(bullet, 4.0f);
	}

    void Melee()
    {
        GameObject axe = Instantiate(meleePrefab, firePoint.position, firePoint.rotation);
        Rigidbody axeBody = axe.GetComponent<Rigidbody>();


        if (axeBody != null)
        {
            axeBody.AddForce(firePoint.forward * meleeSpeed, ForceMode.Impulse);

            Destroy(axe.gameObject, 1f);
        }



        Destroy(axe, 1.0f);
    }

    void FixedUpdate()
	{

		if (Input.GetKeyDown(KeyCode.Space))
		{
			JumpGood();
		}
	}
	public virtual void JumpGood()
	{
		Vector3 jumpup = new Vector3(0f, jump, 0f);
		Player.AddForce(jumpup, ForceMode.Impulse);
	}

	public void LoadSpaceShift(SpaceShift spaceShift)
	{
		isShifted = true;

		gameObject.layer = LayerMask.NameToLayer(spaceShift.collisionLayer);

		Destroy(currentHead);
		moveSpeed = spaceShift.moveSpeed;
		jump = spaceShift.jump;
		attack = spaceShift.attack;


		//fill this in

		currentHead = Instantiate(spaceShift.charecter, playerSpawn.position, playerRotation.rotation, this.transform);
	


        Vector3 headScale =  playerScale.localScale;

        Vector3 headRotation = playerRotation.localEulerAngles;
        headScale = currentHead.transform.localScale;
        headRotation = currentHead.transform.localEulerAngles;

        BackgroundShifter.Instance.SwapBackground(spaceShift);
		foreach (EnemyState shift in enemies)
		{
			if (shift != null)
			{
                shift.LoadEnemyAttackRotation(spaceShift.enemy);
                
            }
		}
        foreach (EnemyState2 shift2 in enemies2)
        {
            if (shift2 != null)
            {
                shift2.LoadEnemyAttackRotation(spaceShift.enemy2);
            }
        }
        ImageShifter.Instance.SwapImage(spaceShift);
		pauseMenuImage.sprite = spaceShift.uiImage;
		currentPhaseshiftImage.sprite = spaceShift.uiImage;
		pauseMenuImage.sprite= spaceShift.uiImage;
		cooldownshiftImage.sprite = spaceShift.uiImage;
		pauseMenuColor.color = spaceShift.colo;
        bloodLust.color = spaceShift.vision;



    }

    public void LoadSpaceShifted(SpaceShift spaceShift)
    {
        isShifted = false;
        gameObject.layer = LayerMask.NameToLayer(spaceShift.collisionLayer);

        Destroy(currentHead);
        moveSpeed = spaceShift.moveSpeed;
        jump = spaceShift.jump;
        attack = spaceShift.attack;



        //fill this in

        currentHead = Instantiate(spaceShift.charecter, playerSpawn.position, playerRotation.rotation, this.transform);

        Vector3 headScale = playerScale.localScale;
        Vector3 headRotation = playerRotation.localEulerAngles;
        headScale = currentHead.transform.localScale;
        headRotation = currentHead.transform.localEulerAngles;

        BackgroundShifter.Instance.SwapBackground(spaceShift);
        foreach (EnemyState shift in enemies)
		{
			if (shift != null)
			{
                shift.LoadEnemyAttackRotation(spaceShift.enemy);
                
            }
		}
        foreach (EnemyState2 shift2 in enemies2)
        {
            if (shift2 != null)
            {
                shift2.LoadEnemyAttackRotation(spaceShift.enemy2);
            }
        }
        ImageShifter.Instance.SwapImage(spaceShift);
        pauseMenuImage.sprite = spaceShift.uiImage;
        currentPhaseshiftImage.sprite = spaceShift.uiImage;
        pauseMenuImage.color = spaceShift.colo;
        cooldownshiftImage.sprite = spaceShift.uiImage;
        pauseMenuImage.sprite = spaceShift.uiImage;
        bloodLust.color = spaceShift.vision;

    }

    



	
}