using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsTimer : MonoBehaviour
{
    [SerializeField] float targetTime = 20f;
    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
