using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthUI : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float recovery= 0.25f;
    public float percentageHealth;
    public int spriteIndex;

    public bool isDead = false;
    public Image healthImage;
    public Text health;

	public Sprite[] healthSprites;

    public bool isRegenerating = false;
	private void Start()
	{
		maxHealth = 4.51f;
		currentHealth = 4.51f;
		UpdateHealthImage();
        HealthScore();
	}

	public void UpdateHealthImage()
	{
		percentageHealth = (float)Mathf.RoundToInt(currentHealth)/ (float)Mathf.RoundToInt(maxHealth);

		spriteIndex = Mathf.RoundToInt(percentageHealth * 5) ;
		if (spriteIndex > 0)
		{
			healthImage.sprite = healthSprites[spriteIndex];
		}
		else
		{
			print("GameOver");
		}
	}

    private void Update()
    {
        NeedHealth();

        if (spriteIndex <= 0)
        {
            isRegenerating = false;
            isDead = true;
        }

        if(isDead)
        {
            Dead();
        }
        
    }

    void NeedHealth()
    {
        if (currentHealth < maxHealth)
        {
            isRegenerating = true;
        }

        if (isRegenerating)
        {            
            currentHealth = Mathf.MoveTowards(currentHealth, maxHealth, recovery* Time.fixedDeltaTime);
            HealthScore();
            UpdateHealthImage();
        }
    }

    void Dead ()
    {

        SceneManager.LoadScene(3);
    }

    void HealthScore()
    {
        float healthScore = percentageHealth * 100;
        health.text = "Health:" + healthScore.ToString() + "%";
    }

}
    
       


    

    



