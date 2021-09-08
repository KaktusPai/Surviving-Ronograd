using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Transform playerpos;
    public GameObject player;
    public Transform spawn;
    public Vector2 movement;
    public PlayerMovement pm;
    public GameManager gm;
    public Spawner s;

    void FixedUpdate()
    {
        if (pm.isControlling == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sup")
        {
            gm.supplies += 10;
            gm.energy += 10;
            Destroy(other.gameObject);
            s.supplies -= 1;
        }

        if (other.gameObject.tag == "Enemy")
        {
            gm.drones -= 1;
            if (s.respawn == true)
            {
                transform.position = spawn.position;
            }
            else if (s.respawn == false)
            {
                Destroy(this.gameObject);
                gm.Dead();
            }
        }
    }
}
