using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player/New Player")]
public class PlayerDataScriptable : ScriptableObject
{
    public string name;
    public GameObject renderer;
    public int health;
    public int attack;
    public Color colorP1;
    public Color colorP2;
}
