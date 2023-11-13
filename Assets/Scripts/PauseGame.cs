using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    [SerializeField] GameObject player4;
    CameraSpeed camera;

    void Start()
    {
        camera = GetComponent<CameraSpeed>();
    }

    void Update()
    {
        if(Input.GetKeyDown("Escape"))
        {

        }
    }
}
