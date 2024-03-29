using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D RB;
    public Animator animator;

    public SpriteRenderer SR;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
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
}
