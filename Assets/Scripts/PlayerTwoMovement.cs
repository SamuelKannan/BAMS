using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 movePlayerTwo;
    private float dirPlayerTwoX;
    private float dirPlayerTwoY;

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
        dirPlayerTwoX = Input.GetAxisRaw("Player2_Horizontal") * moveSpeed * Time.deltaTime;
        dirPlayerTwoY = Input.GetAxisRaw("Player2_Vertical") * moveSpeed * Time.deltaTime;

        movePlayerTwo = new Vector2(dirPlayerTwoX, dirPlayerTwoY).normalized;
    }

    void Move()
    {
        //transform.Translate(dirPlayerTwo, 0, 0);
        rb.velocity = new Vector2(movePlayerTwo.x, movePlayerTwo.y);
    }
}
