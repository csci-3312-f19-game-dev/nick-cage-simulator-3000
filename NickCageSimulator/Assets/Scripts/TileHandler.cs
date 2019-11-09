using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    
    private SpriteRenderer sr;
    private int unitCount = 0; //Each tile starts out with no units
    private bool isCityOfGold;
    public float milliPercentChanceOfDeath = .13f;
    //Unity has a UnityEngine.Random which cannont generate random numbers,
    //must speicify System.Random
    private System.Random rng = new System.Random();

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
                
                //Should the player still see the city of gold if a unit died when going into it?
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
        sr.sprite = SpriteContainer.SC.cityOfGold;
        //TODO need to adjust the polygon collider to match the new sprite
    }

    public void addUnit()
    {
        unitCount += 1; 
    }

    //Starting to get a little messy. One could argue that the player manager should be invoking functions that
    //manipulate the unit count of the tiles, rather than the tile handler doing it. 
    //prev/currTile might ought to be private vars, i.e. a tile handler shouldn't
    //know or care what the curr/prev tile clicked on is. 
    private void moveUnit()
    {
        double rn = rng.NextDouble();
        if (rn < milliPercentChanceOfDeath)
        {
            Debug.Log(rn + " vs " + milliPercentChanceOfDeath);
            PlayerManager.PM.prevTile.killUnit();
        } else {
            PlayerManager.PM.food++;
            PlayerManager.PM.prevTile.unitCount -= 1;
            PlayerManager.PM.currTile.unitCount += 1;
            Debug.Log("unit removed from " + PlayerManager.PM.prevTile.name + ", " + PlayerManager.PM.prevTile.unitCount + " total units");
            Debug.Log("unit added to " + PlayerManager.PM.currTile.name + ", " + PlayerManager.PM.currTile.unitCount + " total units");
        }
    }

    public void killUnit()
    {
        unitCount -= 1;
        Debug.Log("Oh no, your unit from " + this.name + " has died from dysentery");
    }

    public void setOrderInLayer(int i) { sr.sortingOrder = i; }
}
