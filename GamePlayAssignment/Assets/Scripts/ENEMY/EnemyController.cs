 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public static bool playerInRange = false;
    public static float attackRate = 2f;
    public static float nextAttackTime = 0f;
    public float AttackDistance = 4.5f;
    
    public bool takeDamage;
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
        target = PlayerManager.instance.player.transform;
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
        }

        if (takeDamage)
        {
            StartCoroutine(takeDamageCoroutine());
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
            
             
            Debug.Log("dead");
        }
    }
    
    IEnumerator takeDamageCoroutine()
    {
        Debug.Log("ouch");
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
