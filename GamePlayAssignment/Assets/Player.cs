using System.Collections;
using System.Collections.Generic;
using Attempt_2.Player;
using Export_Package.Attempt_2;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static int maxHealth = 100;
    public static int currentHealth;
    public int enemyAttackDamage = 10;

    public healthBar healthBar;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        healthBar.SetHealth(player.GetComponent<PlayerMovement2>().playerHealth);

        /*if (player.GetComponent<PlayerMovement2>().playerHealth <= 0)
        {
            //playerIsDead = true;
            Debug.Log("player is dead");
        }*/
        
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamge(20);
        }*/
        /*if (EnemyController.playerInRange == true)
        {
            if (Time.time >= EnemyController.nextAttackTime)
            {
                TakeDamge(enemyAttackDamage);
                EnemyController.playerInRange = false;
                EnemyController.nextAttackTime = Time.time + 2f / EnemyController.attackRate;
            }
        }*/
    }

    /*void TakeDamge(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //playerIsDead = true;
            Debug.Log("player is dead");
        }
    }*/


}
