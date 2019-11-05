using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * THIS CLASS WAS CREATED WHILE WAITING FOR THE TILE MAP TO BE CREATED,
 * AS A GUIDE FOR METHODS THE ACTUAL TILE SHOULD HAVE AS WELL AS TO HELP
 * THE PROJECT COMPILE UNTIL WE GET TO THAT POINT. THE FINISHED PROJECT
 * SHOULD NOT CONTAIN THIS CLASS.
 */

public class Tile : MonoBehaviour
{
    bool resAvail;
    // Start is called before the first frame update
    void Start()
    {
        resAvail = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool resourcesAvailable()
    {
        return resAvail;
    }

    public int getResources()
    {
        return 7;
    }

    public string getType()
    {
        return "wood";
    }
}
