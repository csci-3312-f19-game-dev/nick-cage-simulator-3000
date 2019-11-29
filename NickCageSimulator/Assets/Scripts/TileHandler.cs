using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{

    private SpriteRenderer sr;
    private int unitCount = 0; //Each tile starts out with no units
    private List<Unit> units = new List<Unit>();
    public GameObject defaultUnit;
    public String typeOfTileName;
    private bool depleted;

    private int xGrid;
    private int yGrid;

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
        depleted = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deplete()
    {
        depleted = true;
        //TODO change image
        Time.timeScale = 1;
        //StartCoroutine("ResourceRegeneration");
        StartCoroutine("ResourceRegeneration");
    }

    IEnumerator ResourceRegeneration()
    {
        yield return new WaitForSeconds(20);
        replenish();
    }

    void replenish()
    {
        //TODO change image
        depleted = false;
    }

    public bool isDepleted()
    {
        return depleted;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("Down");
                PlayerManager.PM.tileClicked(this, true);
            }
            else
            {
                PlayerManager.PM.tileClicked(this, false);
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
        Unit newUnit = Instantiate(defaultUnit, transform).GetComponent<Unit>();
        units.Add(newUnit);
        unitCount += 1;
        newUnit.setTile(this, transform);
    }

    public Unit grabUnit()
    {
        Unit temp = units[unitCount-1];
        units.RemoveAt(unitCount-1);
        unitCount -= 1;
        return temp;
    }

    public void transferUnit(Unit u)
    {
        units.Add(u);
        unitCount += 1;
        u.setTile(this, transform);
        if (isCityOfGold)
        {
            Debug.Log("Congrats, you have found the city of gold!");
            displayCityOfGold();
            if (unitCount >= PlayerManager.PM.unitsToWin) Debug.Log("Congrats, you have successfully excavated the city of gold!");
        }
    }

    public void killUnit()
    {
        Unit u = units[unitCount-1];
        units.RemoveAt(unitCount-1);
        unitCount -= 1;
        Destroy(u.gameObject);
        Debug.Log("Oh no, your unit from " + this.name + " has died from dysentery");
    }

    public int numUnits() {
        return unitCount;
    }
    public void setOrderInLayer(int i) { sr.sortingOrder = i; }
    public void assignGridXY(int x, int y) {
        xGrid = x;
        yGrid = y;
    }
    
    public Tuple<int,int> getGridXY()
    {
        return new Tuple<int, int>(xGrid, yGrid);
    }

    public void clickHighlight()
    {
        sr.color = new Color32(0x7B, 0x7B, 0x7B, 0xFF);
    }

    public void dehighlight()
    {
        sr.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
    }
}
