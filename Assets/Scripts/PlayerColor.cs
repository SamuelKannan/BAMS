using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerColor : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Incorrect" || collision.tag == "Obstacle")
        {
            sprite.color = Color.red;
        }
        else if (collision.tag == "Correct")
        {
            sprite.color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.color = Color.white;
    }
}
