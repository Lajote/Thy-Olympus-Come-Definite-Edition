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
    // Start is called before the first frame update
    void Start()
    {
        normalJump = CC.m_JumpForce;
        boostedJump = normalJump * 1.5f;
   

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
        }
        else
        {
            CC.m_JumpForce = normalJump;
        }
    }
}
