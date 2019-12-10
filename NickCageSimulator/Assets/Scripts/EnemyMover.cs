using System;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this class is to move all enemies based on a timer.

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

    void Start()
    {
        
    }

    //Every x time units, move enemies
    void Update()
    {
        if (currTime - prevTime0 > enemyMoveRate)
        {
            moveEnemies();
            prevTime0 = currTime;
        }
        currTime += Time.deltaTime;
    }

    //Place enemies on new tiles
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

                xList.Add(x);
                yList.Add(y);
            }

            for (int i = 0; i < numEnemies; i++)
            {
                tile.gameObject.GetComponent<TileHandler>().grabEnemy();
            }                
        }

        for (int i = 0; i < xList.Count; i++)
        {
            foreach (GameObject tile in tiles)
            {
                Tuple<int, int> tileXY = tile.gameObject.GetComponent<TileHandler>().getGridXY();
                int tileX = tileXY.Item1;
                int tileY = tileXY.Item2;
                if (tileX == xList[i] && tileY == yList[i])
                {
                    tile.gameObject.GetComponent<TileHandler>().addEnemy();

                    //decide whether to kill units or enemies
                    int numUnits = tile.gameObject.GetComponent<TileHandler>().numUnits();
                    int numEnemies = tile.gameObject.GetComponent<TileHandler>().numEnemies();
                    if (numUnits > numEnemies)
                    {
                        for (int j = 0; j < numEnemies; j++)
                        {
                            tile.gameObject.GetComponent<TileHandler>().grabEnemy();
                        }
                    }
                    else
                    {
                        for (int j = 0; j < numUnits; j++)
                        {
                            tile.gameObject.GetComponent<TileHandler>().killUnit();
                        }
                    }                    
                }
            }            
        }
    }
}
