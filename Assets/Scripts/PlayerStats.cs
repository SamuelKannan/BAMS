using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int baseScore = 1000;
    [SerializeField] int correctPoints = 50;
    [SerializeField] int inCorrectPoints = 25;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Score Functionality
    private void OnTriggerEnter2D(Collider2D collision)
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

}
