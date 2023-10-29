using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 movePlayerTwo;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float dirPlayerTwo = Input.GetAxisRaw("Player2");

        movePlayerTwo = new Vector2(dirPlayerTwo, 0).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(movePlayerTwo.x * moveSpeed, 0);
    }
}
