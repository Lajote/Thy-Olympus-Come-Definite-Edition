using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosAttack : MonoBehaviour
{
    public bool spotted = false;
    public bool atacked = false;
    public float countDown = 0.2f;
    public float passiveTime = 2;
    public float passiveOver;

    // Start is called before the first frame update
    void Start()
    {
        passiveOver = passiveTime;
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

        
        if (spotted)
        {
            passiveOver = passiveOver - 1 * Time.deltaTime;
            if (passiveOver <= 0)
            {
                Damaging();
                Debug.Log("Juimonos");
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            spotted = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spotted = false;
            passiveOver = passiveTime;
        }
    }

    void Damaging()
    {
        if (GameManager.instance.collected >= 0 && !atacked)
        {
            GameManager.instance.collected--;
            atacked = true;
        }
        PlayerHealthController.instance.DealDamage();
        UiManager.uiManager.UpdateEtherCount();

    }


}
