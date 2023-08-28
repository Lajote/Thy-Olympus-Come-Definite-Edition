using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public static PlayerMovement instance;

    public CharacterController controller; 
    public Animator animator;
    public float runSpeed =40f;
    public float bounceForce;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool inDoubleJ =false;

    private Rigidbody2D RB;
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
        RB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if(knockBackCounter <= 0)
        {
            inDoubleJ = animator.GetBool("DoubleJumping");

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                if(inDoubleJ == false)
                {
                    animator.SetBool("Jumping", true);
                }   
            
                        
            }
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }

        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            RB.velocity = new Vector2(0f, knockBackForce);
        }

        

    }

    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
        animator.SetBool("DoubleJumping", false);
    }

    public void OnCrouching(bool Crouching)
    {
        Crouching = crouch;
        animator.SetBool("Crouching", Crouching);
        

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump =false;

    }

    public void Knockback()
    {
        knockBackCounter = knockBackLength;
    }

    public void Bounce()
    {
        RB.velocity = new Vector2(RB.velocity.x, bounceForce);
    }
}
