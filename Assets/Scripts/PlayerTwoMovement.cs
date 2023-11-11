using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerTwoAttack;
    [SerializeField] float targetTime = 7.0f;
    Rigidbody2D pushedBody;
    public Rigidbody2D rb;
    public float moveSpeed;
    public float force;
    

    private Vector2 movePlayerTwo;
    private Vector2 pushDir;
    private Vector3 attackDir;
    private float dirPlayerTwoX;
    private float dirPlayerTwoY;
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
        dirPlayerTwoX = Input.GetAxisRaw("Player2_Horizontal");
        dirPlayerTwoY = Input.GetAxisRaw("Player2_Vertical");
        movePlayerTwo = new Vector2(dirPlayerTwoX, dirPlayerTwoY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(movePlayerTwo.x, movePlayerTwo.y) * moveSpeed * Time.deltaTime;
    }

    void Timer()
    {
        if (isReady == false)
        {
            timeElasped -= Time.deltaTime;
            Debug.Log("Time Elapsed: " + timeElasped);
            if (timeElasped <= 0.0f)
            {
                isReady = true;
                playerTwoAttack.text = "Push = Ready";
                timeElasped = targetTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1" || collision.tag == "Player3" || collision.tag == "Player4")
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
        if (collision.tag == "Player1" || collision.tag == "Player3" || collision.tag == "Player4")
        {
            inContact = false;
            //Debug.Log("OntriggerExit2D");
            //Debug.Log("Collision.tag: " + collision.tag + "inContact: " + inContact);
        }
        
    }

    void Attack()
    {
         if (Input.GetKeyDown("r") && inContact == true && isReady == true)
         {
            pushDir = attackDir.normalized * force;
            pushedBody.AddRelativeForce(pushDir, ForceMode2D.Force);
            isReady = false;
            playerTwoAttack.text = "Push = Recharging";
            //Debug.Log("Attack");
            //Debug.Log("inContact: " + inContact);

         }
    }



}
