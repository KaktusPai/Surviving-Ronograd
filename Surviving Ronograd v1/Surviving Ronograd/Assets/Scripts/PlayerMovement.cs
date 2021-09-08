using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform playerpos;
    public GameObject player;
    public Vector2 movement;

    public bool isControlling = false;
    public GameObject conpop;
    public GameObject cam;
    public GameObject camDrone;
    bool canSwitch = false;

    void Start()
    {
        conpop.gameObject.SetActive(false);
        camDrone.SetActive(false);
    }

    void Update()
    {
        if (canSwitch == true)
        {
            DroneSwitch();
        }
    }

    void FixedUpdate()
    {
        if (isControlling == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Console")
        {
            canSwitch = true;
            conpop.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Console")
        {
            canSwitch = false;
            conpop.gameObject.SetActive(false);
        }
    }

    void DroneSwitch()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isControlling = !isControlling;
        }

        if (isControlling == true)
        {
            camDrone.SetActive(true);
        } else if (isControlling == false) {
            camDrone.SetActive(false);
        }
    }
}
