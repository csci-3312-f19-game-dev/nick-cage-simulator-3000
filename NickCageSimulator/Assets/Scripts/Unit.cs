using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    string type;
    float xPos;
    float yPos;
    TileHandler tile;
    //attach to sprite?

    void Start()
    {
        type = "theOnlyTypeRn"; //potential to expand
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(xPos, yPos, 0f); //0 is the z value

        //TODO call to TileHandler new method "try to harvest"
        //if successful, TileHandler will add to player stash
        //reload time for resources based on a timer
    }

    public void setTile(TileHandler t, float x, float y)
    {
        tile = t;
        xPos = x;
        yPos = y;
    }
}