using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] float targetTime = 3f;
    [SerializeField] PlayerOneMovement player1;
    [SerializeField] PlayerTwoMovement player2;
    [SerializeField] PlayerThreeMovement player3;
    [SerializeField] PlayerFourMovement player4;
    CameraSpeed speed;
    int timeText;

    void Start()
    {
        speed = GetComponent<CameraSpeed>();
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("Timer", 1f);
    }

    void Timer()
    {
        targetTime -= Time.deltaTime;
        timeText = (int)targetTime;
        timer.text = timeText.ToString();
        if (targetTime <= 1.0f)
        {
            timer.text = "Go!";
            speed.enabled = true;
            player1.enabled = true;
            player2.enabled = true;
            player3.enabled = true;
            player4.enabled = true;
            
        }
    }

}
