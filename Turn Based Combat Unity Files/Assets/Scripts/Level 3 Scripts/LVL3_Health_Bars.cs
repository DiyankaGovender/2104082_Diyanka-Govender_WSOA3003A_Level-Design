using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL3_Health_Bars : MonoBehaviour
{
    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    public Image playerImg;

    public Image enemyImg;

    public float eCurrentHealth;
    public float eMaxHealth = 20f;

    public float pCurrentHealth;
    public float pMaxHealth = 20f;

    public LVL3_Player_Controller LVL3_player_Controller;
    public LVL3_Enemy_AI LVL3_enemy_AI;

    void Start()
    {
        enemyImg.GetComponent<Image>();
        playerImg.GetComponent<Image>();
    }


    void Update()
    {
        eCurrentHealth = LVL3_enemy_AI.enemyCurrentHealth;
        enemyImg.fillAmount = eCurrentHealth / eMaxHealth;

        pCurrentHealth = LVL3_player_Controller.playerCurrentHealth;
        playerImg.fillAmount = pCurrentHealth / pMaxHealth;
    }
}
