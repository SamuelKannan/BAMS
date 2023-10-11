using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeed : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float iteration = 0.017f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, speed, 0);  
    }

    //Update camera speed after every correct answer
    public void UpdateCameraSpeed()
    {
        iteration += iteration;
    }
}
