using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Player playerData;
    public MeshRenderer renderObjeto;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
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

    public void InitialPositionPlayer(Transform tilePosition)
    {
        gameObject.transform.SetParent(tilePosition);
        gameObject.transform.localPosition = Vector3.zero;
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
