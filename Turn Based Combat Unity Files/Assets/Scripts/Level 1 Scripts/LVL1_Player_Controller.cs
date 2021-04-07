using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1_Player_Controller : MonoBehaviour
{
    public LVL1_Enemy_RNG LVL1_enemy_RNG;
    public LVL1_Player_RNG LVL1_player_RNG;

    public int playerCurrentHealth;
    public int playerMaxHealth;

    public int playerHealed = 0;



    public int enemyDamageGiven;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void playerTakenDamage()
    {
        enemyDamageGiven = LVL1_enemy_RNG.enemyAttackHealStatNumber;
        playerCurrentHealth = playerCurrentHealth - enemyDamageGiven;
        // Debug.Log("player " + playerCurrentHealth);
    }

    public void playerHealedUp()
    {
        playerCurrentHealth = playerCurrentHealth + playerHealed;
        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }
}
