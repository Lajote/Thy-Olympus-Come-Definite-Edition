// este Script, si bien no lo hice de 0 para este juego, es un script de un tutorial que use en un proyecto de prueba anterior,
// cuando apenas estaba comenzando a aprender unity, si bien en un inicio fue descargado, lo he modificado en todo este tiempo al punto de que no queda casi nada del original
// dicho esto de todas formas hago la aclaracion ya que en el formato decia que el codigo debia ser propio, y este Script al haber sido tan modificado ya lo siento como propio.
// espero no estar incumpliendo ninguna norma y de ser asi por favor comunicarse para cambiar el Script por uno completamente nuevo, 
// ya que lo use simplemente para ahorrar tiempo a travez del trabajo ya hecho anteriormente por mi persona.


using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	public static CharacterController instance;
	//[SerializeField] permite editarlo desde unity.
    //[Header] pone un tiulo,ayuda a mantener organizado el inspector de unity.
	//[Range()] muestra una barra para editar en unity dentro de un rango establecido.
	//[Space] salta un espacio, ayuda a mantener organizado el inspector de unity.
	[Header("Movimiento")]
	[SerializeField] private float m_JumpForce = 400f;							
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;
	[Header("Colisiones")]							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;							
	[SerializeField] private Transform m_CeilingCheck;							
	[SerializeField] private Collider2D m_CrouchDisableCollider;
	[Space]				
	[SerializeField] private Animator animator;
	const float k_GroundedRadius = .2f;
	private bool m_Grounded;  
	private bool m_DoubleJump;          
	const float k_CeilingRadius = .2f; 
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;

	public int collected;

	[Header("Eventos")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
		instance = this;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		
		if (!crouch)
		{
			
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		
		if (m_Grounded || m_AirControl)
		{

			
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				
				move *= m_CrouchSpeed;

				
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			
			if (move > 0 && !m_FacingRight)
			{
				
				Flip();
			}
			
			else if (move < 0 && m_FacingRight)
			{
				
				Flip();
			}
		}
		
if (m_Grounded)
		{
			m_DoubleJump = true;
		}

		if (m_Grounded && jump)
		{
			
			m_Grounded = true;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			AudioManager.instance.PlaySXF(8);
		}
		else if (m_DoubleJump && jump)
		{
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			animator.SetBool("Jumping", false);
			animator.SetBool("DoubleJumping", true);
			m_DoubleJump = false;
			AudioManager.instance.PlaySXF(8);
		}
	}


	private void Flip()
	{
		
		m_FacingRight = !m_FacingRight;

		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
