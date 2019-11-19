using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreInventoryDisplay : MonoBehaviour
{
    public Text foodDisplay;
    public Text stoneDisplay;
    public Text waterDisplay;
    public Text woodDisplay;
    PlayerManager pm;
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("PlayerManagerTag").GetComponent<PlayerManager>();
        foodDisplay.text = "No food yet.";
    }

    // Update is called once per frame
    void Update()
    {
        foodDisplay.text = ("" + pm.food);
        stoneDisplay.text = ("" + pm.stone);
        woodDisplay.text = ("" + pm.wood);
        waterDisplay.text = ("" + pm.water);
    }
}
