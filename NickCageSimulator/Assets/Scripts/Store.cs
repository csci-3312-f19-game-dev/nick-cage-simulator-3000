using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    PlayerManager pm; //= GameObject.FindGameObjectWithTag("PlayerManagerTag");

    //fields updated from pm for display purposes
    int food;// = pm.food;
    int water;
    int wood;
    int stone;
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("PlayerManagerTag").GetComponent<PlayerManager>();
    }

    void Update()
    {
        //food = pm.food;
        //water = pm.water;
        //wood = pm.wood;
        //stone = pm.stone;
    }

    public void buyUnit()
    {
        Debug.Log("attempt to purchase unit from store");
        pm.purchaseUnit();
        food = pm.food;
    }
}
