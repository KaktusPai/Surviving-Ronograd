using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxGameTime = 180;
    public int supplies = 100;
    public int energy = 100;
    public int drones = 5;
    public Slider timerSlider;
    public Text sup;
    public Text nrg;
    public Text drn;
    public GameObject alien;
    public float alienAttackSpeed = 4f;
    public Transform endPos;
    public float gameTime;
    public bool attacking = false;

    private void Start()
    {
        gameTime = maxGameTime;
        timerSlider.maxValue = maxGameTime;
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            Win();
        }
        timerSlider.value = gameTime;

        sup.text = "Supplies: " + supplies + "%";
        nrg.text = "Energy: " + energy + "%";
        drn.text = "Drones: " + drones;

        AutoDeplete();
        gameOverWhen();
        AlienAttack();
    }

    float time1;
    float time2;

    void AutoDeplete()
    {
        time1 += Time.deltaTime;
        time2 += Time.deltaTime;

        if (time1 > 3)
        {
            supplies -= 5;
            time1 = 0;
        }

        if (time2 > 6)
        {
            energy -= 5;
            time2 = 0;
        }
    }

    void gameOverWhen()
    {
        if (drones <= 0)
        {
            Dead();
        }
    }

    public void AlienAttack()
    {
        if (attacking == true)
        {
            Vector2.MoveTowards(transform.position, endPos.position, alienAttackSpeed * Time.deltaTime);

            if (alien.transform.position.y >= -2)
            {
                energy -= 10;
                supplies -= 20;
            }

        } else if (attacking == false)
        {
            alien.transform.position = new Vector2(3.5f, -7f);
        }
    }

    
    public void Menu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Game()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    
    public void Dead()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    public void Win()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
} 

