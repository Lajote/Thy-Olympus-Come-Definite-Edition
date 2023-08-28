using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject deadEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            PlayerMovement.instance.Bounce();
            Instantiate(deadEffect, other.transform.position, other.transform.rotation);
            other.transform.parent.gameObject.SetActive(false);
            AudioManager.instance.PlaySXF(6);
            
        }
        
        if (other.tag == "Boss")
        {
            PlayerMovement.instance.Bounce();
            BossController.instance.DealDamage();           
        }

       
    }      
    
}
