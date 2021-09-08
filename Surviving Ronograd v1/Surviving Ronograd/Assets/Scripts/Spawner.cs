using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int enemies = 0;
    public int supplies = 0;

    public GameObject supplyPrefab;

    public Transform sup1;
    public Transform sup2;
    public Transform sup3;

    float supplyTime;
    bool startSupplyTimer;
    static bool respawnEnemy = false;

    public float supplyRespawnTime;
    public bool respawn = true;

    public GameManager gm;

    void Start()
    {
        GameObject supply = Instantiate(supplyPrefab, sup1) as GameObject;
        GameObject supply2 = Instantiate(supplyPrefab, sup2) as GameObject;
        GameObject supply3 = Instantiate(supplyPrefab, sup3) as GameObject;
        supplies = 3;
    }

    void Update()
    {
        SupplyTimer();
        RespawnDrone();

        if (respawnEnemy == true)
        {

        }
    }

    void RespawnDrone()
    {
        if (gm.drones <= 0)
        {
            respawn = false;
        }
    }

    void SupplyTimer()
    {
        if (supplies < 3)
        {
            startSupplyTimer = true;
        }

        if (supplyTime > supplyRespawnTime)
        {
            SpawnRandomSupply();
            startSupplyTimer = false;
        }

        if (startSupplyTimer == true)
        {
            supplyTime += Time.deltaTime;
        } else if (startSupplyTimer == false)
        {
            supplyTime = 0f;
        }
    }

    void SpawnRandomSupply()
    {
        int random = Random.Range(0,3);
        Debug.Log("spawn");
        if (random == 0)
        {
            Debug.Log("at " + random);
            GameObject supply = Instantiate(supplyPrefab, sup1) as GameObject;
            supplies += 1;
        }
        if (random == 1)
        {
            Debug.Log("at " + random);
            GameObject supply2 = Instantiate(supplyPrefab, sup2) as GameObject;
            supplies += 1;
        }
        if (random == 2)
        {
            Debug.Log("at " + random);
            GameObject supply3 = Instantiate(supplyPrefab, sup3) as GameObject;
            supplies += 1;
        }
    }
}


