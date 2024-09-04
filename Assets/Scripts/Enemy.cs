using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;
    [SerializeField] Transform target;
    [SerializeField] private float chaseRange;
    [SerializeField] public int damage = 10;

    private float attackCooldown = 2f;
    private float lastAttackTime;

    // Start is called before the first frame update
   void Start() //we will need this set as "protected virtual" to ensure we can initialize our child class correctly
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DisplayEnemyStats();
    }

    private void DisplayEnemyStats()
    {
        Debug.Log($"{enemyName} has {healthPoint} HP and can move at a speed of {moveSpeed}");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, target.position) < chaseRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer() //method needs to be virtual to allow overriding
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log($"{enemyName} is attacking the player for {damage} damage!");
            lastAttackTime = Time.time;
        }
    }
}
