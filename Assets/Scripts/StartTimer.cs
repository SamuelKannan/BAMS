using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] float targetTime = 3f;
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
        //Timer();
    }

    void Timer()
    {
        targetTime -= Time.deltaTime;
        timeText = (int)targetTime;
        timer.text = timeText.ToString();
        if (targetTime <= 1.0f)
        {
            timer.text = "Go";
            speed.enabled = true;
            //timer.gameObject.SetActive(false);
        }
    }
}
