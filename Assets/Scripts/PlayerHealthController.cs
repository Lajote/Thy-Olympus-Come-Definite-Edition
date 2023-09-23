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
            PlayerMovement.instance.animator.SetTrigger("Hurt");
            AudioManager.instance.PlaySXF(7);

            if(currentHealth <= 0)
            {
                currentHealth =0;

                Instantiate(DeadEffect, PlayerMovement.instance.transform.position, PlayerMovement.instance.transform.rotation);
                AudioManager.instance.PlaySXF(4);
                gameObject.SetActive(false);
                AudioManager.instance.BgmStop();
                GameOver.show();
            }
            else
            {
                invincibleCounter = invincibleLength;
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
                
               // PlayerMovement.instance.Knockback();
            }
            UiController.instance.UpdateHealthDisplay();
        }
        
    }

    public void Dead()
    {
        PlayerMovement.instance.animator.SetTrigger("Hurt");
        Instantiate(DeadEffect, PlayerMovement.instance.transform.position, PlayerMovement.instance.transform.rotation);
        gameObject.SetActive(false);
        AudioManager.instance.BgmStop();
        GameOver.show();
    }

}
