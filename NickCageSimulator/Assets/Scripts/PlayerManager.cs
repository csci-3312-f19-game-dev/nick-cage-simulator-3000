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

    public void assignPrevTile(TileHandler tile) { prevTile = tile;  }
    public void assignCurrTile(TileHandler tile) { currTile = tile; }
    public void resetPM()
    {
        assignCurrTile(null);
        assignPrevTile(null);
        isTileClicked = false;
    }
}
