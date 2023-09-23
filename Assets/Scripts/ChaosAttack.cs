using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosAttack : MonoBehaviour
{
    public bool spotted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
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
        }
    }


}
