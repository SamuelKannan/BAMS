using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerAttack;
    [SerializeField] float targetTime = 7.0f;
    //[SerializeField] Sprite[] spriteList;
    AudioSource source;
    Rigidbody2D pushedBody;
    SpriteRenderer sprite;
    Rigidbody2D rb;
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
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
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
        dirPlayerX = Input.GetAxisRaw("Player1_Horizontal");
        dirPlayerY = Input.GetAxisRaw("Player1_Vertical");
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
            Debug.Log("Player1 Time Elapsed: " + timeElasped);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            pushedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            attackDir = collision.transform.position - transform.position;
            inContact = true;
            //Debug.Log("OntriggerEnter2D");
            //Debug.Log("Collision.tag: " + collision.tag + "inContact: " + inContact);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            inContact = false;
            //Debug.Log("OntriggerExit2D");
            //Debug.Log("Collision.tag: " + collision.tag + "inContact: " + inContact);
        }

    }

    void Attack()
    {
        if (Input.GetKeyDown("q") && inContact == true && isReady == true)
        {
            pushDir = attackDir.normalized * force;
            pushedBody.AddRelativeForce(pushDir, ForceMode2D.Force);
            source.Play();
            isReady = false;
            playerAttack.text = "Push = Recharging";
            //Debug.Log("Attack");
            //Debug.Log("inContact: " + inContact);

        }
    }

}
