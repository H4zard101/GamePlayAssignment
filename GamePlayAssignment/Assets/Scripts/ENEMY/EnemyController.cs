 using System;
 using System.Collections;
using System.Collections.Generic;
 using Attempt_2;
 using Attempt_2.Player;
 using Export_Package.Attempt_2;
 using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public bool playerInRange = false;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;
    public float AttackDistance = 4.5f;
    
    public bool takeDamage;
    public bool dealDamage;
    public float damageTimer;
    public float enemyHealth = 100;

    private Material enemyMat;

    public GameObject smallerEnemy;

    public bool spawnSmallerEnemies;
    public int count = 0;
    
    Transform target;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        enemyMat = GetComponent<Renderer>().material;
        enemyMat.color = Color.white;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance < AttackDistance)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }
        }

        if (takeDamage)
        {
            StartCoroutine(TakeDamageCoroutine());
            takeDamage = false;
        }

        if (enemyHealth <= 0 && count < 2)
        {
            if (count == 1)
            {
                Destroy(gameObject);
            }
            count++;
            if (spawnSmallerEnemies)
            {
                Instantiate(smallerEnemy, transform.position, transform.rotation);
            }

            Debug.Log("Enemy dead");
        }
        
    }

    private void FixedUpdate()
    {
        
        if (playerInRange)
        {
            damageTimer += Time.fixedDeltaTime;
            if (damageTimer > 3)
            {
                //Debug.Log(damageTimer);
                target.GetComponent<PlayerMovement2>().playerHealth -= 10;
                target.GetComponent<PlayerMovement2>().takeDamage = true;
                damageTimer = 0;
            }
        }
        else
        {
            damageTimer = 0;
        }
    }

    IEnumerator TakeDamageCoroutine()
    {
        Debug.Log("Enemy ouch");
        enemyMat.color = Color.red;
        yield return new WaitForSeconds(.5f);
        enemyMat.color = Color.white;
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackDistance);
    }
}
