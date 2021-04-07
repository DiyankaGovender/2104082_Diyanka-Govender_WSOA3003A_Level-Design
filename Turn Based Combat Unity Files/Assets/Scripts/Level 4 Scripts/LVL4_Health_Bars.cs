using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL4_Health_Bars : MonoBehaviour
{
    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    public Image playerImg;

    public Image enemyImg;

    public float eCurrentHealth;
    public float eMaxHealth = 20f;

    public float pCurrentHealth;
    public float pMaxHealth = 20f;

    public LVL4_Player_Controller LVL4_player_Controller;
    public LVL4_Enemy_AI LVL4_enemy_AI;

    void Start()
    {
        enemyImg.GetComponent<Image>();
        playerImg.GetComponent<Image>();
    }


    void Update()
    {
        eCurrentHealth = LVL4_enemy_AI.enemyCurrentHealth;
        enemyImg.fillAmount = eCurrentHealth / eMaxHealth;

        pCurrentHealth = LVL4_player_Controller.playerCurrentHealth;
        playerImg.fillAmount = pCurrentHealth / pMaxHealth;
    }
}
