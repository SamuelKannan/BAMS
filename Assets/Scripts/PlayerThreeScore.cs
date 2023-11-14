using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerThreeScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int baseScore = 100;
    [SerializeField] int correctPoints = 50;
    [SerializeField] int inCorrectPoints = 25;
    [SerializeField] int obstaclepoints = 25;
    [SerializeField] GameObject explosion;

    void Update()
    {
        if (baseScore <= 0)
        {
            Destroy(gameObject, 1.5f);
            explosion.SetActive(true);
        }
    }

    public int GetScore
    {
        get { return baseScore; }
    }

    //Score Functionality
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Correct")
        {
            baseScore += correctPoints;
            scoreText.text = "P3 Points = " + baseScore.ToString();
        }
        else if (collision.gameObject.tag == "Incorrect")
        {
            baseScore -= inCorrectPoints;
            scoreText.text = "P3 Points = " + baseScore.ToString();
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            baseScore -= obstaclepoints;
            scoreText.text = "P3 Points = " + baseScore.ToString();
        }
    }
}
