using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeed : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 0.5f;
    //AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, cameraSpeed, 0);  
    }
}
