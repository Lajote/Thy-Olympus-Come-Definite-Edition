using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private float z;
    public float smoothnes = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 from = transform.position;
        Vector3 to = player.transform.position;
        Vector3 result = Vector3.Lerp(from, to, smoothnes);

        // Update the camera's position smoothly using the result of the Lerp function
        transform.position = new Vector3(result.x, result.y, z);
    }
}