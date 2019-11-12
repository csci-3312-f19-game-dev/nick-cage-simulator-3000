﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject hexPrefab;
    public GameObject plainsPrefab;
    public GameObject forestPrefab;
    public GameObject mountainsPrefab;
    public GameObject riverPrefab;
    public GameObject cityPrefab;
    public GameObject purchasePrefab;

    private static int width = 17; //using static cuz Random.Range needs it
    private static int height = 17;
    //private float xOffset = .448f;
    //private float yOffset = .766f;
    private float xOffset = 37.7f;// 75.4f;
    private float yOffset = 37.8f;
    private int goldX;
    private int goldY;
    private float mapOffestX = 0;
    private float mapOffestY = 0;
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

                //GameObject temp = Instantiate(hexPrefab, new Vector3(xPos, y * yOffset, 0), Quaternion.identity);
                var tileType = generateRandomBiomeTile();
                GameObject temp = Instantiate(tileType, new Vector3(xPos - mapOffestX, (y * yOffset) - mapOffestY, 0), Quaternion.identity);
                temp.name = temp.name.Substring(0,3) + x + "_" + y;
                TileHandler th = temp.GetComponent<TileHandler>();
                th.setOrderInLayer(height - y); 
                if (y == goldY && x == goldX)
                { 
                    th.setAsCityOfGold();
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

    private GameObject generateRandomBiomeTile()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0: return plainsPrefab;
            case 1: return riverPrefab;
            case 2: return forestPrefab;
            case 3: return mountainsPrefab;
            default: return plainsPrefab;
        }
    }
}
