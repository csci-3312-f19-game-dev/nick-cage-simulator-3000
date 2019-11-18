﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /* Singleton */
    public static PlayerManager PM;
    private void Awake()
    {
        PM = this;
    }

    //Managing tiles clicked
    public TileHandler prevTile;
    public TileHandler currTile;
    public bool isTileClicked = false;

    //Resources
    //private int wood = 5;
    //private int stone = 5;
    public int food = 5;
    public int moveCount = 0;

    //Logic
    //Unity has a UnityEngine.Random which cannont generate random numbers,
    //must speicify System.Random
    private System.Random rng = new System.Random();
    public float milliPercentChanceOfDeath = .13f;

    /* Unity-specific functions */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Our functions */
    public void purchaseUnit()
    {
        if (food < 4) Debug.Log("You don't have enough food to purchase a new unit");
        else
        {
            Debug.Log("New unit added");
            food -= 5;
            prevTile.addUnit();
        }
    }

    public void tileClicked(TileHandler tile)
    {
        if (!isTileClicked)
        {
            prevTile = tile;
            isTileClicked = true;
        }
        else
        {
            currTile = tile;
            moveUnit();
            resetPM();
        }
    }
            
    private void moveUnit()
    {
        if (prevTile.numUnits() < 1) { Debug.Log("There are no units on that tile"); }
        else
        {
            double rn = rng.NextDouble();
            if (rn < milliPercentChanceOfDeath)
            {
                Debug.Log(rn + " vs " + milliPercentChanceOfDeath);
                PlayerManager.PM.prevTile.killUnit();
            }
            else
            {
                Unit u = prevTile.grabUnit();
                currTile.transferUnit(u);
            }
        }
    }

    public void assignPrevTile(TileHandler tile) { prevTile = tile;  }
    public void assignCurrTile(TileHandler tile) { currTile = tile; }
    public void resetPM()
    {
        assignCurrTile(null);
        assignPrevTile(null);
        isTileClicked = false;
    }
}
