using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    //have a player controller singleton that keeps track of if tile selected or not
    //moderate the onMoustOver.GetMouseButtonDown(0) to do something differently if the player has pre-selected a tile
    //be concious of off-screen clicks or something -- actually, shouldn't matter since this is onMouseOver
    //REMOVE PLAYER MANAGER FROM CLASS ONCE YOU ARE DONE

    private SpriteRenderer sr;
    private int unitCount = 5; //Arbitrary choice of 5 for testing

    /* Unity-specific functions */

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerManager.PM.isTileClicked)
            {
                PlayerManager.PM.isTileClicked = false;
                PlayerManager.PM.currTile = this;
                PlayerManager.PM.prevTile.unitCount -= 1;
                PlayerManager.PM.currTile.unitCount += 1;
                //Setting to null after each pair of tile clicks - hackish but works for now
                PlayerManager.PM.prevTile = null;
                PlayerManager.PM.currTile = null;
            } else
            {
                PlayerManager.PM.isTileClicked = true;
                PlayerManager.PM.prevTile = this;
            }

            sr.color = new Color(1, 0, 0, 1);
        }
    }
    
}
