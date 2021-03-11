using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] BoardConstructor board;
    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitializeGame();
        }
    }


    void InitializeGame()
    {
        board.InstantiateBoardGame();
        GameObject p1 = Instantiate(playerPrefab);
        p1.GetComponent<PlayerScript>().initiatePerson(ManagerGame.Instance.playersGame[0]);
        int randoPosWidthP1 = Random.Range(0, ManagerGame.Instance.WidthValue);
        int randoPosheigthP1 = Random.Range(0, ManagerGame.Instance.HeigthValue);
        p1.GetComponent<PlayerScript>().InitialPositionPlayer(board.GetTile(randoPosWidthP1, randoPosheigthP1));
        GameObject p2 = Instantiate(playerPrefab);
        p2.GetComponent<PlayerScript>().initiatePerson(ManagerGame.Instance.playersGame[1]);
        bool differentPositionP1 = false;
        int randoPosWidthP2 = 0;
        int randoPosheigthP2 = 0;
        while (!differentPositionP1)
        {
            randoPosWidthP2 = Random.Range(0, ManagerGame.Instance.WidthValue);
            randoPosheigthP2 = Random.Range(0, ManagerGame.Instance.HeigthValue);
            if (randoPosWidthP2 != randoPosWidthP1 || randoPosheigthP2 != randoPosheigthP1)
            {
                differentPositionP1 = true;
            }
        }
        p2.GetComponent<PlayerScript>().InitialPositionPlayer(board.GetTile(randoPosWidthP2, randoPosheigthP2));
    }
}
