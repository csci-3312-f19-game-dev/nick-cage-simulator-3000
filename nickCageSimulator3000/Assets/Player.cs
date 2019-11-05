using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int wood = 0;
    int stone = 0;
    int water = 0;
    int food = 0;

    List<Unit> units = new List<Unit>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    //Use for picking up and spending resources (negative number)
    public void updateResources(string s, int amount)
    {
        if (s.Equals("wood"))
        {
            wood += amount;
        }

        else if (s.Equals("water"))
        {
            water += amount;
        }

        else if (s.Equals("food"))
        {
            food += amount;
        }

        else
        {
            stone += amount;
        }
    }

    //When units die
    public void removeUnit(Unit u)
    {
        units.Remove(u);
    }

    //When you buy a unit
    void addUnit()
    {
        Unit u = new Unit(); //TODO: pass in type, location
        units.Add(u);
    }
}
