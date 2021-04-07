using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL1_Enemy_RNG : MonoBehaviour
{
    public LVL1_Player_RNG LVL1_player_RNG;
    public LVL1_BattleState LVL1_battleState;

    public int enemyRNGAttackHealStateNumber;
    
    public int enemyCardPosition;
    public int enemyAttackHealStatNumber;

    void Start()
    {
        enemyRNGAttackHealStateNumber = 1;
    }

    void Update()
    {
        if
      (LVL1_player_RNG.button1.GetComponent<Button>().interactable == false &&
       LVL1_player_RNG.button2.GetComponent<Button>().interactable == false &&
       LVL1_player_RNG.button3.GetComponent<Button>().interactable == false &&
       LVL1_player_RNG.button4.GetComponent<Button>().interactable == false &&
       LVL1_player_RNG.button5.GetComponent<Button>().interactable == false &&
       LVL1_player_RNG.button6.GetComponent<Button>().interactable == false &&
       LVL1_battleState.gameState == GameState.enemyTurn)
        {
            Debug.Log("FALSE");
            LVL1_player_RNG.randomiseNumbers();
        }
    }

    public void generateRNGAttackHealStateNumber()
    {

        enemyRNGAttackHealStateNumber = Random.Range(1, 3);
    }

    public void generateEnemyCardPosition()
    {
        Debug.Log("ENEMY CARD POSITION " + enemyCardPosition);

        enemyCardPosition = Random.Range(1, 7);
        if (enemyCardPosition == 7)
        {
            enemyCardPosition = 6;
        }

        if (enemyCardPosition == 0)
        {
            enemyCardPosition = 1;
        }


    }

    public void generateEnemyAttackHealStatNumber()
    {
        Debug.Log("ENEMY ATTACK/HEAL STAT NUMBER: " + enemyAttackHealStatNumber);
        if (enemyCardPosition == 1)
        {


            if (LVL1_player_RNG.button1.GetComponent<Button>().interactable == true)
            {
                LVL1_player_RNG.button1.GetComponent<Button>().interactable = false;
                LVL1_player_RNG.button1.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);


                enemyAttackHealStatNumber = LVL1_player_RNG.randomNumber1;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 2)
        {
            if (LVL1_player_RNG.button2.GetComponent<Button>().interactable == true)
            {
                LVL1_player_RNG.button2.GetComponent<Button>().interactable = false;
                LVL1_player_RNG.button2.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = LVL1_player_RNG.randomNumber2;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 3)
        {
            if (LVL1_player_RNG.button3.GetComponent<Button>().interactable == true)
            {
                LVL1_player_RNG.button3.GetComponent<Button>().interactable = false;
                LVL1_player_RNG.button3.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = LVL1_player_RNG.randomNumber3;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 4)
        {
            if (LVL1_player_RNG.button4.GetComponent<Button>().interactable == true)
            {
                LVL1_player_RNG.button4.GetComponent<Button>().interactable = false;
                LVL1_player_RNG.button4.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = LVL1_player_RNG.randomNumber4;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }


        else if (enemyCardPosition == 5)
        {
            if (LVL1_player_RNG.button5.GetComponent<Button>().interactable == true)
            {
                LVL1_player_RNG.button5.GetComponent<Button>().interactable = false;
                LVL1_player_RNG.button5.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = LVL1_player_RNG.randomNumber5;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 6)
        {
            if (LVL1_player_RNG.button6.GetComponent<Button>().interactable == true)
            {
                LVL1_player_RNG.button6.GetComponent<Button>().interactable = false;
                LVL1_player_RNG.button6.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = LVL1_player_RNG.randomNumber6;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }


    }

}
