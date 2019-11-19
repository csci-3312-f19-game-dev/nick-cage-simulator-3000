using System.Collections;
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
        if (food < 4) Debug.Log("You don't have enough food to purchase a new unit");
        else
        {
            Debug.Log("New unit added");
            food -= 5;
            prevTile.addUnit();
        }
    }

    public void tileClicked(TileHandler tile, bool shiftDown)
    {
        if (!isTileClicked)
        {
            prevTile = tile;
            isTileClicked = true;
        }
        else
        {
            currTile = tile;
            if (shiftDown) moveUnits();
            else moveUnit();
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
            bool foodGotten = false;
            while (prevTile.numUnits() > 0)
            {
                double rn = rng.NextDouble();
                if (rn < groupPercentChance)
                {
                    Debug.Log(rn + " vs " + groupPercentChance);
                    prevTile.killUnit();
                }
                else
                {
                    Unit u = prevTile.grabUnit();
                    currTile.transferUnit(u);
                    if (!foodGotten) //ensures you only get on food per move, rather than one food per unit
                    {
                        foodGotten = true;
                        food++;
                    }
                }
            }
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
                food++;
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
