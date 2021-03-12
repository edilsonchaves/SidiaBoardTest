using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameCanvas battleCanvas;
    [SerializeField] int numberOfDices;
    [SerializeField] List<int> dicesPlayerTurn;
    [SerializeField] List<int> dicesPlayerEnemy;

    int victoryPlayerTurn;
    int victoryPlayerEnemy;
    bool isBattleSystem;
    float timerRollDice;
    PlayerScript playerTurn;
    PlayerScript playerEnemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBattleSystem)
        {
            if (timerRollDice > 2)
            {
                timerRollDice = 0;
                int winner = CompareHigherDices();
                if (winner == 0)
                {
                    victoryPlayerTurn++;
                }
                else
                {
                    victoryPlayerEnemy++;
                }
                battleCanvas.VictoryUI(victoryPlayerTurn, victoryPlayerEnemy);

                if (dicesPlayerTurn.Count == 0)
                {
                    if (victoryPlayerTurn >= victoryPlayerEnemy)
                    {
                        battleCanvas.FinalWinnerUI(playerTurn.playerData.Name, "Player Turn");
                        playerEnemy.CurrentHealthPlayer -= playerTurn.CurrentAttackPlayer;
                        battleCanvas.ConfigPlayerEnemyUI(playerEnemy);
                    }
                    else
                    {
                        battleCanvas.FinalWinnerUI(playerEnemy.playerData.Name, "Player Enemy");
                        playerTurn.CurrentHealthPlayer -= playerEnemy.CurrentAttackPlayer;
                        battleCanvas.ConfigPlayerTurnUI(playerTurn);

                    }

                    battleCanvas.EndBattleSysteButtonIteractable(true);
                    isBattleSystem = false;
                }
            }
            else
            {
                timerRollDice += Time.deltaTime;
            }
           
        }
    }
    public void InitiateBattleSystem(int numberDices, PlayerScript newPlayerTurn, PlayerScript newPlayerEnemy)
    {
        playerTurn = newPlayerTurn;
        playerEnemy = newPlayerEnemy;
        victoryPlayerTurn = 0;
        victoryPlayerEnemy = 0;
        dicesPlayerTurn = new List<int>();
        dicesPlayerEnemy = new List<int>();
        RollDice(numberDices);
        isBattleSystem = true;
        timerRollDice = 1.5f;
        battleCanvas.VictoryUI(0, 0);
        battleCanvas.InitialDice();
        battleCanvas.FinalWinnerUI("", "");
        battleCanvas.EndBattleSysteButtonIteractable(false);
    }
    void RollDice(int dices)
    {
        numberOfDices = dices;
        for (int i = 0; i < numberOfDices; i++)
        {
            dicesPlayerTurn.Add(Random.Range(1, 7));
            dicesPlayerEnemy.Add(Random.Range(1, 7));
        }
    }

    int CompareHigherDices()
    {
        int numberDicePlayerTurn= HigherDicePlayerTurn();
        int numberDicePlayerEnemy= HigherDicePlayerEnemy();
        Debug.Log("Player: "+ numberDicePlayerTurn+ ", Enemy: "+ numberDicePlayerEnemy);

        if (numberDicePlayerTurn>= numberDicePlayerEnemy)
        {
            battleCanvas.RollDiceUI(numberDicePlayerTurn, numberDicePlayerEnemy,0);
            return 0;
        }
        else
        {
            battleCanvas.RollDiceUI(numberDicePlayerTurn, numberDicePlayerEnemy, 1);
            return 1;
        }
    }

    int HigherDicePlayerTurn()
    {
        int number = 0;
        int positionNumber = -1;
        int count = 0;
        foreach(int diceValue in dicesPlayerTurn)
        {
            if (diceValue > number)
            {
                number = diceValue;
                positionNumber = count;
            }
            count++;
        }
        dicesPlayerTurn.RemoveAt(positionNumber);
        return number;
    }

    int HigherDicePlayerEnemy()
    {
        int number = 0;
        int positionNumber = -1;
        int count = 0;
        foreach (int diceValue in dicesPlayerEnemy)
        {
            if (diceValue > number)
            {
                number = diceValue;
                positionNumber = count;
            }
            count++;
        }
        dicesPlayerEnemy.RemoveAt(positionNumber);
        return number;
    }
}
