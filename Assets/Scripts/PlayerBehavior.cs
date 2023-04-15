using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    public float movementSpeed = 0.5f;
    private int baseDamage = 10;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void DamageTaken(int damage)
    {
        Debug.Log("Player HP: " + currentHealth);
        if(damage < 0) 
            damage = 0;

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Player Dead");
        // restart?
    }
}
