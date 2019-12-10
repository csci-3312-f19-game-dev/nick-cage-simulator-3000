using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//The purpose of this class is to handle tile information for each instance
public class TileHandler : MonoBehaviour
{
    private SpriteRenderer sr;
    private int unitCount = 0; //Each tile starts out with no units
    private List<Unit> units = new List<Unit>();
    private int enemyCount = 0; //Each tile starts out with no enemies
    private List<Enemy> enemies = new List<Enemy>();
    public GameObject defaultUnit;
    public GameObject defaultEnemy;
    public string typeOfTileName;
    private bool depleted;
    private float currTime = 0;
    private float enemyMoveRate = 5f;
    private float prevTime0;

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
        Time.timeScale = 1f;
        prevTime0 = Time.time;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    //Temporarily deplete a tile of its resources
    public void deplete()
    {
        depleted = true;

        if (!isCityOfGold)
        {
            switch (typeOfTileName)
            {
                case "plains":
                    changeSprite(MapGenerator.MG.plainsDepPath);
                    break;
                case "river":
                    changeSprite(MapGenerator.MG.riverDepPath);
                    break;
                case "forest":
                    changeSprite(MapGenerator.MG.forestDepPath);
                    break;
                case "stone":
                    changeSprite(MapGenerator.MG.mountainsDepPath);
                    break;
                default:
                    changeSprite(MapGenerator.MG.plainsDepPath);
                    Debug.Log("Error. In TileHandler/deplete()");
                    break;
            }
        }       

        Time.timeScale = 1;
        StartCoroutine("ResourceRegeneration");
    }

    //Add delay between depletion and regeneration
    IEnumerator ResourceRegeneration()
    {
        yield return new WaitForSeconds(20);
        if (!isCityOfGold) replenish();
    }

    //Regenerate tile resources
    void replenish()
    {
        switch (typeOfTileName)
        {
            case "plains":
                changeSprite(MapGenerator.MG.plainsPath);
                break;
            case "river":
                changeSprite(MapGenerator.MG.riverPath);
                break;
            case "forest":
                changeSprite(MapGenerator.MG.forestPath);
                break;
            case "stone":
                changeSprite(MapGenerator.MG.mountainsPath);
                break;
            default:
                changeSprite(MapGenerator.MG.plainsPath);
                Debug.Log("Error. In TileHandler/replenish()");
                break;
        }
        depleted = false;
    }

    //Tells whether or not this tile is depleted
    public bool isDepleted()
    {
        return depleted;
    }

    //Transition tile to safety tile
    public void makeSafetyTile()
    {
        depleted = true;
        changeSprite(MapGenerator.MG.safetySprite);
    }

    //Handle mouse input for tiles
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
    
    //Tells if this tile is the city of gold
    public void setAsCityOfGold()
    {
        isCityOfGold = true;
    }

    //Display city when tile is stepped on (if applicable)
    void displayCityOfGold()
    {
        sr.sprite = SpriteContainer.SC.cityOfGold; //TODO need to adjust the polygon collider to match the new sprite ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }   

    //Place unit on tile
    public void addUnit()
    {        
        Unit newUnit = Instantiate(defaultUnit, transform).GetComponent<Unit>();
        units.Add(newUnit);
        unitCount += 1;
        newUnit.setTile(this, transform);
    }

    //Place enemy on tile
    public void addEnemy()
    {
        Enemy newEnemy = Instantiate(defaultEnemy, transform).GetComponent<Enemy>();
        enemies.Add(newEnemy);
        enemyCount += 1;
        newEnemy.setTile(this, transform);
    }

    //Remove unit from tile
    public Unit grabUnit()
    {
        Unit temp = units[unitCount-1];
        units.RemoveAt(unitCount-1);
        unitCount -= 1;
        return temp;
    }

    //Remove enemy from tile
    public void grabEnemy()
    {
        Enemy temp = enemies[enemyCount - 1];
        enemies.RemoveAt(enemyCount - 1);
        enemyCount -= 1;
        Destroy(temp.gameObject);
    }

    //Move unit from one tile to another
    public void transferUnit(Unit u)
    {
        Debug.Log("EDITOR NOTE: transferring unit");
        units.Add(u);
        unitCount += 1;
        u.setTile(this, transform);
        MoveUnitSound();
        if (isCityOfGold)
        {
            Debug.Log("PLAYER NEEDS TO SEE: Congrats, you have found the city of gold!");
            displayCityOfGold();
            
            if (unitCount >= PlayerManager.PM.unitsToWin && PlayerManager.PM.stone >= PlayerManager.PM.stoneToWin && PlayerManager.PM.water >= PlayerManager.PM.waterToWin && PlayerManager.PM.wood >= PlayerManager.PM.woodToWin) {
                Debug.Log("PLAYER NEEDS TO SEE: Congrats, you have successfully excavated the city of gold!");                
                GameManager.GM.endSceneString = "You Won!";
                GameManager.GM.ChangeScene();
            }
            else
            {
                Debug.Log("PLAYER NEEDS TO SEE: You need more resources to excavate the city of gold.");
            }
        }
    }

    public void MoveUnitSound()
    {
        switch (typeOfTileName)
        {
            case "plains":
                MusicContainer.MC.playSound(3);
                break;
            case "river":
                MusicContainer.MC.playSound(10);
                break;
            case "forest":
                MusicContainer.MC.playSound(11);
                break;
            case "stone":
                //changeSprite(MapGenerator.MG.mountainsDepPath);
                break;
            default:
                //changeSprite(MapGenerator.MG.plainsDepPath);
                //Debug.Log("Error. In TileHandler/deplete()");
                break;
        }
    }

    //Kill a unit
    public void killUnit()
    {
        Unit u = units[unitCount-1];
        units.RemoveAt(unitCount-1);
        unitCount -= 1;
        Destroy(u.gameObject);        
    }
    
    public int numUnits() {
        return unitCount;
    }
    public int numEnemies()
    {
        return enemyCount;
    }
    public List<Enemy> getEnemies()
    {
        return enemies;
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

    public void changeSprite(String s)
    {
        Debug.Log("inchangesprite");
        sr.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(s);
    }
}
