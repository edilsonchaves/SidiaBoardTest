using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Colectable", menuName = "Board/New Colectable")]
public class ColectableScriptable :ScriptableObject
{
    public enum TypeColectableEnum {Movement,Attack,Health}
    public TypeColectableEnum typeColectable;
    public int forcaEfeito;
    public Color colorTileColectable;
}
