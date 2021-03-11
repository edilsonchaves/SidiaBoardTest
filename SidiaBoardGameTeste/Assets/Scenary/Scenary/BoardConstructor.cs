using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardConstructor : MonoBehaviour
{
    [SerializeField] Transform board;
    [SerializeField] GameObject tilePrefab;
    public List<GameObject> tileBoard;
    public ColectableScriptable[] colectablesScriptable;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void InstantiateBoardGame()
    {
        for(int i = 0; i < ManagerGame.Instance.HeigthValue; i++)
        {
            for (int j = 0; j < ManagerGame.Instance.WidthValue; j++)
            {
                GameObject tileInstantiate = Instantiate(tilePrefab, board);
                tileInstantiate.transform.position = new Vector3(0+5*j, 0, 0+5*i);
                tileInstantiate.name = "Tile" + j + " " +"" + i;
                tileInstantiate.GetComponent<TileScript>().ConfigTile(j,i);

                int randomNumber = Random.Range(0, 101);
                if (randomNumber < 60)
                {
                    if (randomNumber < 30)
                    {
                        tileInstantiate.GetComponent<TileScript>().ConfigColectable(colectablesScriptable[0]);
                    }
                    else
                    {
                        tileInstantiate.GetComponent<TileScript>().ConfigColectable(colectablesScriptable[1]);
                    }
                }
                else
                {
                    if (randomNumber < 90)
                    {
                        tileInstantiate.GetComponent<TileScript>().ConfigColectable(colectablesScriptable[2]);
                    }
                    else
                    {
                        tileInstantiate.GetComponent<TileScript>().ConfigColectable(colectablesScriptable[3]);
                    }
                }
                tileBoard.Add(tileInstantiate);
            }
        }
    }

    public void RemoveColectablePosition(int PosWidht, int PosHeigth)
    {

    }

    public Transform GetTile(int width,int heigth)
    {
        return tileBoard[ManagerGame.Instance.WidthValue * heigth + width].transform;
    }
}
