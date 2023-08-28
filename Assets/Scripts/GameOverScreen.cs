using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private SpriteRenderer SR;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
