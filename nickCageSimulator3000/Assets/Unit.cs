using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //for sprite rendering purposes
    int xLoc = 0;//change do def spawn location
    int yLoc = 0;//change to default spawn

    string type; //set on creation

    Tile tile; //assign to tile corresponding to location
    Player player;//reference to player singleton

    void Start()
    {

    }

    void Update()
    {
        if (tile.resourcesAvailable())
        {
            //list of types of resources
            int resource = tile.getResources();

            player.updateResources(tile.getType(), resource);
        }
    }

    //Called from Tile class
    void moveUnit(Tile t)
    {
        tile = t;
        int chance = 100; //TODO the likelihood of death on this tile (from tile class). format: 1 / chance

        //TODO: MOVE ASSOCIATED SPRITE

        Random random = new Random();
        if (random.Next(chance) == 1) //TODO && within first 5 turns == false
        {
            //Unit died
            player.removeUnit(this);
            Object.Destroy(this.gameObject);
            return;
        }
    }
}


