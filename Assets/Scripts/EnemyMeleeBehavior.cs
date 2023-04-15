using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMeleeBehavior : MonoBehaviour
{
    private float detectionRange = 2f;
    private float attackRange = 0.4f;
    private float resetRange = 4f;
    private bool isChasing = false;

    protected float movingSpeed = 0.2f;

    private Transform playerTransform;
    private Vector3 startingTransform;

    private EnemyWarrior enemyWarrior;
    private PlayerBehavior playerBehavior;
    

    protected virtual void Awake()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        startingTransform = transform.position;

        enemyWarrior = GetComponent<EnemyWarrior>();
        
    }

    private void Start()
    {
        playerBehavior = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>();
    }

    public void FixedUpdate()
    {
        Debug.Log("player: " + playerTransform.position);
        Debug.Log("starting: " + startingTransform);
        if(Vector3.Distance(playerTransform.position, startingTransform) < detectionRange)
        {
            Debug.Log("In detection range");
            isChasing = true;
            
            if(isChasing)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, movingSpeed * Time.deltaTime);
                if (Vector3.Distance(playerTransform.position, transform.position) < attackRange)
                {
                    Debug.Log("In attack range");

                    playerBehavior.DamageTaken(enemyWarrior.DamageDealt(playerBehavior.currentHealth));

                    // for debugging enemy death
                    //enemyWarrior.DamageTaken(31);
                }
            }   
        }

        if(Vector3.Distance(startingTransform, transform.position) > resetRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingTransform, movingSpeed * Time.deltaTime);
        }
    }


}
