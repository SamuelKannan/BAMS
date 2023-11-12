using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
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
        dirPlayerX = Input.GetAxisRaw("Player2_Horizontal");
        dirPlayerY = Input.GetAxisRaw("Player2_Vertical");
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
            Debug.Log("Player2 Time Elapsed: " + timeElasped);
            if (timeElasped <= 0.0f)
            {
                isReady = true;
                playerAttack.text = "Push = Ready";
                timeElasped = targetTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
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
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            inContact = false;
            //Debug.Log("OntriggerExit2D");
            //Debug.Log("Collision.tag: " + collision.tag + "inContact: " + inContact);
        }
        
    }

    void Attack()
    {
         if (Input.GetKeyDown("t") && inContact == true && isReady == true)
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
