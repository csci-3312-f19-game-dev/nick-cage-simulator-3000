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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
