using UnityEngine;
using UnityEngine.UI;

//The purpose of this class is to display the player's resource inventory at the bottom of the screen.
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

    void Update()
    {
        foodDisplay.text = ("" + pm.food);
        stoneDisplay.text = ("" + pm.stone);
        woodDisplay.text = ("" + pm.wood);
        waterDisplay.text = ("" + pm.water);
    }
}
