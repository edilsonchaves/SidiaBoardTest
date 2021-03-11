using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerChooseCanvas : MonoBehaviour
{
    public int playerJogador;
    [SerializeField]PlayerDataScriptable[] playersConfig;
    [SerializeField]GameObject[] typePlayers;
    [SerializeField] Text textTitle;
    // Start is called before the first frame update
    void Start()
    {
        playerJogador = 1;
        textTitle.text = "Choose Player " + playerJogador;
        AdjustPlayerMaterial();
    }

    void AdjustPlayerMaterial()
    {
        int playerConfig = 0;
        foreach (GameObject player in typePlayers)
        {
            if (playerJogador == 1)
            {
                player.GetComponentInChildren<MeshRenderer>().material.color = playersConfig[playerConfig].colorP1;
            }
            else
            {
                player.GetComponentInChildren<MeshRenderer>().material.color = playersConfig[playerConfig].colorP2;
            }
            playerConfig++;
        }
    }


    public void playerSelection(int numberPlayerSelection)
    {
        Player newPlayer=null;
        if (playerJogador == 1)
        {
            newPlayer = new Player(playersConfig[numberPlayerSelection].name, playersConfig[numberPlayerSelection].health, playersConfig[numberPlayerSelection].attack,
                                   playersConfig[numberPlayerSelection].colorP1, playersConfig[numberPlayerSelection].renderer);
        }
        else if(playerJogador==2){
            newPlayer = new Player(playersConfig[numberPlayerSelection].name, playersConfig[numberPlayerSelection].health, playersConfig[numberPlayerSelection].attack,
                                   playersConfig[numberPlayerSelection].colorP2, playersConfig[numberPlayerSelection].renderer);
        }

        ManagerGame.Instance.playersGame.Add(newPlayer);
        playerJogador++;
        if (playerJogador < 3)
        {
            textTitle.text = "Choose Player " + playerJogador;
            AdjustPlayerMaterial();
        }
        else
        {
            //startGame
            SceneManager.LoadScene("GameScene");
        }

    }
}
