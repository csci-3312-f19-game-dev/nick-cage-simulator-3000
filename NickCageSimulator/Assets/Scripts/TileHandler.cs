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
    private int unitCount = 0; //Each tile starts out with no units
    private bool isCityOfGold;

    /* Unity-specific functions */

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        isCityOfGold = false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
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
                PlayerManager.PM.assignCurrTile(this);
                moveUnit(); 
                
                if (PlayerManager.PM.currTile.isCityOfGold)
                {
                    Debug.Log("Congrats, you have found the city of gold!");
                    displayCityOfGold();
                    if (unitCount == 10) Debug.Log("Congrats, you have successfully excavated the city of gold!");
                    //in future prototypes, this might be where we handle win requirements logic
                }

                PlayerManager.PM.resetPM();
                
            } else
            {
                PlayerManager.PM.isTileClicked = true;
                PlayerManager.PM.assignPrevTile(this);
            }
        }
    }
    
    /* Our functions */
    public void setAsCityOfGold()
    {
        isCityOfGold = true;
    }
    void displayCityOfGold()
    {
        sr.color = new Vector4(1, 2, 0, 1);
    }

    public void addUnit()
    {
        unitCount += 1; 
    }

    private void moveUnit()
    {
        PlayerManager.PM.prevTile.unitCount -= 1;
        PlayerManager.PM.currTile.unitCount += 1;
        Debug.Log("unit removed from " + PlayerManager.PM.prevTile.name + ", " + PlayerManager.PM.prevTile.unitCount + " total units");
        Debug.Log("unit added to " + PlayerManager.PM.currTile.name + ", " + PlayerManager.PM.currTile.unitCount + " total units");
    }
}
