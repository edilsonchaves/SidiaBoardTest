﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] int widthPos;
    [SerializeField] int heigthPos;
    [SerializeField] Colectable colectable;

    [SerializeField] Color defaultColor;
    [SerializeField] MeshRenderer meshRendererIntern;
    [SerializeField] ParticleSystem particles;
    public AudioSource audioTile;
    public void ConfigTile(int valueWidth, int valueHeight)
    {
        widthPos = valueWidth;
        heigthPos = valueHeight;
    }
    public void ConfigColectable(ColectableScriptable colecScriptable)
    {
        int randomNumber = Random.RandomRange(0, 100);
        int rarity = 0;
        if (randomNumber < 60)
        {
            rarity = 1;
        }
        else
        {
            if (randomNumber < 97)
            {
                rarity = 2;
            }
            else
            {
                rarity = 3;
            }
        }
        colectable = new Colectable(colecScriptable.typeColectable.ToString(), rarity, colecScriptable.forcaEfeito, colecScriptable.colorTileColectable);
        meshRendererIntern.material.color = colectable.colorTileColectable;
    }
    public Colectable GetColectable()
    {
        
        return colectable;
    }
    public void PlayParticleGetColectable()
    {
        particles.Play();
    }
    public void RemoveColectable()
    {
        
        colectable = null;
        meshRendererIntern.material.color = defaultColor;
    }

    public int GetWidth()
    {
        return widthPos;
    }
    public int GetHeigth()
    {
        return heigthPos;
    }
}
[System.Serializable]
public class Colectable
{
    public string typeColectable;
    public int rarity;
    public int forceEffect;
    public Color colorTileColectable;

    public Colectable(string newTypeColectable,int newRarity, int newForceEffect,Color newColorTile)
    {
        typeColectable = newTypeColectable;
        rarity = newRarity;
        forceEffect = newForceEffect;
        colorTileColectable = newColorTile;
    }

}