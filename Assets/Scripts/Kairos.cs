using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kairos : MonoBehaviour
{
    public Timer timer;
    public CharacterController CC;
    public float jumpkairos;
    public float normalJump;
    public float boostedJump;


    public SpriteRenderer SRKairos;

    private float targetAlpha;
    public float alphaChangeSpeedON = 10.0f; // Adjust this value to control the speed of alpha transition to ON.
    public float alphaChangeSpeedOFF = 6.0f; // Adjust this value to control the speed of alpha transition to OFF.

    // Start is called before the first frame update
    void Start()
    {
        normalJump = CC.m_JumpForce;
        boostedJump = normalJump * 1.5f;
        targetAlpha = 0f; // Initialize the target alpha to 0.


    }

    // Update is called once per frame
    void Update()
    {
        jumpkairos = timer.seconds;
        /*Debug.Log("Residuo de la divisíon es ");
        Debug.Log(jumpkairos % 5);*/
        if (jumpkairos % 5 == 0)
        {
            // Debug.Log("KAIROS");
            CC.m_JumpForce = boostedJump;
            targetAlpha = 1f; // Set the target alpha to 1 when Kairos is active.
            SRKairos.color = new Color(SRKairos.color.r, SRKairos.color.g, SRKairos.color.b, Mathf.Lerp(SRKairos.color.a, targetAlpha, alphaChangeSpeedON * Time.deltaTime));

        }
        else
        {
            CC.m_JumpForce = normalJump;
            targetAlpha = 0f; // Set the target alpha to 0 when Kairos is not active.
            SRKairos.color = new Color(SRKairos.color.r, SRKairos.color.g, SRKairos.color.b, Mathf.Lerp(SRKairos.color.a, targetAlpha, alphaChangeSpeedOFF * Time.deltaTime));
        }

        
    }
}
