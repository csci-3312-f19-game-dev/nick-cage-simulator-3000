using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /* Singleton */
    public static PlayerManager PM;
    public static bool StoreMenuIsOpen;
    private void Awake()
    {
        PM = this;
    }

    //Managing tiles clicked
    public TileHandler prevTile;
    public TileHandler currTile;
    public TileHandler lastClickedTile;//for store/unit spawning purposes
    public bool isTileClicked = false;

    //Resources
    public int wood = 5;
    public int stone = 5;
    public int water = 5;
    public int food = 4;
    public int moveCount = 0;

    //Winning stuff
    public int unitsToWin = 10;

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
        Debug.Log("Moo");
        if (food < 5) Debug.Log("You don't have enough food to purchase a new unit");
        else
        {
            Debug.Log("New unit added. Food was " + food);
            food -= 5;
            if (prevTile == null)
            {
                lastClickedTile.addUnit();//compkains this is null whenclicedafter one move
            }
            else
            {
                prevTile.addUnit();
            }
        }
    }

    public void tileClicked(TileHandler tile, bool shiftDown)
    {
        if(StoreMenuIsOpen) return;
        if (!isTileClicked)
        {
            prevTile = tile;
            isTileClicked = true;
        }
        else
        {
            currTile = tile;
            lastClickedTile = currTile;

            //Check if move is legal (can only move to adjacent tile)
            Tuple<int, int> prevXY = prevTile.getGridXY();
            int prevX = prevXY.Item1;
            int prevY = prevXY.Item2;
            Tuple<int, int> currXY = currTile.getGridXY();
            int currX = currXY.Item1;
            int currY = currXY.Item2;
            bool legalMove;
            if (currX - 1 <= prevX && prevX <= currX + 1 && currY - 1 <= prevY && prevY <= currY + 1) legalMove = true;
            else legalMove = false;

            if (legalMove)
            {
                if (shiftDown) moveUnits();
                else moveUnit();                
            }
            else
            {
                Debug.Log("Illegal Move");
            }

            resetPM();
        }
    }

    //moveUnit and moveUnits have duplicate code, but works for now.
    private void moveUnits()
    {
        if (prevTile.numUnits() < 1) { Debug.Log("There are no units on that tile"); }
        else
        {
            double groupPercentChance = milliPercentChanceOfDeath - (prevTile.numUnits() * .01f);
            if (groupPercentChance < 0.05) groupPercentChance = 0.05; //has to at least have 5%
            bool resourceGotten = false;
            while (prevTile.numUnits() > 0)
            {
                double rn = rng.NextDouble();
                if (rn < groupPercentChance)
                {
                    //Debug.Log(rn + " vs " + groupPercentChance);
                    prevTile.killUnit();
                }
                else
                {
                    Unit u = prevTile.grabUnit();
                    currTile.transferUnit(u);
                    if (!resourceGotten) //ensures you only get on food per move, rather than one food per unit
                    {
                        //Add appropriate resourece to inventory
                        resourceGotten = true;
                        //food++;
                        getResource();
                    }
                }
            }
        }
    }
            
    void getResource()
    {
        switch (currTile.typeOfTileName)
        {
            case "plains":
                food++;
                break;
            case "river":
                water++;
                break;
            case "forest":
                wood++;
                food++;
                break;
            case"stone":
                stone++;
                break;
            default:
                food++;
                break;
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
                //food++;
                getResource();
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
