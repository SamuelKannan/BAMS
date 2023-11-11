using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 movePlayerOne;
    private float dirPlayerOneX;
    private float dirPlayerOneY;

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
        dirPlayerOneX = Input.GetAxisRaw("Player1_Horizontal");
        dirPlayerOneY = Input.GetAxisRaw("Player1_Vertical");

        movePlayerOne = new Vector2(dirPlayerOneX, dirPlayerOneY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(movePlayerOne.x, movePlayerOne.y) * moveSpeed * Time.deltaTime;
    }
}
