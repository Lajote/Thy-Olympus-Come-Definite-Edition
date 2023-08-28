using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            CharacterController.instance.collected++;
            UiController.instance.UpdateGemCount();
            AudioManager.instance.PlaySXF(3); 
            gameObject.SetActive(false);

        }
    }
}
