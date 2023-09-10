using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeveloperButton : MonoBehaviour
{
    public GameObject DevUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player")
        {

            DevUI.SetActive (true);

            // Debug.Log("Vamos bien");
        }
    }
    public void exitDev()
    {
        DevUI.SetActive(false);
    }

    public void DevTools()
    {
        Debug.Log("Welcome to the DevTools environment");
    }

    public void scenes()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }




}
