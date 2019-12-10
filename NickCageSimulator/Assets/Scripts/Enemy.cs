using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this class is to hold information for an enemy instance.
public class Enemy : MonoBehaviour
{
    string type; //For use if we expand and create multiple units
    TileHandler tile;
    GameObject thisObject; //weird variable, but needed for removing a unit
    SpriteRenderer sr;

    void Start()
    {
        type = "theOnlyTypeRn"; //potential to expand
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = MapGenerator.MG.topLayer() + 1;
    }

    void Update()
    {
        //TODO call to TileHandler new method "try to harvest" ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //if successful, TileHandler will add to player stash
        //reload time for resources based on a timer
    }

    public void setTile(TileHandler th, Transform tr)
    {
        tile = th;
        transform.SetParent(tr);
        int n = th.numEnemies();
        transform.localPosition = new Vector3(-20 + 10 * n, 0, 0);
    }

    public void assignGameObject(GameObject go)
    {

    }
}