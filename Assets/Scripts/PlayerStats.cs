using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int baseScore = 100;
    [SerializeField] int correctPoints = 50;
    [SerializeField] int inCorrectPoints = 25;

    private CameraSpeed cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = GetComponent<CameraSpeed>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Score Functionality
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Correct")
        {
            scoreText.text = "Score = " + (baseScore + correctPoints).ToString();
        }
        else if (collision.gameObject.tag == "Incorrect")
        {
            scoreText.text = "Score = " + (baseScore - inCorrectPoints).ToString();
        }
    }

    //When player exits a correct answer increase camera speed
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Correct")
        {
            
        }
    }



}
