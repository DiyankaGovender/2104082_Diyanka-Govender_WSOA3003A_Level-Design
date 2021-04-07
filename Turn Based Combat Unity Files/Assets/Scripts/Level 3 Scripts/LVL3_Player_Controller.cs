using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3_Player_Controller : MonoBehaviour
{
    public LVL3_Enemy_RNG LVL3_enemy_RNG;
    public LVL3_Player_RNG LVL3_player_RNG;

    public int playerCurrentHealth;
    public int playerMaxHealth;

    public int playerHealed = 0;

    //THIS WILL BE A RANDOMLY GENERATED NUMBER 
    public int enemyDamageGiven;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playerTakenDamage()
    {
        enemyDamageGiven = LVL3_enemy_RNG.enemyAttackHealStatNumber;
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
