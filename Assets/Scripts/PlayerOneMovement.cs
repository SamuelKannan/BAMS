using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 movePlayerOne;
    private float dirPlayerOne;

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
        dirPlayerOne = Input.GetAxisRaw("Player1") * moveSpeed * Time.deltaTime;

        //movePlayerOne = new Vector2(dirPlayerOne, 0).normalized;
    }

    void Move()
    {
        transform.Translate(dirPlayerOne, 0, 0);
        //rb.velocity = new Vector2(movePlayerOne.x * moveSpeed, 0);
    }
}
