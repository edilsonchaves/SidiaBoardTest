using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameCanvas : MonoBehaviour
{
    [Header("Board Game Canvas UI")]
    [SerializeField] Text movementText;
    [SerializeField] Text playerTurnText;

    [SerializeField] Text player1NameText;
    [SerializeField] Text player1AttackText;
    [SerializeField] Text player1HealthText;

    [SerializeField] Text player2NameText;
    [SerializeField] Text player2AttackText;
    [SerializeField] Text player2HealthText;

    [Header("Battle Canvas UI")]
    public GameObject battleCanvas;

    [SerializeField] Text lifePlayerTurn;
    [SerializeField] Text namePlayerTurn;
    [SerializeField] Text attackPlayerTurn;

    [SerializeField] Text lifePlayerEnemy;
    [SerializeField] Text namePlayerEnemy;
    [SerializeField] Text attackPlayerEnemy;

    [SerializeField] Text numberVictoryPlayerTurn;
    [SerializeField] Text numberVictoryPlayerEnemy;
    [SerializeField] Text finalWinner;

    [SerializeField] Sprite[] spriteDicesPlayerTurn;
    [SerializeField] Sprite[] spriteDicesPlayerEnemy;
    [SerializeField] Image dicePlayerTurnImage;
    [SerializeField] Image dicePlayerEnemyImage;
    [SerializeField] Text winnerPlayerTurnText;
    [SerializeField] Text winnerPlayerEnemyText;

    [SerializeField] Button endBattleSysteButton;

    [Header("End Game UI")]
    public GameObject endGameCanvas;
    public Text playerWinnerText;
    public void PlayerMovementUI(int movementLeft,string playerTurn)
    {
        playerTurnText.text = playerTurn;
        movementText.text = "Movement: " + movementLeft;
    }

    public void Player1UI(PlayerScript player)
    {
        player1NameText.text = player.playerData.Name;
        player1AttackText.text = "Attack: "+player.CurrentAttackPlayer;
        Debug.Log("player1: " + player.CurrentHealthPlayer);
        if (player.CurrentHealthPlayer > 0)
        {
            player1HealthText.text = "Life: " + player.CurrentHealthPlayer;
        }
        else
        {
            player1HealthText.text = "Life: " +0;
        }
    }

    public void Player2UI(PlayerScript player)
    {
        player2NameText.text = player.playerData.Name;
        player2AttackText.text = "Attack: " + player.CurrentAttackPlayer;
        Debug.Log("player2: " + player.CurrentHealthPlayer);
        if (player.CurrentHealthPlayer > 0)
        {
            player2HealthText.text = "Life: " + player.CurrentHealthPlayer;
        }
        else
        {
            player2HealthText.text = "Life: " + 0;
        }


    }

    public void ActivateBattleUI(GameObject[]players,int playerTurn)
    {
        battleCanvas.SetActive(true);
        if (playerTurn == 0)
        {
            ConfigPlayerTurnUI(players[0].GetComponent<PlayerScript>());
            ConfigPlayerEnemyUI(players[1].GetComponent<PlayerScript>());
        }
        else
        {
            ConfigPlayerTurnUI(players[1].GetComponent<PlayerScript>());
            ConfigPlayerEnemyUI(players[0].GetComponent<PlayerScript>());
        }
        
    }

    public void DesactiveBattleUI()
    {
        battleCanvas.SetActive(false);
    }
    public void VictoryUI(int playerTurnVictory, int enemyTurnVictory)
    {
        numberVictoryPlayerTurn.text = "VICTORY\n" + playerTurnVictory;
        numberVictoryPlayerEnemy.text = "VICTORY\n" + enemyTurnVictory;
    }

    public void FinalWinnerUI(string nameWinner,string complement)
    {
        if (nameWinner != "")
        {
            finalWinner.text = "FINAL WINNER\n" + nameWinner + " " + complement;
        }
        else
        {
            finalWinner.text = "";
        }

    }
    public void EndBattleSysteButtonIteractable(bool value)
    {
        endBattleSysteButton.interactable = value;
    }
    public void ConfigPlayerTurnUI(PlayerScript player)
    {
        if (player.CurrentHealthPlayer > 0)
        {
            Debug.Log("Teste1");
            lifePlayerTurn.text = "L:" + player.CurrentHealthPlayer;
        }
        else
        {
            Debug.Log("Teste2");
            lifePlayerTurn.text = "L:" + 0;
        }
        namePlayerTurn.text = "" + player.playerData.Name;
        attackPlayerTurn.text = "A:" + player.CurrentAttackPlayer;
    }
    public void ConfigPlayerEnemyUI(PlayerScript player)
    {
        Debug.Log(player.playerData.Name);
        if (player.CurrentHealthPlayer > 0)
        {
            Debug.Log("Teste1");
            lifePlayerEnemy.text = "L:" + player.CurrentHealthPlayer;
        }
        else
        {
            Debug.Log("Teste2");
            lifePlayerEnemy.text = "L:" + 0;
        }
        namePlayerEnemy.text = "" + player.playerData.Name;
        attackPlayerEnemy.text = "A:" + player.CurrentAttackPlayer;
    }
    public void RollDiceUI(int dicePlayerTurn, int dicePlayerEnemy, int winner)
    {
        dicePlayerTurnImage.sprite = spriteDicesPlayerTurn[dicePlayerTurn-1];
        dicePlayerTurnImage.color = new Color(1, 1, 1, 1);
        dicePlayerEnemyImage.sprite = spriteDicesPlayerEnemy[dicePlayerEnemy-1];
        dicePlayerEnemyImage.color = new Color(1, 1, 1, 1);
        if (winner == 0)
        {
            winnerPlayerTurnText.text = "W";
            winnerPlayerEnemyText.text = "";
        }
        else
        {
            winnerPlayerTurnText.text = "";
            winnerPlayerEnemyText.text = "W";
        }

    }
    public void InitialDice()
    {
        dicePlayerTurnImage.sprite = null;
        dicePlayerTurnImage.color = new Color(1, 1, 1, 0);
        dicePlayerEnemyImage.sprite = null;
        dicePlayerEnemyImage.color = new Color(1, 1, 1, 0);
        winnerPlayerTurnText.text = "";
        winnerPlayerEnemyText.text = "";
    }

    public void ActiveEndGameUI()
    {
        endGameCanvas.SetActive(true);
    }
    public void WinnerUIEndGame(PlayerScript player)
    {
        playerWinnerText.text = player.playerData.Name+"\nWINNER!!!";
    }
}
