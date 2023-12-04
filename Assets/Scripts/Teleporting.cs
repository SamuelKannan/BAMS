using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    [SerializeField] GameObject teleportOne;
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject teleportTwo;
    [SerializeField] GameObject playerTwo;
    [SerializeField] GameObject teleportThree;
    [SerializeField] GameObject playerThree;
    [SerializeField] GameObject teleportFour;
    [SerializeField] GameObject playerFour;
    [SerializeField] GameObject beachOne;
    [SerializeField] GameObject beachTwo;
    [SerializeField] GameObject beachThree;
    [SerializeField] GameObject beachFour;
    [SerializeField] GameObject camera;

    bool passed = false;
    SpriteRenderer one;
    SpriteRenderer two;
    SpriteRenderer three;
    SpriteRenderer four;
    Collider2D oneCollider;
    Collider2D twoCollider;
    Collider2D threeCollider;
    Collider2D fourCollider;


    Vector3 spaceCamera = new Vector3(0.04f, -2.54f, -10f);
    Vector3 beachCamera = new Vector3(41.61f, -2.6f, -10f);
    Vector3 highwayCamera = new Vector3(79.84f, -2.6f, -10f);

    // Start is called before the first frame update
    void Start()
    {
        one = playerOne.GetComponent<SpriteRenderer>();
        oneCollider = playerOne.GetComponent<BoxCollider2D>();
        two = playerTwo.GetComponent<SpriteRenderer>();
        twoCollider = playerTwo.GetComponent<BoxCollider2D>();
        three = playerThree.GetComponent<SpriteRenderer>();
        threeCollider = playerThree.GetComponent<BoxCollider2D>();
        four = playerFour.GetComponent<SpriteRenderer>();
        fourCollider = playerFour.GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (passed)
        {
            Invoke("Teleport", 2f);
            passed = false;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        teleportOne.SetActive(true);
        teleportTwo.SetActive(true);
        teleportThree.SetActive(true);
        teleportFour.SetActive(true);
        one.enabled = false;
        oneCollider.enabled = false;
        two.enabled = false;
        twoCollider.enabled = false;
        three.enabled = false;
        threeCollider.enabled = false;
        four.enabled = false;
        fourCollider.enabled = false;
        passed = true;
    }

    void Teleport()
    {
        teleportOne.SetActive(false);
        teleportTwo.SetActive(false);
        teleportThree.SetActive(false);
        teleportFour.SetActive(false);
        beachOne.SetActive(true);
        beachTwo.SetActive(true);
        beachThree.SetActive(true);
        beachFour.SetActive(true);

        if (gameObject.tag == "Space")
        {
            camera.transform.position = beachCamera;
            playerOne.transform.position = new Vector3(36f, -5.9f, 0f);
            playerTwo.transform.position = new Vector3(38f, -5.9f, 0f);
            playerThree.transform.position = new Vector3(40.1f, -5.9f, 0f);
            playerFour.transform.position = new Vector3(42.0f, -5.9f, 0f);
        }

        if (gameObject.tag == "Beach")
        {
            camera.transform.position = highwayCamera;
            beachOne.transform.position = new Vector3(74.99f, -5.9f, 0f);
            beachTwo.transform.position = new Vector3(77.74f, -6f, 0f);
            beachThree.transform.position = new Vector3(80.75f, -6f, 0f);
            beachFour.transform.position = new Vector3(84.33f, -6.1f, 0f);
        }


    }
}
