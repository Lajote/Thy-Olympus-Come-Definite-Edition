using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;

    public GameObject DeadEffect;

    private float invincibleCounter;

    private SpriteRenderer SR;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;

        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(invincibleCounter> 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
            }
        }

    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth--;
            UiManager.uiManager.UpdateHealthDisplay();

            AudioManager.audioManager.PlaySXF(7);

            if(currentHealth <= 0)
            {
                currentHealth =0;
                Instantiate(DeadEffect, PlayerMovement.instance.transform.position, PlayerMovement.instance.transform.rotation);
                AudioManager.audioManager.PlaySXF(4);
                gameObject.SetActive(false);
                AudioManager.audioManager.BgmStop();
                GameOver.show();
            }
            else
            {
                invincibleCounter = invincibleLength;
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
                
               // PlayerMovement.instance.Knockback();
            }
            UiManager.uiManager.UpdateHealthDisplay();
        }
        
    }

    public void Dead()
    {
        
        Instantiate(DeadEffect, PlayerMovement.instance.transform.position, PlayerMovement.instance.transform.rotation);
        gameObject.SetActive(false);
        AudioManager.audioManager.BgmStop();
        GameOver.show();
    }

}
