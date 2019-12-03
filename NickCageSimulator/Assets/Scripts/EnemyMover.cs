using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float currTime = 0;
    private float enemyMoveRate = 5f;
    private float prevTime0;

    private void Awake()
    {
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
        if (currTime - prevTime0 > enemyMoveRate)
        {
            moveEnemies();
            prevTime0 = currTime;
        }
        currTime += Time.deltaTime;
    }

    public void moveEnemies()
    {
        int h = MapGenerator.height;
        int w = MapGenerator.width;
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        List<int> xList = new List<int>();
        List<int> yList = new List<int>();
        foreach (GameObject tile in tiles)
        {
            List<Enemy> enemies = tile.gameObject.GetComponent<TileHandler>().getEnemies();
            Tuple<int, int> gridXY = tile.gameObject.GetComponent<TileHandler>().getGridXY();
            int xGrid = gridXY.Item1;
            int yGrid = gridXY.Item2;
            int numEnemies = enemies.Count;

            if (numEnemies > 0)
            {
                Debug.Log("(xGrid,yGrid) = (" + xGrid + "," + yGrid + ")");
                Debug.Log(numEnemies + " enemies");
            }


            for (int i = 0; i < numEnemies; i++)
            {
                Enemy enemy = enemies[i];
                int y = 0;
                int x = 0;
                y = UnityEngine.Random.Range(Mathf.Max(0, yGrid - 1), Mathf.Min(h, yGrid + 1) + 1);
                float rand = UnityEngine.Random.Range(0.0f, 1.0f);
                if (y == yGrid)
                {
                    if ((rand < 0.5f && xGrid != 0) || (xGrid == w - 1))
                    {
                        x = xGrid - 1;
                    }
                    else
                    {
                        x = xGrid + 1;
                    }
                }
                else if (yGrid % 2 == 0)
                {
                    if ((rand < 0.5f && xGrid != 0) || (xGrid == w - 1))
                    {
                        x = xGrid - 1;
                    }
                    else
                    {
                        x = xGrid;
                    }
                }
                else
                {
                    if ((rand < 0.5f && xGrid != 0) || (xGrid == w - 1))
                    {
                        x = xGrid;
                    }
                    else
                    {
                        x = xGrid + 1;
                    }
                }
                Debug.Log("(x,y) = (" + x + "," + y + ")");
                xList.Add(x);
                yList.Add(y);
            }

            for (int i = 0; i < numEnemies; i++)
            {
                tile.gameObject.GetComponent<TileHandler>().grabEnemy();
            }                
        }

        Debug.Log("units placed on:");
        for (int i = 0; i < xList.Count; i++)
        {
            Debug.Log("(x,y) = (" + xList[i] + "," + yList[i] + ")");
            foreach (GameObject tile in tiles)
            {
                Tuple<int, int> tileXY = tile.gameObject.GetComponent<TileHandler>().getGridXY();
                int tileX = tileXY.Item1;
                int tileY = tileXY.Item2;
                if (tileX == xList[i] && tileY == yList[i])
                {
                    tile.gameObject.GetComponent<TileHandler>().addEnemy();
                    int numUnitsToKill = tile.gameObject.GetComponent<TileHandler>().numUnits();
                    for (int j = 0; j < numUnitsToKill; j++)
                    {
                        tile.gameObject.GetComponent<TileHandler>().killUnit();
                    }
                }
            }            
        }
    }
}
