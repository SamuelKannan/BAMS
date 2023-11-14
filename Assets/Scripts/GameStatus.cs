using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    [SerializeField] GameObject player4;
    [SerializeField] GameObject scorePlayer1;
    [SerializeField] GameObject scorePlayer2;
    [SerializeField] GameObject scorePlayer3;
    [SerializeField] GameObject scorePlayer4;
    [SerializeField] GameObject attackPlayer1;
    [SerializeField] GameObject attackPlayer2;
    [SerializeField] GameObject attackPlayer3;
    [SerializeField] GameObject attackPlayer4;
    [SerializeField] GameObject startOne;
    [SerializeField] GameObject startTwo;
    [SerializeField] GameObject startThree;
    [SerializeField] GameObject startFour;
    [SerializeField] GameObject finishOne;
    [SerializeField] GameObject finishTwo;
    [SerializeField] GameObject finishThree;
    [SerializeField] GameObject finishFour;
    [SerializeField] GameObject countDown;
    [SerializeField] GameObject startGame;
    [SerializeField] PlayerOneScore p1Score;
    [SerializeField] PlayerTwoScore p2Score;
    [SerializeField] PlayerThreeScore p3Score;
    [SerializeField] PlayerFourScore p4Score;
    [SerializeField] StartTimer start;
    [SerializeField] TextMeshProUGUI winText;
    
  

    bool playerOneActive = false;
    bool playerTwoActive = false;
    bool playerThreeActive = false;
    bool playerFourActive = false;
    bool playerOneDeath = false;
    bool playerTwoDeath = false;
    bool playerThreeDeath = false;
    bool playerFourDeath = false;

    int remainingPlayers = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayers();
        PlayersDeath();
        Debug.Log("Remaining players: " + remainingPlayers);
    }

    void CheckPlayers()
    {
        if (Input.GetKeyDown("space"))
        {
            start.enabled = true;
            startGame.SetActive(false);
            countDown.SetActive(true);
            
        }

        if (Input.GetKeyDown("1"))
        {
            startOne.SetActive(false);
            scorePlayer1.SetActive(true);
            attackPlayer1.SetActive(true);
            player1.SetActive(true);
            playerOneActive = true;
            remainingPlayers++;

        }

        if (Input.GetKeyDown("2"))
        {
            startTwo.SetActive(false);
            scorePlayer2.SetActive(true);
            attackPlayer2.SetActive(true);
            player2.SetActive(true);
            playerTwoActive = true;
            remainingPlayers++;
        }

        if (Input.GetKeyDown("3"))
        {
            startThree.SetActive(false);
            scorePlayer3.SetActive(true);
            attackPlayer3.SetActive(true);
            player3.SetActive(true);
            playerThreeActive = true;
            remainingPlayers++;
        }

        if (Input.GetKeyDown("4"))
        {
            startFour.SetActive(false);
            scorePlayer4.SetActive(true);
            attackPlayer4.SetActive(true);
            player4.SetActive(true);
            playerFourActive = true;
            remainingPlayers++;
        }
    }

    void PlayersDeath()
    {
        if (p1Score.GetScore == 0)
        {
            scorePlayer1.SetActive(false);
            attackPlayer1.SetActive(false);
            finishOne.SetActive(true);
            playerOneDeath = true;
            remainingPlayers--;
            Win();
        }

        if (p2Score.GetScore == 0)
        {
            scorePlayer2.SetActive(false);
            attackPlayer2.SetActive(false);
            finishTwo.SetActive(true);
            playerTwoDeath = true;
            remainingPlayers--;
            Win();
        }

        if (p3Score.GetScore == 0)
        {
            scorePlayer3.SetActive(false);
            attackPlayer3.SetActive(false);
            finishThree.SetActive(true);
            playerThreeDeath = true;
            remainingPlayers--;
            Win();
        }

        if (p4Score.GetScore == 0)
        {
            scorePlayer4.SetActive(false);
            attackPlayer4.SetActive(false);
            finishFour.SetActive(true);
            playerFourDeath = true;
            remainingPlayers--;
            Win();
        }
    }

    void Win()
    {
        if (remainingPlayers == 1)
        {
            if (playerOneActive == true && playerOneDeath == false)
            {
                winText.text = "Player 1 wins";
                winText.gameObject.SetActive(true);
        
               
            }
            else if (playerTwoActive == true && playerTwoDeath == false)
            {
                winText.text = "Player 2 wins";
                winText.gameObject.SetActive(true);
            }
            else if (playerThreeActive == true && playerThreeDeath == false)
            {
                winText.text = "Player 3 wins";
                winText.gameObject.SetActive(true);
            }
            else if (playerFourActive == true && playerFourDeath == false)
            {
                winText.text = "Player 4 wins";
                winText.gameObject.SetActive(true);
            }
        }

    }
}
