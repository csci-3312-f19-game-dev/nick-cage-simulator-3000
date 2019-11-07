using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject hexPrefab;
    public GameObject purchasePrefab;

    private static int width = 20; //using static cuz Random.Range needs it
    private static int height = 20;
    private float xOffset = .448f;
    private float yOffset = .766f;
    private int goldX;
    private int goldY;
    // Start is called before the first frame update
    void Start()
    {
        goldX = 2; //Random.Range(0, width); 
        goldY = 2; //Random.Range(0, height);
        Debug.Log("City of gold: " + goldX + ", " + goldY);

        for (int x=0; x<width; x++)
        {
            for (int y=0; y<height; y++)
            {
                float xPos = x * xOffset*2;
                if (y % 2 == 1) xPos += xOffset; //if an oddRow
                GameObject temp = Instantiate(hexPrefab, new Vector3(xPos, y * yOffset, 0), Quaternion.identity);
                temp.name = "Hex_" + x + "_" + y;
                if (y == goldY && x == goldX)
                {
                    TileHandler th = temp.GetComponent<TileHandler>();
                    th.setAsCityOfGold();
                }
            }
        }

        //Really hackish UI elements. I would have just used normal UI elements, but I'm no 100% sure how to handle it with git
        Instantiate(purchasePrefab, new Vector3(-1, -1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
