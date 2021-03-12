using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame Instance { get; private set; }
    public List<Player> playersGame;

    [SerializeField] int _widthValue;
    [SerializeField] int _heigthValue;
    [SerializeField] bool _isMusic;

    public int WidthValue
    {
        get { return _widthValue; }
        set { _widthValue = value; }
    }

    public int HeigthValue
    {
        get { return _heigthValue; }
        set { _heigthValue = value; }
    }

    public bool IsMusic
    {
        get { return _isMusic; }
        set { _isMusic = value; }
    }
    void Awake()
    {
        if (Instance == null)
        {
            _widthValue = 16;
            _heigthValue = 16;
            _isMusic = true;
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
