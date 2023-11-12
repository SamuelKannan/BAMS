using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerFourMovement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerAttack;
    [SerializeField] float targetTime = 7.0f;
    Rigidbody2D pushedBody;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float force;


    private Vector2 movePlayer;
    private Vector2 pushDir;
    private Vector3 attackDir;
    private float dirPlayerX;
    private float dirPlayerY;
    private float timeElasped;
    private bool inContact = false;
    private bool isReady = true;


    void Start()
    {
        timeElasped = targetTime;
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Attack();
        Timer();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        dirPlayerX = Input.GetAxisRaw("Player4_Horizontal");
        dirPlayerY = Input.GetAxisRaw("Player4_Vertical");
        movePlayer = new Vector2(dirPlayerX, dirPlayerY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(movePlayer.x, movePlayer.y) * moveSpeed * Time.deltaTime;
    }

    void Timer()
    {
        if (isReady == false)
        {
            timeElasped -= Time.deltaTime;
            Debug.Log("Player4 Time Elapsed: " + timeElasped);
            if (timeElasped <= 0.0f)
            {
                isReady = true;
                playerAttack.text = "Push = Ready";
                timeElasped = targetTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player3")
        {
            pushedBody = collision.GetComponent<Rigidbody2D>();
            attackDir = collision.transform.position - transform.position;
            inContact = true;
            //Debug.Log("OntriggerEnter2D");
            //Debug.Log("Collision.tag: " + collision.tag + "inContact: " + inContact);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player2" || collision.tag == "Player3")
        {
            inContact = false;
            //Debug.Log("OntriggerExit2D");
            //Debug.Log("Collision.tag: " + collision.tag + "inContact: " + inContact);
        }

    }

    void Attack()
    {
        if (Input.GetKeyDown("/") && inContact == true && isReady == true)
        {
            pushDir = attackDir.normalized * force;
            pushedBody.AddRelativeForce(pushDir, ForceMode2D.Force);
            isReady = false;
            playerAttack.text = "Push = Recharging";
            //Debug.Log("Attack");
            //Debug.Log("inContact: " + inContact);

        }
    }
}
