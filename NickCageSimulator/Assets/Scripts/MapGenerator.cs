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

    //TODO NEED TO ADD TO SCENE
    public GameObject forestDepPrefab;
    public GameObject plainsDepPrefab;
    public GameObject mountainsDepPrefab;
    public GameObject riverDepPrefab;

    //String Paths of depleted sprites
    public string forestDepPath;
    public string plainsDepPath;
    public string mountainsDepPath;
    public string riverDepPath;

    public string forestPath;
    public string plainsPath;
    public string mountainsPath;
    public string riverPath;

    public string safetySprite;

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
        forestDepPath = "Assets/Sprites/ForestDepleted.png";
        plainsDepPath = "Assets/Sprites/PlainsDepleted.png";
        mountainsDepPath = "Assets/Sprites/MountainDepleted.png";
        riverDepPath = "Assets/Sprites/RiverDepleted.png";

        forestPath = "Assets/Sprites/Forest.png";
        plainsPath = "Assets/Sprites/Plains.png";
        mountainsPath = "Assets/Sprites/Mountain.png";
        riverPath = "Assets/Sprites/River.png";

        //MADDIE TODO: put path to sprite asset here
        //safetySprite = "Assets/Sprites/.............."

        //DELETE ME, MADDIE
        safetySprite = "Assets/Sprites/CityOfGold.png"; //PLACEHOLDER ONLY /////////////////////////////////////////////////////////////////////////////////////////////////


    tileBeingMade = "oops";

        goldX = Random.Range(0, width); 
        goldY = Random.Range(0, height);
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
}
