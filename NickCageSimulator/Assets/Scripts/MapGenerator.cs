using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public static MapGenerator MG;
    private void Awake()
    {
        MG = this;
    }

    public GameObject hexPrefab;
    public GameObject plainsPrefab;
    public GameObject forestPrefab;
    public GameObject mountainsPrefab;
    public GameObject riverPrefab;
    public GameObject cityPrefab;
    public GameObject purchasePrefab;

    //TODO NEED TO ADD TO SCENE
    public GameObject forestDepPrefab;
    public GameObject plainsDepPrefab;
    public GameObject mountainsDepPrefab;
    public GameObject RiverDepPrefab;

    public static int width = 16; //using static cuz Random.Range needs it
    public static int height = 17;
    //private float xOffset = .448f;
    //private float yOffset = .766f;
    private float xOffset = 37.7f;// 75.4f;
    private float yOffset = 37.8f;
    private int goldX;
    private int goldY;
    private float mapOffestX = 0;
    private float mapOffestY = 0;

    //for use ONLY when instantiating tiles
    string tileBeingMade;

    private static System.Random rng = new System.Random();

    void Start()
    {
        tileBeingMade = "oops";

        goldX = 1;//TODO REMOVE Random.Range(0, width); 
        goldY = 1; //TODO REMOVE Random.Range(0, height);
        Debug.Log("City of gold: " + goldX + ", " + goldY);

        for (int x=0; x<width; x++)
        {
            for (int y=0; y<height; y++)
            {
                float xPos = x * xOffset*2;
                if (y % 2 == 1) xPos += xOffset; //if an oddRow

                //GameObject temp = Instantiate(hexPrefab, new Vector3(xPos, y * yOffset, 0), Quaternion.identity);
                var tileType = generateRandomBiomeTile();



                GameObject temp = Instantiate(tileType, new Vector3(xPos - mapOffestX, (y * yOffset) - mapOffestY, 0), Quaternion.identity);
                temp.gameObject.tag = "Tile";
                temp.name = temp.name.Substring(0,3) + x + "_" + y;
                TileHandler th = temp.GetComponent<TileHandler>();
                th.typeOfTileName = tileBeingMade;//tell tile what its type is
                th.assignGridXY(x, y);
                th.setOrderInLayer(height - y); 
                if (y == goldY && x == goldX)
                { 
                    th.setAsCityOfGold();
                }
                //Temporary, need to remove this before pushing
                //y==x just as arbitraty way to add random units
               // if (y==x) th.addUnit();
               if(x == 0 && y == 0)
                {
                    th.addUnit();
                }
               /*if (x == 3 && y == 3)
                {
                    th.addEnemy();
                    th.addEnemy();
                }*/
               if (rng.NextDouble() < .1)
                {
                    th.addEnemy();
                }

            }
        }

        //Really hackish UI elements. I would have just used normal UI elements, but I'm no 100% sure how to handle it with git
        Instantiate(purchasePrefab, new Vector3(-60, -60, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int topLayer() { return height; }

    private GameObject generateRandomBiomeTile()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                tileBeingMade = "plains";
                return plainsPrefab;
            case 1:
                tileBeingMade = "river";
                return riverPrefab;
            case 2:
                tileBeingMade = "forest";
                return forestPrefab;
            case 3:
                tileBeingMade = "stone";
                return mountainsPrefab;
            default:
                tileBeingMade = "plains";
                Debug.Log("in the default. something wrong");
                return plainsPrefab;
        }
    }

    public void depletedImage(string t)
    {
        switch(t)
        {
            case "plains":
                //set tile
                break;
            case "river":
                //set tile
                break;
            case "forest":
                //set tile
                break;
            case "stone":
                //set tile
                break;
            default:
                //set tile
                Debug.Log("Something went wrong. In default 2");
                break;
        }

    }

    public void replenishedImage(string t)
    {
        switch (t)
        {
            case "plains":
                //set tile
                break;
            case "river":
                //set tile
                break;
            case "forest":
                //set tile
                break;
            case "stone":
                //set tile
                break;
            default:
                //set tile
                Debug.Log("Something went wrong. In default 3");
                break;
        }

    }
}
