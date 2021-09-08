using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.15f;
    public Transform player;
    public Transform bunker;
    public Transform espawn;
    public Spawner s;
    public float attackDistance = 5;
    public float dist;

    void Start()
    {
       
    }

    void Update()
    {
        dist = Vector2.Distance(transform.position, player.position);

        float distFromBunker = Vector2.Distance(transform.position, bunker.position);

        if (dist <= attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            Debug.Log(dist);
        } else
        {
            transform.position = transform.position;
        }

        if (distFromBunker <= 0.5)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = espawn.position;
    }
}
