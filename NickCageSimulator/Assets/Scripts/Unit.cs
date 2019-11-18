using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    string type;
    //xPos and yPos are already contained by the transform, so I don't think we need these variables
    float xPos;
    float yPos;
    TileHandler tile;
    //attach to sprite?
    SpriteRenderer sr;

    void Start()
    {
        type = "theOnlyTypeRn"; //potential to expand
        xPos = transform.position.x;
        yPos = transform.position.y;
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = MapGenerator.MG.topLayer() + 1;
    }

    void Update()
    {
        //TODO call to TileHandler new method "try to harvest"
        //if successful, TileHandler will add to player stash
        //reload time for resources based on a timer
    }

    public void setTile(TileHandler th, Transform tr)
    {
        tile = th;
        transform.SetParent(tr);
        transform.localPosition = new Vector3(0, 0, 0);   
    }
}