using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            
            GameManager.instance.collected++;
            UiManager.uiManager.UpdateEtherCount();
            AudioManager.audioManager.PlaySXF(3); 
            gameObject.SetActive(false);

        }
    }
}
