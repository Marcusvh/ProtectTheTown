using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

public class EnemyWarrior : EnemyMeleeBehavior
{
    private int maxHealth = 30;
    private int currentHealth;
    
    public string enemyName = "WarriorName";
    //private string classType = "Warrior";

    public bool ayayaa = true;
    
    private int baseDmg = 5;
    private float cooldown = 1.5f;
    private float lastAttacked;

    private Animator animator;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
        movingSpeed = 0.3f;

        animator = GetComponent<Animator>();
    }

    public virtual int DamageDealt(int hp)
    {
        if (Time.time - lastAttacked > cooldown)
        {
            lastAttacked = Time.time;
            int totalDamage = baseDmg; // more to come, eg. weapon    
            return totalDamage;
        }
        return 0;
    }

    public virtual void DamageTaken(int dmg)
    {
        if (dmg < 0)
            dmg = 0;

        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        // TODO: dont use sleep and play the death animation
        Debug.Log($"Warrior: {enemyName} is dead");

        animator.SetTrigger("Death");

        // drop loot?
    }
}
