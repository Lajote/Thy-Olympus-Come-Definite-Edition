using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosAttack : MonoBehaviour
{
    public bool spotted = false;
    public bool atacked = false;
    public float countDown = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(atacked)
        {
            countDown = countDown - 1 * Time.deltaTime;
            if(countDown <= 0) 
            {
                atacked= false;
                countDown= 2;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.instance.collected >= 0 && !atacked) 
            { 
                GameManager.instance.collected--;
                atacked= true;
            } 
            spotted = true;
            PlayerHealthController.instance.DealDamage();
            UiManager.uiManager.UpdateEtherCount();

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spotted = false;
        }
    }


}
