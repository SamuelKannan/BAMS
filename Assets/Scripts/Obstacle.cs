using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Sprite explosion;
    SpriteRenderer sprite;
    

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" ||
            collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            sprite.sprite = explosion;
            Destroy(gameObject, 3f);
        }
    }
}