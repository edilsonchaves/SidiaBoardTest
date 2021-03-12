using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GameScript : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] BoardConstructor board;
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject camViewReference;
    enum TurnoEnum {Player1,Player2}
    [SerializeField]TurnoEnum turno;

    enum GameStatusEnum { MovementCamera,MovementPlayer,Game,Battle}
    [SerializeField] GameStatusEnum gameStatus;
    int playerTurn;
    [SerializeField]CinemachineVirtualCamera cam;
    [SerializeField] GameCanvas gameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();
        playerTurn = 0;
        players[playerTurn].GetComponent<PlayerScript>().InitiatePersonTurn();
        gameCanvas.PlayerMovementUI(players[playerTurn].GetComponent<PlayerScript>().CurrentMovementPlayer, turno.ToString());
        gameStatus = GameStatusEnum.Game;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus == GameStatusEnum.Game)
        {
            if (Input.GetMouseButtonDown(0) && players[playerTurn].GetComponent<PlayerScript>().CurrentMovementPlayer > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    TileScript tileSelect = null;
                    if (hit.collider.gameObject.GetComponent<TileScript>() != null)
                    {
                        tileSelect = hit.collider.gameObject.GetComponent<TileScript>();
                        Debug.Log(tileSelect.GetWidth() + " " + tileSelect.GetHeigth());
                        bool approvedMove = OrtogonalCheck(players[playerTurn].GetComponent<PlayerScript>(), tileSelect);
                        if (hit.collider.gameObject.transform.childCount == 1 && approvedMove)
                        {
                            players[playerTurn].GetComponent<PlayerScript>().CurrentMovementPlayer -= 1;
                            gameCanvas.PlayerMovementUI(players[playerTurn].GetComponent<PlayerScript>().CurrentMovementPlayer, turno.ToString());
                            gameStatus = GameStatusEnum.MovementPlayer;
                            players[playerTurn].GetComponent<PlayerScript>().setDestinyPlayer(hit.collider.gameObject);
                            
                        }
                        else
                        {
                            Debug.Log("Nao Posso mover");
                        }
                    }
                }
            }
        }
        if(gameStatus == GameStatusEnum.MovementPlayer)
        {
            if (!players[playerTurn].GetComponent<PlayerScript>().IsMove)
            {
                if (OrtogonalCheckBattle(players))
                {
                    gameStatus = GameStatusEnum.Battle;
                }
                else
                {
                    gameStatus = GameStatusEnum.Game;
                    if (players[playerTurn].GetComponent<PlayerScript>().CurrentMovementPlayer == 0)
                    {
                        ChangeTurn();
                        ChangeCamFollow();
                        gameCanvas.PlayerMovementUI(players[playerTurn].GetComponent<PlayerScript>().CurrentMovementPlayer, turno.ToString());
                    }
                }
            }
        }
    }

    bool OrtogonalCheck(PlayerScript player, TileScript tileSelect)
    {
        if(player.GetWidth()+1 == tileSelect.GetWidth() || player.GetWidth() -1 == tileSelect.GetWidth())
        {
            if(player.GetHeigth() == tileSelect.GetHeigth())
            {
                return true;
            }
        }
        else
        {
            if (player.GetHeigth() + 1 == tileSelect.GetHeigth() || player.GetHeigth() - 1 == tileSelect.GetHeigth())
            {
                if (player.GetWidth() == tileSelect.GetWidth())
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool OrtogonalCheckBattle(GameObject[] players)
    {
        PlayerScript playerAttack=null;
        PlayerScript playerEnemy = null;
        if (playerTurn == 0)
        {
            playerAttack = players[0].GetComponent<PlayerScript>();
            playerEnemy = players[1].GetComponent<PlayerScript>();
        }
        else
        {
            playerAttack = players[1].GetComponent<PlayerScript>();
            playerEnemy = players[0].GetComponent<PlayerScript>();
        }
        if (playerAttack.GetWidth() + 1 == playerEnemy.GetWidth() || playerAttack.GetWidth() - 1 == playerEnemy.GetWidth())
        {
            if (playerAttack.GetHeigth() == playerEnemy.GetHeigth())
            {
                return true;
            }
        }
        else
        {
            if (playerAttack.GetHeigth() + 1 == playerEnemy.GetHeigth() || playerAttack.GetHeigth() - 1 == playerEnemy.GetHeigth())
            {
                if (playerAttack.GetWidth() == playerEnemy.GetWidth())
                {
                    return true;
                }
            }
        }
        return false;
    }
    void InitializeGame()
    {
        players = new GameObject[2];
        board.InstantiateBoardGame();
        GameObject p1 = Instantiate(playerPrefab);
        p1.GetComponent<PlayerScript>().initiatePerson(ManagerGame.Instance.playersGame[0]);
        int randomPosWidthP1 = Random.Range(0, ManagerGame.Instance.WidthValue);
        int randomPosheigthP1 = Random.Range(0, ManagerGame.Instance.HeigthValue);
        p1.GetComponent<PlayerScript>().InitialPositionPlayer(board.GetTile(randomPosWidthP1, randomPosheigthP1), randomPosWidthP1, randomPosheigthP1);
        players[0] = p1;
        GameObject p2 = Instantiate(playerPrefab);
        p2.GetComponent<PlayerScript>().initiatePerson(ManagerGame.Instance.playersGame[1]);
        bool differentPositionP1 = false;
        int randomPosWidthP2 = 0;
        int randomPosheigthP2 = 0;
        while (!differentPositionP1)
        {
            randomPosWidthP2 = Random.Range(0, ManagerGame.Instance.WidthValue);
            randomPosheigthP2 = Random.Range(0, ManagerGame.Instance.HeigthValue);
            if (randomPosWidthP2 != randomPosWidthP1 || randomPosheigthP2 != randomPosheigthP1)
            {
                differentPositionP1 = true;
            }
        }
        p2.GetComponent<PlayerScript>().InitialPositionPlayer(board.GetTile(randomPosWidthP2, randomPosheigthP2), randomPosWidthP2, randomPosheigthP2);
        players[1] = p2;
        cam.Follow = players[0].transform;
    }

    void ChangeCamFollow()
    {
        if(turno == TurnoEnum.Player1)
        {
            cam.Follow = players[0].transform;
        }
        else
        {
            cam.Follow = players[1].transform;
        }
    }

    public void ChangeTurn()
    {
        if (turno == TurnoEnum.Player1)
        {
            playerTurn = 1;
            turno = TurnoEnum.Player2;
            
        }
        else
        {
            playerTurn = 0;
            turno = TurnoEnum.Player1;
        }
        players[playerTurn].GetComponent<PlayerScript>().InitiatePersonTurn();
    }
}
