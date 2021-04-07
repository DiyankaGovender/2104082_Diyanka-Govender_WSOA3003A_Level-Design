using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LVL4_BattleState : MonoBehaviour
{
    public enum LVL4GameState
    {
        gameStart,


        battleSetup,

        playerTurn,
        enemyTurn,

        playerWins,
        playerLost,


    }

    

    public GameObject playerShield;

    public Animator playerAnim;
    public Animator enemyAnim;



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

    public LVL4_Enemy_AI LVL4_enemy_AI;
    public LVL4_Player_Controller LVL4_player_Controller;
    public LVL4_Enemy_RNG LVL4_enemy_RNG;
    public LVL4_Player_RNG LVL4_player_RNG;


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

    //MECHANIC BUTTONS
    public GameObject playerAttackButton;
    public GameObject playerHealButton;
    public GameObject playerBlockButton;
    public GameObject playerShieldButton;
  

    //SHIELD CHECKER
   
    public GameObject shieldCanvas;
    public GameObject shieldOG;
    public GameObject shieldOBJ;

    public static bool playerHasShield;
    public static bool enemyAttackedShield;

    GameObject shieldClone;

    void Start()
    {
        shieldOG.GetComponent<Image>();
        shieldOG.GetComponent<Image>().enabled = false;
        gameState = GameState.gameStart;

        square.SetActive(false);
        square2.SetActive(false);

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
        playerHealButton.SetActive(false);
        playerBlockButton.SetActive(false);
        playerShieldButton.SetActive(false);
        

        enemySlider.gameObject.SetActive(false);
        playerSlider.gameObject.SetActive(false);

       


        playerHasShield = false;
        enemyAttackedShield = false;
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
        LVL4_player_RNG.activateRNG();
        LVL4_player_RNG.activateNumber();

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
        playerHealButton.SetActive(true);
        playerBlockButton.SetActive(true);
        playerShieldButton.SetActive(true);

        if (playerHasShield==true)
        {
            playerShieldButton.SetActive(false);
        }

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
        LVL4_enemy_AI.enemyTakenDamage();

        //UI UPDATED
        maintextBox.text = "<color=#ff0000ff><b>ENEMY</b></color>" + " has taken " + "<b>" + LVL4_enemy_AI.playerDamageAttackGiven.ToString() + "</b>" + "<b>HP</b>" + " DAMAGE!";
        enemyUI.text = LVL4_enemy_AI.enemyCurrentHealth + "/" + LVL4_enemy_AI.enemyMaxHealth;
        damage.Play();
        enemyAnim.Play("Enemy_Damages");

        //HAS ENEMY BEEN KILLED?
        if (LVL4_enemy_AI.enemyCurrentHealth <= 0)
        {
            //Debug.Log("Dead enemy");
            LVL4_enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            Debug.Log("Enemy Turn State");

            gameState = GameState.enemyTurn;
            StartCoroutine(enemyTurnState());

        
        }

    }



    //PLAYER HEAL
    public void onPlayerHealButton()
    {
        click.Play();
        if (gameState != GameState.playerTurn)
            return;
        else StartCoroutine(PlayerHeal());
    }


    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(2);

        //Debug.Log("Player Heals");

        //UI UPDATED 
        maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + "<b> HEALS!</b>";

        yield return new WaitForSeconds(2);

        //PLAYER HEALED
        LVL4_player_Controller.playerHealedUp();

        //UI UPDATED
        maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + " has" + "<b> HEALED</b>" + " by " + "<b>" + LVL4_player_Controller.playerHealed.ToString() + "</b>" + "<b> HP!</b>";
        playerUI.text = LVL4_player_Controller.playerCurrentHealth + "/" + LVL4_player_Controller.playerMaxHealth;
        heal.Play();
        playerAnim.Play("Player_Heals");

        //HAS ENEMY BEEN KILLED?
        if (LVL4_enemy_AI.enemyCurrentHealth <= 0)
        {
            //Debug.Log("Dead enemy");
            LVL4_enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            //Debug.Log("Enemy Turn State");

            gameState = GameState.enemyTurn;
            StartCoroutine(enemyTurnState());

           

        }

    }



    //PLAYER BLOCK
    public void onPlayerBlockButton()
    {
        click.Play();
        if (gameState != GameState.playerTurn)
            return;
        else StartCoroutine(PlayerBlock());
    }

    public IEnumerator PlayerBlock()
    {
        yield return new WaitForSeconds(2);



        //UI UPDATED 
        maintextBox.richText = enabled;
        maintextBox.text = "<color=#0000ffff><b>PLAYER</b></color>" + "<b> BLOCKS!</b>";

        playerAttackButton.SetActive(false);
        playerHealButton.SetActive(false);
        playerBlockButton.SetActive(false);
        playerShieldButton.SetActive(false);

        yield return new WaitForSeconds(2);

        //UI UPDATED
        maintextBox.text = "<color=#0000ffff><b>PLAYER</b></color>" + " goes <b>AGAIN!</b> ";


        //HAS ENEMY BEEN KILLED?
        if (LVL4_enemy_AI.enemyCurrentHealth <= 0)
        {
            //Debug.Log("Dead enemy");
            LVL4_enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            Debug.Log("Player Turn State");

            gameState = GameState.playerTurn;
            StartCoroutine(playerTurnState());


        }

    }


    //PLAYER SHIELD 
    public void onButtonShieldState()
    {
        click.Play();
        if (gameState != GameState.playerTurn)
            return;
        else StartCoroutine(PlayerShields());

       
    }

    public IEnumerator PlayerShields()
    {
        yield return new WaitForSeconds(2);

        //UI UPDATED 
        maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + "<b> SHIELDS!</b>";

        playerAttackButton.SetActive(false);
        playerHealButton.SetActive(false);
        playerBlockButton.SetActive(false);
        playerShieldButton.SetActive(false);

        yield return new WaitForSeconds(2);

        shieldClone = Instantiate(playerShield);

        shieldClone.transform.parent = shieldCanvas.transform;
        shieldClone.transform.position = shieldOG.transform.position;
        shieldClone.transform.position = new Vector2(-294, 54);
        shieldClone.transform.localScale = new Vector2(0.2725879f, 0.08533276f);
        shieldClone.GetComponent<RectTransform>().sizeDelta = shieldOBJ.GetComponent<RectTransform>().sizeDelta;
        shieldClone.GetComponent<RectTransform>().localScale = shieldOBJ.GetComponent<RectTransform>().localScale;
        shieldClone.GetComponent<RectTransform>().position = shieldOBJ.GetComponent<RectTransform>().position;

       
        maintextBox.text = "<b><color=#0000ffff>PLAYER</color></b>" + " will not take" + "<b> DAMAGE!</b>";

        playerHasShield = true;
       
        if (playerHasShield == true && gameState == GameState.playerTurn) 
        {
            
        }
        else if (playerHasShield == false && gameState ==GameState.playerTurn)
        {
            
        }
       
       

        //HAS ENEMY BEEN KILLED?
        if (LVL4_enemy_AI.enemyCurrentHealth <= 0)
        {
          
            LVL4_enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            Debug.Log("Enemy Turn State");

            gameState = GameState.enemyTurn;
            StartCoroutine(enemyTurnState());


        }

    }

    public void checkingShield()
    {

    }

    public void destroyShield()
    {
        GameObject.Destroy(shieldClone);
        Destroy(shieldClone);
        enemyAttackedShield = false;
        playerHasShield = false;
    }







    //ENEMY TURN STATE 
    IEnumerator enemyTurnState()
    {
        LVL4_enemy_RNG.generateRNGAttackHealStateNumber();
        LVL4_enemy_RNG.generateEnemyCardPosition();
        LVL4_enemy_RNG.generateEnemyAttackHealStatNumber();


        //PLAYER BUTTONS DISABLED
        playerAttackButton.SetActive(false);
        playerHealButton.SetActive(false);
        playerBlockButton.SetActive(false);
        playerBlockButton.SetActive(false);
        playerShieldButton.SetActive(false);


        yield return new WaitForSeconds(2);
        maintextBox.text = "It's the" + "<b><color=#ff0000ff> ENEMY'S TURN</color></b>";

        yield return new WaitForSeconds(2);





        //ENEMY ATTACK
        if (LVL4_enemy_RNG.enemyRNGAttackHealStateNumber == 1)
        {
            LVL4_enemy_RNG.generateEnemyAttackHealStatNumber();
            
            //UI UPDATED
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> ATTACKS!</b>";
            Debug.Log("Enemy Attacks");

            //DOES PLAYER HAVE SHIELD?
            yield return new WaitForSeconds(2);
            if (playerHasShield == true)
            {
                
                enemyAttackedShield = true;
                LVL4_player_Controller.playerShield();
                maintextBox.text = "<b><color=#0000ffff>PLAYER </color></b>" + " has taken " + "<b>" + LVL4_player_Controller.enemyDamageGiven + "HP DAMAGE!" + "</b>";
                playerUI.text = LVL4_player_Controller.playerCurrentHealth + "/" + LVL4_player_Controller.playerMaxHealth;
                destroyShield();
            }

            //IF THEY DON'T
            else if (playerHasShield==false)
            {
                LVL4_player_Controller.playerTakenDamage();
                maintextBox.text = "<b><color=#0000ffff>PLAYER </color></b>" + " has taken " + "<b>" + LVL4_player_Controller.enemyDamageGiven + "HP DAMAGE!" + "</b>";
                playerUI.text = LVL4_player_Controller.playerCurrentHealth + "/" + LVL4_player_Controller.playerMaxHealth;
                damage.Play();
                playerAnim.Play("Player_Damages");
            }



            //IS PLAYER DEAD?
            if (LVL4_player_Controller.playerCurrentHealth <= 0)
            {
                LVL4_player_Controller.playerCurrentHealth = 0;
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
        if (LVL4_enemy_RNG.enemyRNGAttackHealStateNumber == 2)
        {
            LVL4_enemy_RNG.generateEnemyAttackHealStatNumber();

            //UI UPDATED
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> HEALS!</b>";
            Debug.Log("Enemy HEALS");

            yield return new WaitForSeconds(2);
            //ENEMY HEALS 
            LVL4_enemy_AI.enemyHealedUp();

            //UI UPDATED 
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + " has" + "<b> HEALED</b>" + " by " + "<b>" + LVL4_enemy_AI.enemyHealed + "HP" + "</b>";
            enemyUI.text = LVL4_enemy_AI.enemyCurrentHealth + "/" + LVL4_enemy_AI.enemyMaxHealth;
            heal.Play();
            enemyAnim.Play("Enemy_Heals");

            //IS PLAYER DEAD?
            if (LVL4_player_Controller.playerCurrentHealth <= 0)
            {
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




        //ENEMY BLOCKS 
        if (LVL4_enemy_RNG.enemyRNGAttackHealStateNumber == 3)
        {
            LVL4_enemy_RNG.generateEnemyAttackHealStatNumber();

            //UI UPDATED
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> BLOCKS!</b>";
            Debug.Log("Enemy BLOCKS");

            yield return new WaitForSeconds(2);


            //UI UPDATED 
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + " goes" + "<b> AGAIN!</b>";
            enemyUI.text = LVL4_enemy_AI.enemyCurrentHealth + "/" + LVL4_enemy_AI.enemyMaxHealth;


            //IS PLAYER DEAD?
            if (LVL4_player_Controller.playerCurrentHealth <= 0)
            {
                //Debug.Log("Player Dead");
                gameState = GameState.playerLost;
                endState();
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                gameState = GameState.enemyTurn;
                StartCoroutine(enemyTurnState());
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
            playerHealButton.SetActive(false);
            playerBlockButton.SetActive(false);
            

        }

        //Debug.Log("end");
        if (gameState == GameState.playerLost)
        {
            sad.Play();
            maintextBox.text = "<b><color=#ff0000ff>ENEMY</color></b>" + "<b> WINS!</b>";

            playerAttackButton.SetActive(false);
            playerHealButton.SetActive(false);
            playerBlockButton.SetActive(false);
            

            
        }

    }
}
