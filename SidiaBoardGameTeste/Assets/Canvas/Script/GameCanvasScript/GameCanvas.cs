using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameCanvas : MonoBehaviour
{
    public Text movementText;
    public Text playerTurnText;
    public void PlayerMovementUI(int movementLeft,string playerTurn)
    {
        playerTurnText.text = playerTurn;
        movementText.text = "Movement: " + movementLeft;
    }
}
