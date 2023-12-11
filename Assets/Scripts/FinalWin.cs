using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class FinalWin : MonoBehaviour
{
    [SerializeField] GameStatus gameStatus;
    [SerializeField] TextMeshProUGUI finalWinText;
    int a, b, c, d;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        find_greatest();
    }

    void find_greatest()
    {
        Debug.Log("insdie the function");
        a = gameStatus.GetOneScore();
        b = gameStatus.GetTwoScore();
        c = gameStatus.GetThreeScore();
        d = gameStatus.GetFourScore();

        if (a > b)
        {
            if (a > c)
            {
                if (a > d)
                {
                    finalWinText.text = "Player 1 wins";
                    finalWinText.gameObject.SetActive(true);
                }
                else
                {
                    finalWinText.text = "Player 4 wins";
                    finalWinText.gameObject.SetActive(true);
                }
            }
        }
        else if (b > c)
        {
            if (b > d)
            {
                finalWinText.text = "Player 2 wins";
                finalWinText.gameObject.SetActive(true);
            }
            else
            {
                finalWinText.text = "Player 4 wins";
                finalWinText.gameObject.SetActive(true);
            }
        }
        else if (c > d)
        {
            finalWinText.text = "Player 3 wins";
            finalWinText.gameObject.SetActive(true);
        }
        else
        {
            finalWinText.text = "Player 4 wins";
            finalWinText.gameObject.SetActive(true);
        }
    }
}
