using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;
    public float moveSpeed;
    public int currentHealth, maxHealth;
    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D RB;
    private Animator animator;
    public GameObject DeadEffect;
    public SpriteRenderer SR;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    public float invincibleLength;
    private float invincibleCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
        moveCount = moveTime;

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

        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if(movingRight)
            {
                RB.velocity = new Vector2(moveSpeed, RB.velocity.y);
                SR.flipX = true;

                if(transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                RB.velocity = new Vector2(-moveSpeed, RB.velocity.y);
                SR.flipX = false;

                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <=0)
            {
                waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
            animator.SetBool("Moving", true);
        }
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            RB.velocity = new Vector2(0f, RB.velocity.y);
            
            if (waitCount <=0)
            {
                moveCount = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
            }
            animator.SetBool("Moving", false);
        }
        
        
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            currentHealth--;
            AudioManager.instance.PlaySXF(6);

            if(currentHealth <= 0)
            {
                currentHealth =0;

                Instantiate(DeadEffect, gameObject.transform.position, gameObject.transform.rotation);
                AudioManager.instance.PlaySXF(6);
                gameObject.SetActive(false);
                AudioManager.instance.BgmStop();
                AudioManager.instance.win();
                GameOver.win();
            }
            else
            {
                invincibleCounter = invincibleLength;
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.5f);
                
            }
            
        }
        
    }
}
