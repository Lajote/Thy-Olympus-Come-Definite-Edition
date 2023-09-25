using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNoche : MonoBehaviour
{

    public GameObject cielo;

    public float ether;
    public float maxEther;
    public float changeInput;
    
    bool changeTime = false;

    public float transitionSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ether = (float)GameManager.instance.collected;
        maxEther = (float)GameManager.instance.maxEther;
        changeInput = maxEther / 2;
        if (ether>=changeInput) 
        {
            ChangeTime();
        }
        if (changeTime)
        {
            float targetRotation = 180f;
            float currentRotation = cielo.transform.rotation.eulerAngles.z;
            float newRotation = Mathf.Lerp(currentRotation, targetRotation, transitionSpeed * Time.deltaTime);
            cielo.transform.rotation = Quaternion.Euler(cielo.transform.rotation.eulerAngles.x, cielo.transform.rotation.eulerAngles.y, newRotation);
        }

    }

    public void ChangeTime()
    {
            changeTime = true;
        
    }

}
