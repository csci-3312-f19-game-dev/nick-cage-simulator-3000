using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreInventoryDisplay : MonoBehaviour
{
    public Text foodDisplay;
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
    }
}
