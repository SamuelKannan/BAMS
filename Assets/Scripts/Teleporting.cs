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
    Vector3 spaceCamera = new Vector3(0.04f, -2.54f, -10f);
    Vector3 beachCamera = new Vector3(41.62f, -2.54f, -10f);
    Vector3 highwayCamera = new Vector3(79.79f, -2.54f, -10f);

    // Start is called before the first frame update
    void Start()
    {
        one = playerOne.GetComponent<SpriteRenderer>();
        two = playerTwo.GetComponent<SpriteRenderer>();
        three = playerThree.GetComponent<SpriteRenderer>();
        four = playerFour.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (passed)
        {
            Invoke("Teleport", 4f);
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
        two.enabled = false;
        three.enabled = false;
        four.enabled = false;
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

        camera.transform.position = beachCamera;
        playerOne.transform.position = new Vector3(34.6f, -7.47f, 0f);
        playerTwo.transform.position = new Vector3(37.1f, -7.47f, 0f);
        playerThree.transform.position = new Vector3(39.6f, -7.47f, 0f);
        playerFour.transform.position = new Vector3(42.1f, -7.47f, 0f);

    }
}
