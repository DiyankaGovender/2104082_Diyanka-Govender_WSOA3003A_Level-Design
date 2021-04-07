using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_RNG : MonoBehaviour
{
    public Player_RNG player_RNG;
    public BattleState battleState;

    public int enemyRNGAttackHealStateNumber;

    

    public int enemyCardPosition;
    public int enemyAttackHealStatNumber;


  
    void Start()
    {
        //enemyCardPosition = 1;
        enemyRNGAttackHealStateNumber = 1;

        
    }

    
    void Update()
    {
        if
       (player_RNG.button1.GetComponent<Button>().interactable == false &&
        player_RNG.button2.GetComponent<Button>().interactable == false &&
        player_RNG.button3.GetComponent<Button>().interactable == false &&
        player_RNG.button4.GetComponent<Button>().interactable == false &&
        player_RNG.button5.GetComponent<Button>().interactable == false &&
        player_RNG.button6.GetComponent<Button>().interactable == false &&
        battleState.gameState == GameState.enemyTurn)
        {
            Debug.Log("FALSE");
            player_RNG.randomiseNumbers();
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
            

            if (player_RNG.button1.GetComponent<Button>().interactable == true)
            {
                player_RNG.button1.GetComponent<Button>().interactable = false;
                player_RNG.button1.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);


                enemyAttackHealStatNumber = player_RNG.randomNumber1;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 2)
        {
            if (player_RNG.button2.GetComponent<Button>().interactable == true)
            {
                player_RNG.button2.GetComponent<Button>().interactable = false;
                player_RNG.button2.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = player_RNG.randomNumber2;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 3)
        {
            if (player_RNG.button3.GetComponent<Button>().interactable == true)
            {
                player_RNG.button3.GetComponent<Button>().interactable = false;
                player_RNG.button3.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = player_RNG.randomNumber3;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 4)
        {
            if (player_RNG.button4.GetComponent<Button>().interactable == true)
            {
                player_RNG.button4.GetComponent<Button>().interactable = false;
                player_RNG.button4.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = player_RNG.randomNumber4;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }


        else if (enemyCardPosition == 5)
        {
            if (player_RNG.button5.GetComponent<Button>().interactable == true)
            {
                player_RNG.button5.GetComponent<Button>().interactable = false;
                player_RNG.button5.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = player_RNG.randomNumber5;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }

        else if (enemyCardPosition == 6)
        {
            if (player_RNG.button6.GetComponent<Button>().interactable == true)
            {
                player_RNG.button6.GetComponent<Button>().interactable = false;
                player_RNG.button6.GetComponent<Image>().color = new Color(1, 0.3215686275f, 0.3215686275f);
                enemyAttackHealStatNumber = player_RNG.randomNumber6;
            }

            else
            {
                generateEnemyCardPosition();
                return;
            }
        }


    }

}
