using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosAttackController : MonoBehaviour
{
    public ChaosAttack right;
    public ChaosAttack left;

    [SerializeField] private Animator animatorRight;
    [SerializeField] private Animator animatorLeft;
    // Start is called before the first frame update
    void Start()
    {
        animatorRight = right.GetComponent<Animator> ();
        animatorLeft = left.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right.spotted)
        {
            
            animatorRight.SetBool("Attacking", true);
            //PlayerHealthController.instance.DealDamage();

        }
        else { animatorRight.SetBool("Attacking", false); }
        
        if (left.spotted)
        {
            
            animatorLeft.SetBool("Attacking", true);
            //PlayerHealthController.instance.DealDamage();
        }
        else { animatorLeft.SetBool("Attacking", false); }
    }



}
