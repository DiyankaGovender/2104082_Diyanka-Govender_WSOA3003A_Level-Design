using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1_Enemy_AI : MonoBehaviour
{
    //Need to make this a random variable
    public LVL1_Enemy_RNG LVL1_enemy_RNG;


    public int enemyCurrentHealth;
    public int enemyMaxHealth;

    //THIS WILL BE A CARD DRAFTED NUMBER 
    public int playerDamageAttackGiven = 5;

    //THIS WILL BE A RANDOM NUMBER 
    public int enemyHealed;


    public void Start()
    {
        enemyMaxHealth = 10;
        enemyCurrentHealth = 10;
    }
    public void enemyTakenDamage()
    {
        enemyCurrentHealth = enemyCurrentHealth - playerDamageAttackGiven;
        //Debug.Log("enemy" + enemyCurrentHealth);
    }

    public void enemyHealedUp()
    {
        enemyHealed = LVL1_enemy_RNG.enemyAttackHealStatNumber;
        enemyCurrentHealth = enemyCurrentHealth + enemyHealed;
        if (enemyCurrentHealth > enemyMaxHealth)
        {
            enemyCurrentHealth = enemyMaxHealth;
        }
    }
}
