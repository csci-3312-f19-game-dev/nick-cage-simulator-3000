using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    
    private SpriteRenderer sr;
    private int unitCount = 0; //Each tile starts out with no units
    private List<Unit> units = new List<Unit> ();
    public GameObject defaultUnit;

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
            if (Input.GetKey(KeyCode.LeftShift)) Debug.Log("Down");
            if (Input.GetKey(KeyCode.LeftShift)) PlayerManager.PM.tileClicked(this, true);
            else PlayerManager.PM.tileClicked(this, false);
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
        Unit newUnit = Instantiate(defaultUnit, transform).GetComponent<Unit>();
        units.Add(newUnit);
    }

    public Unit grabUnit()
    {
        Unit temp = units[0];
        units.RemoveAt(0);
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
        Unit u = units[0];
        units.RemoveAt(0);
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

}
