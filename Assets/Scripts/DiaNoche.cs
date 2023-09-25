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
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 180;
            cielo.transform.rotation = Quaternion.Euler(rotationVector);
        }

    }

    public void ChangeTime()
    {
            changeTime = true;
        
    }

}
