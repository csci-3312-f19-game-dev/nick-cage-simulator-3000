using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    
    private SpriteRenderer sr;
    private int unitCount = 0; //Each tile starts out with no units
    private List<Unit> units = new List<Unit> ();

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
        //Add logic for shift click to move all units at once
        if (Input.GetMouseButtonDown(0))
        {
            PlayerManager.PM.tileClicked(this);
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
        Unit newUnit = new Unit();
        units.Add(newUnit);
        newUnit.setTile(this, transform.position.x, transform.position.y); //***
    }

    public Unit grabUnit()
    {
        Debug.Log("hmm");
        Unit temp = units[0];
        Debug.Log("After hmm");
        units.RemoveAt(0);
        return temp;
    }

    public void transferUnit(Unit u)
    {
        units.Add(u);
        unitCount++;
        if (isCityOfGold)
        {
            Debug.Log("Congrats, you have found the city of gold!");
            displayCityOfGold();
            if (unitCount == 10) Debug.Log("Congrats, you have successfully excavated the city of gold!");
        }
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

    public int numUnits() { return unitCount; }
    public void setOrderInLayer(int i) { sr.sortingOrder = i; }
}
