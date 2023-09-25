using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsON : MonoBehaviour
{

    public SpriteRenderer darkness;

    private float targetAlpha;
    public float alphaChangeSpeedON = 10.0f; // Adjust this value to control the speed of alpha transition to ON.
    bool POWER = false;
    // Start is called before the first frame update
    void Start()
    {
        targetAlpha = 0f; // Initialize the target alpha to 0.
    }

    // Update is called once per frame
    void Update()
    {
        
        if (POWER)
        {
            darkness.color = new Color(darkness.color.r, darkness.color.g, darkness.color.b, Mathf.Lerp(darkness.color.a, targetAlpha, alphaChangeSpeedON * Time.deltaTime));
        }
    }

    public void lightsOn()
    {
            POWER = true;
        
    }

}
