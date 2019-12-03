using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{

    private SpriteRenderer sr;
    private int unitCount = 0; //Each tile starts out with no units
    private List<Unit> units = new List<Unit>();
    private int enemyCount = 0; //Each tile starts out with no anemonies
    private List<Enemy> enemies = new List<Enemy>();
    public GameObject defaultUnit;
    public GameObject defaultEnemy;
    public String typeOfTileName;
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
        Debug.Log("IN DEPLETED");
        depleted = true;
        //TODO change image
        // MapGenerator.MG.depletedImage(typeOfTileName);

        switch (typeOfTileName)
        {
            case "plains":
                changeSprite(MapGenerator.MG.plainsDepPrefab);
                break;
            case "river":
                changeSprite(MapGenerator.MG.riverDepPrefab);
                break;
            case "forest":
                changeSprite(MapGenerator.MG.forestDepPrefab);
                break;
            case "stone":
                changeSprite(MapGenerator.MG.mountainsDepPrefab);
                break;
            default:
                changeSprite(MapGenerator.MG.plainsDepPrefab);
                Debug.Log("Something went wrong. In default 2");
                break;
        }

        Time.timeScale = 1;
        StartCoroutine("ResourceRegeneration");
    }

    IEnumerator ResourceRegeneration()
    {
        yield return new WaitForSeconds(20);
        replenish();
    }

    void replenish()
    {
        switch (typeOfTileName)
        {
            case "plains":
                changeSprite(MapGenerator.MG.plainsPrefab);
                break;
            case "river":
                changeSprite(MapGenerator.MG.riverPrefab);
                break;
            case "forest":
                changeSprite(MapGenerator.MG.forestPrefab);
                break;
            case "stone":
                changeSprite(MapGenerator.MG.mountainsPrefab);
                break;
            default:
                changeSprite(MapGenerator.MG.plainsPrefab);
                Debug.Log("Something went wrong. In default 2");
                break;
        }
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

    public void addEnemy()
    {
        Enemy newEnemy = Instantiate(defaultEnemy, transform).GetComponent<Enemy>();
        enemies.Add(newEnemy);
        enemyCount += 1;
        newEnemy.setTile(this, transform);
    }

    public Unit grabUnit()
    {
        Unit temp = units[unitCount-1];
        units.RemoveAt(unitCount-1);
        unitCount -= 1;
        return temp;
    }

    public void grabEnemy()
    {
        Enemy temp = enemies[enemyCount - 1];
        enemies.RemoveAt(enemyCount - 1);
        enemyCount -= 1;
        Destroy(temp.gameObject);
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
            //MOVE INTO WIN STATE BELOW, EVENTUALLY
                //GameManager.GM.endSceneText.text = "You Won!";
                GameManager.GM.endSceneString = "You Won!";
                GameManager.GM.ChangeScene();
            if (unitCount >= PlayerManager.PM.unitsToWin) Debug.Log("Congrats, you have successfully excavated the city of gold!");
        }
    }

    public void killUnit()
    {
        Unit u = units[unitCount-1];
        units.RemoveAt(unitCount-1);
        unitCount -= 1;
        Destroy(u.gameObject);        

        /*if(unitCount == 0)
        {
            //GameManager.GM.endSceneText.text = "GAME OVER.";
            GameManager.GM.endSceneString = "GAME OVER";
            GameManager.GM.ChangeScene();
        }*/
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

    public void changeSprite(GameObject g)
    {
        Debug.Log("inchangesprite");
        //sr.sprite = g.GetComponent<Sprite>();
    }
}
