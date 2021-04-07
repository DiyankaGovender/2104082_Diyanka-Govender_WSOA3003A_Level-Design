using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3_Enemy_AI : MonoBehaviour
{
    //Need to make this a random variable
    public LVL3_Enemy_RNG LVL3_enemy_RNG;


    public int enemyCurrentHealth;
    public int enemyMaxHealth;

    //THIS WILL BE A CARD DRAFTED NUMBER 
    public int playerDamageAttackGiven = 5;

    //THIS WILL BE A RANDOM NUMBER 
    public int enemyHealed;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void enemyTakenDamage()
    {
        enemyCurrentHealth = enemyCurrentHealth - playerDamageAttackGiven;
        //Debug.Log("enemy" + enemyCurrentHealth);
    }

    public void enemyHealedUp()
    {
        enemyHealed = LVL3_enemy_RNG.enemyAttackHealStatNumber;
        enemyCurrentHealth = enemyCurrentHealth + enemyHealed;
        if (enemyCurrentHealth > enemyMaxHealth)
        {
            enemyCurrentHealth = enemyMaxHealth;
        }
    }
}
