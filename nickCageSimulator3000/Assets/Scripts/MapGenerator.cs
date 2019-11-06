using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject hexPrefab;
    private int width = 20;
    private int height = 20;
    private float xOffset = .448f;
    private float yOffset = .766f;
    // Start is called before the first frame update
    void Start()
    {
        for (int x=0; x<width; x++)
        {
            for (int y=0; y<height; y++)
            {
                float xPos = x * xOffset*2;
                if (y % 2 == 1) xPos += xOffset; //if an oddRow
                
                Instantiate(hexPrefab, new Vector3(xPos, y * yOffset, 0), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
