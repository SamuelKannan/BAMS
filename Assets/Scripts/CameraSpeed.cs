using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeed : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 0.02f;
    [SerializeField] float iteration = 0.0035f;
    [SerializeField] PlayerOneMovement one;
    //AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //source = GetComponent<AudioSource>();
    }

    /*private void Update()
    {
        Debug.Log("Passed ?: " + one.GetPassed);
    }*/

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, cameraSpeed, 0);
        if (one.GetPassed == true)
        {
            cameraSpeed += iteration;
            one.SetPassed(false);
        }
        
    }
}
