using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Data")]
    public Player playerData;
    public MeshRenderer renderObjeto;
    [SerializeField]int widthPos;
    [SerializeField]int heigthPos;
    [Header("Player Movement")]
    int basicmovementPlayer = 3;
    [SerializeField]int _currentMovementPlayer;
    [SerializeField] GameObject destiny;
    [SerializeField] float velMove;
    [SerializeField] bool _isMove;
    public bool IsMove
    {
        get
        {
            return _isMove;
        }
        set
        {
            _isMove = value;
        }
    }
    public int CurrentMovementPlayer
    {
        get
        {
            return _currentMovementPlayer;
        }
        set
        {
            Debug.Log(value);
            _currentMovementPlayer = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        velMove = 5;
    }
    private void Update()
    {
        if (_isMove)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destiny.transform.position, velMove * Time.deltaTime);
            if (Vector3.Distance(this.transform.position, destiny.transform.position) == 0)
            {
                IsMove = false;
                destiny = null;
            }
        }
    }
    public void initiatePerson(Player newPlayerData)
    {
        playerData = new Player(newPlayerData.Name, newPlayerData.HealthInitial, newPlayerData.AttackInitial, newPlayerData.PlayerColor, newPlayerData.RendererPlayer);
        InstantiateRenderer();
        ConfigPerson();
    }
    public void InstantiateRenderer()
    {
        this.gameObject.name = playerData.Name;
        Instantiate(playerData.RendererPlayer,transform);
        renderObjeto = GetComponentInChildren<MeshRenderer>();
    }
    public void ConfigPerson()
    {
        playerData.InitializePlayer();
        renderObjeto.material.color = playerData.PlayerColor;
    }
    public void InitialPositionPlayer(Transform tilePosition, int widthPosition, int heigthPostion)
    {
        gameObject.transform.SetParent(tilePosition);
        gameObject.transform.localPosition = Vector3.zero;
        widthPos = widthPosition;
        heigthPos = heigthPostion;
    }
    public void InitiatePersonTurn()
    {
        _currentMovementPlayer = basicmovementPlayer;
    }
    public int GetWidth()
    {
        return widthPos;
    }
    public int GetHeigth()
    {
        return heigthPos;
    }

    public void setDestinyPlayer (GameObject newDestiny)
    {
        destiny = newDestiny;
        _isMove = true;
        widthPos = newDestiny.GetComponent<TileScript>().GetWidth();
        heigthPos = newDestiny.GetComponent<TileScript>().GetHeigth();
    }
}


[System.Serializable]
public class Player
{
    [Header("Initial Data")]
    [SerializeField] string _name;
    [SerializeField] int _healthInitial;
    [SerializeField] int _attackInitial;
    [SerializeField] Color _playerColor;
    [SerializeField] GameObject _rendererPlayer;
    [Header("Game Player Info")]
    [SerializeField] int _currentHealth;

    public string Name {get{return _name;}}
    public int HealthInitial {get{return _healthInitial; }}
    public int AttackInitial {get{return _attackInitial;}}
    public Color PlayerColor {get{return _playerColor; }}
    public GameObject RendererPlayer {get{return _rendererPlayer;}}

    public Player(string newName, int newHeathInitial, int newAttackInitial, Color newColor, GameObject newRendererPlayer )
    {
        _name = newName;
        _healthInitial = newHeathInitial;
        _attackInitial = newAttackInitial;
        _playerColor = newColor;
        _rendererPlayer = newRendererPlayer;
    }

    public void InitializePlayer()
    {
        _currentHealth = _healthInitial;
    }


}
