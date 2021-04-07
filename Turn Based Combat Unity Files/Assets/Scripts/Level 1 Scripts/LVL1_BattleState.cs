using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum LVL1_GameState
{
    gameStart,


    battleSetup,

    playerTurn,
    enemyTurn,

    playerWins,
    playerLost,


}


public class LVL1_BattleState : MonoBehaviour
{
    public Animator playerAnim;
    public Animator enemyAnim;

    //public GameObject healthImg;
    public GameObject swordImg;
    public AudioSource click;
    public AudioSource damage;
    public AudioSource heal;
    public AudioSource happy;
    public AudioSource sad;

    public GameState gameState;

    public GameObject square;
    public GameObject square2;

    public Slider enemySlider;
    public Slider playerSlider;


    //MAKE SURE THE SCRIPTS MATCH
    public LVL1_Enemy_AI LVL1_enemy_AI;
    public LVL1_Player_Controller LVL1_player_Controller;
    public LVL1_Enemy_RNG LVL1_enemy_RNG;
    public LVL1_Player_RNG LVL1_player_RNG;


    //PLAYER AND ENEMY SPRITES
    public GameObject player;
    public GameObject enemy;

    //MAIN TEXT BOX AND OTHER TEXT BOX
    public TextMeshProUGUI maintextBox;
    public TextMeshProUGUI pickNumber;

    //ENEMY AND PLAYER HEALTH
    public TextMeshProUGUI playerUI;
    public TextMeshProUGUI playerUI2;
    public TextMeshProUGUI enemyUI;
    public TextMeshProUGUI enemyUI2;

    //BUTTONS
    public GameObject startButton;


    public GameObject playerAttackButton;
    //public GameObject playerHealButton;

    void Start()
    {

        //Debug.Log("Start State"); 

        gameState = GameState.gameStart;

        square.SetActive(false);
        player.SetActive(false);
        playerUI.enabled = false;
        playerUI2.enabled = false;

        enemy.SetActive(false);
        enemyUI.enabled = false;
        enemyUI2.enabled = false;


        maintextBox.enabled = false;
        pickNumber.enabled = false;

        startButton.SetActive(true);

        playerAttackButton.SetActive(false);
        //playerHealButton.SetActive(false);

        enemySlider.gameObject.SetActive(false);
        playerSlider.gameObject.SetActive(false);

        square2.SetActive(false);

        //healthImg.GetComponent<SpriteRenderer>().enabled = false;
        swordImg.GetComponent<SpriteRenderer>().enabled = false;
    }


    public void onStartButtonState()
    {
        if (gameState == GameState.gameStart)
        {
            //Debug.Log("Ended Start State");

            startButton.SetActive(false);
            gameState = GameState.battleSetup;
            square.SetActive(true);
            battleSetupState();

        }

    }



    public void battleSetupState()
    {
        //Debug.Log("Battle setup");


        enemySlider.gameObject.SetActive(true);
        playerSlider.gameObject.SetActive(true);
        square2.SetActive(true);

        player.SetActive(true);
        playerUI.enabled = true;
        playerUI2.enabled = true;

        enemy.SetActive(true);
        enemyUI.enabled = true;
        enemyUI2.enabled = true;

        maintextBox.enabled = true;


        maintextBox.text = "It's " + "<b><color=#0000ffff> YOUR TURN</color></b>" + ", pick a" + "<b> CARD</b>";

        pickNumber.enabled = true;

        gameState = GameState.playerTurn;
        StartCoroutine(playerTurnState());


        //PLAYER RNG START
        LVL1_player_RNG.activateRNG();
        LVL1_player_RNG.activateNumber();

    }

    //PLAYER TURN STATE
    IEnumerator playerTurnState()
    {
        yield return new WaitForSeconds(1.4f);
        maintextBox.text = "It's " + "<b><color=#0000ffff> YOUR TURN</color></b>" + ", pick a" + "<b> CARD</b>";

        pickNumber.enabled = true;

        yield return new WaitForSeconds(4f);
        pickNumber.enabled = false;
        yield return new WaitForSeconds(1f);
        maintextBox.text = "What do" + "<color=#0000ffff><b> YOU</b></color>" + " want to" + "<b> DO</b>?";
        playerAttackButton.SetActive(true);
        //playerHealButton.SetActive(true);

        //healthImg.GetComponent<SpriteRenderer>().enabled = true;
        swordImg.GetComponent<SpriteRenderer>().enabled = true;

        //Debug.Log("Player Turn");



    }


    //PLAYER ATTACK
    public void onPlayerAttackButton()
    {
        click.Play();
        if (gameState != GameState.playerTurn)
            return;
        else StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(2);

        //Debug.Log("Player Attacks");

        //UI UPDATED 
        maintextBox.richText = enabled;
        maintextBox.text = "<color=#0000ffff><b>PLAYER</b></color>" + "<b> ATTACKS!</b>";


        yield return new WaitForSeconds(2);

        //ENEMY DAMAGED 
        LVL1_enemy_AI.enemyTakenDamage();

        //UI UPDATED
        maintextBox.text = "<color=#ff0000ff><b>ENEMY</b></color>" + " has taken " + "<b>" + LVL1_enemy_AI.playerDamageAttackGiven.ToString() + "</b>" + "<b>HP</b>" + " DAMAGE!";
        enemyUI.text = LVL1_enemy_AI.enemyCurrentHealth + "/" + LVL1_enemy_AI.enemyMaxHealth;
        damage.Play();
        enemyAnim.Play("Enemy_Damages");

        //HAS ENEMY BEEN KILLED?
        if (LVL1_enemy_AI.enemyCurrentHealth <= 0)
        {
            //Debug.Log("Dead enemy");
            LVL1_enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            Debug.Log("Enemy Turn State");

            gameState = GameState.enemyTurn;
            StartCoroutine(enemyTurnState());

            //enemy_RNG.generateRNGAttackHealStateNumber();
            //enemy_RNG.generateEnemyCardPosition();
            //enemy_RNG.generateEnemyAttackHealStatNumber();
        }

    }



    //PLAYER HEAL
   // public void onPlayerHealButton()
    //{
      //  click.Play();
        //if (gameState != GameState.playerTurn)
          //  return;
        //else StartCoroutine(PlayerHeal());
    //}


    //IEnumerator PlayerHeal()
    //{
      //  yield return new WaitForSeconds(2);

        //Debug.Log("Player Heals");

        //UI UPDATED 
        //maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + "<b> HEALS!</b>";

        //yield return new WaitForSeconds(2);

        //PLAYER HEALED
        //LVL1_player_Controller.playerHealedUp();

        //UI UPDATED
        //maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + " has" + "<b> HEALED</b>" + " by " + "<b>" + LVL1_player_Controller.playerHealed.ToString() + "</b>" + "<b> HP!</b>";
        //playerUI.text = LVL1_player_Controller.playerCurrentHealth + "/" + LVL1_player_Controller.playerMaxHealth;
        //heal.Play();
        //playerAnim.Play("Player_Heals");

        //HAS ENEMY BEEN KILLED?
        //if (LVL1_enemy_AI.enemyCurrentHealth <= 0)
        //{
            //Debug.Log("Dead enemy");
          //  LVL1_enemy_AI.enemyCurrentHealth = 0;
            //gameState = GameState.playerWins;
            //endState();
       // }
        //else
        //{
            //Debug.Log("Enemy Turn State");

          //  gameState = GameState.enemyTurn;
            //StartCoroutine(enemyTurnState());

            //enemy_RNG.generateRNGAttackHealStateNumber();
            //enemy_RNG.generateEnemyCardPosition();
            //enemy_RNG.generateEnemyAttackHealStatNumber();

    //    }

    //}



    //ENEMY TURN STATE 
    IEnumerator enemyTurnState()
    {
        LVL1_enemy_RNG.generateRNGAttackHealStateNumber();
        LVL1_enemy_RNG.generateEnemyCardPosition();
        LVL1_enemy_RNG.generateEnemyAttackHealStatNumber();


        //PLAYER BUTTONS DISABLED
        playerAttackButton.SetActive(false);
        //playerHealButton.SetActive(false);

        //healthImg.GetComponent<SpriteRenderer>().enabled = false;
        swordImg.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(2);
        maintextBox.text = "It's the" + "<b><color=#ff0000ff> ENEMY'S TURN</color></b>";

        yield return new WaitForSeconds(2);

        //ENEMY ATTACK
        if (LVL1_enemy_RNG.enemyRNGAttackHealStateNumber == 1)
        {
            LVL1_enemy_RNG.generateEnemyAttackHealStatNumber();
            //UI UPDATED
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> ATTACKS!</b>";
            Debug.Log("Enemy Attacks");


            yield return new WaitForSeconds(2);
            //PLAYER DAMAGED 
            LVL1_player_Controller.playerTakenDamage();

            //UI UPDATED 
            maintextBox.text = "<b><color=#0000ffff>PLAYER </color></b>" + " has taken " + "<b>" + LVL1_player_Controller.enemyDamageGiven + "HP DAMAGE!" + "</b>";
            playerUI.text = LVL1_player_Controller.playerCurrentHealth + "/" + LVL1_player_Controller.playerMaxHealth;
            damage.Play();
            playerAnim.Play("Player_Damages");

            //IS PLAYER DEAD?
            if (LVL1_player_Controller.playerCurrentHealth <= 0)
            {
                LVL1_player_Controller.playerCurrentHealth = 0;
                //Debug.Log("Player Dead");
                gameState = GameState.playerLost;
                endState();
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                gameState = GameState.playerTurn;
                StartCoroutine(playerTurnState());
            }




        }
        //ENEMY HEALS
        if (LVL1_enemy_RNG.enemyRNGAttackHealStateNumber == 2)
        {
            LVL1_enemy_RNG.generateEnemyAttackHealStatNumber();
            //UI UPDATED
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> ATTACKS!</b>";
            Debug.Log("Enemy Attacks");


            yield return new WaitForSeconds(2);
            //PLAYER DAMAGED 
            LVL1_player_Controller.playerTakenDamage();

            //UI UPDATED 
            maintextBox.text = "<b><color=#0000ffff>PLAYER </color></b>" + " has taken " + "<b>" + LVL1_player_Controller.enemyDamageGiven + "HP DAMAGE!" + "</b>";
            playerUI.text = LVL1_player_Controller.playerCurrentHealth + "/" + LVL1_player_Controller.playerMaxHealth;
            damage.Play();
            playerAnim.Play("Player_Damages");

            //IS PLAYER DEAD?
            if (LVL1_player_Controller.playerCurrentHealth <= 0)
            {
                LVL1_player_Controller.playerCurrentHealth = 0;
                //Debug.Log("Player Dead");
                gameState = GameState.playerLost;
                endState();
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                gameState = GameState.playerTurn;
                StartCoroutine(playerTurnState());
            }
        }


    }

    void endState()
    {
        //Debug.Log("end");
        if (gameState == GameState.playerWins)
        {
            happy.Play();
            maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + "<b> WINS!</b>";

            playerAttackButton.SetActive(false);
            //playerHealButton.SetActive(false);

            //healthImg.GetComponent<SpriteRenderer>().enabled = false;
            swordImg.GetComponent<SpriteRenderer>().enabled = false;
        }

        //Debug.Log("end");
        if (gameState == GameState.playerLost)
        {
            sad.Play();
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> WINS!</b>";

            playerAttackButton.SetActive(false);
            //playerHealButton.SetActive(false);

            //healthImg.GetComponent<SpriteRenderer>().enabled = false;
            swordImg.GetComponent<SpriteRenderer>().enabled = false;
        }

    }


}
