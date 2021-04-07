using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL1_Health_Bars : MonoBehaviour
{
    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    public Image playerImg;

    public Image enemyImg;

    public float eCurrentHealth;
    public float eMaxHealth = 10f;

    public float pCurrentHealth;
    public float pMaxHealth = 10f;

    public LVL1_Player_Controller LVL1_player_Controller;
    public LVL1_Enemy_AI LVL1_enemy_AI;

    void Start()
    {
        enemyImg.GetComponent<Image>();
        playerImg.GetComponent<Image>();
      
    }

    
    void Update()
    {
        eCurrentHealth = LVL1_enemy_AI.enemyCurrentHealth;
        enemyImg.fillAmount = eCurrentHealth / eMaxHealth;

        pCurrentHealth = LVL1_player_Controller.playerCurrentHealth;
        playerImg.fillAmount = pCurrentHealth / pMaxHealth;
    }
}
