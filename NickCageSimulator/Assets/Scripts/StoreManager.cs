using UnityEngine;
using UnityEngine.UI;

//The purpose of this class is to handle buying and selling
public class StoreManager : MonoBehaviour
{
    public static StoreManager SM;

    public GameObject StoreScreen;
    public GameObject DisplayPanel;
    public Text WoodToFoodDisplay;
    public Text StoneToFoodDisplay;
    public Text WaterToFoodDisplay;
    public Text StoneToWoodDisplay;
    public Text WaterToWoodDisplay;
    public Text FoodToWoodDisplay;
    public Text WaterToStoneDisplay;
    public Text FoodToStoneDisplay;
    public Text WoodToStoneDisplay;
    public Text FoodToWaterDisplay;
    public Text WoodToWaterDisplay;
    public Text StoneToWaterDisplay;
    public Text FoodToUnitsDisplay;
    public static int WoodToFoodPrice;
    public static int StoneToFoodPrice;
    public static int WaterToFoodPrice;
    public static int StoneToWoodPrice;
    public static int WaterToWoodPrice;
    public static int FoodToWoodPrice;
    public static int WaterToStonePrice;
    public static int FoodToStonePrice;
    public static int WoodToStonePrice;
    public static int FoodToWaterPrice;
    public static int WoodToWaterPrice;
    public static int StoneToWaterPrice;
    public static int FoodToUnitsPrice;
    public static int StoneToSafetyTilePrice;

    public bool currentlyPlacingBoughtTiles;

    void Start()
    {
        SM = this;
        StoreScreen.SetActive(false);
        DisplayPanel.SetActive(false);
        PlayerManager.StoreMenuIsOpen = false;
        WoodToFoodPrice = 2;
        StoneToFoodPrice = 2;
        WaterToFoodPrice = 2;
        StoneToWoodPrice = 2;
        WaterToWoodPrice = 2;
        FoodToWoodPrice = 2;
        WaterToStonePrice = 2;
        FoodToStonePrice = 2;
        WoodToStonePrice = 2;
        FoodToWaterPrice = 2;
        WoodToWaterPrice = 2;
        StoneToWaterPrice = 2;
        FoodToUnitsPrice = 5;
        StoneToSafetyTilePrice = 5;

        currentlyPlacingBoughtTiles = false;

        updatePriceDisplays();
    }

    void Update()
    {
    }

    private void updatePriceDisplays()
    {
        WoodToFoodDisplay.text = "" + WoodToFoodPrice;
        StoneToFoodDisplay.text = "" + StoneToFoodPrice;
        WaterToFoodDisplay.text = "" + WaterToFoodPrice;
        StoneToWoodDisplay.text = "" + StoneToWoodPrice;
        WaterToWoodDisplay.text = "" + WaterToWoodPrice;
        FoodToWoodDisplay.text = "" + FoodToWoodPrice;
        WaterToStoneDisplay.text = "" + WaterToStonePrice;
        FoodToStoneDisplay.text = "" + FoodToStonePrice;
        WoodToStoneDisplay.text = "" + WoodToStonePrice;
        FoodToWaterDisplay.text = "" + FoodToWaterPrice;
        WoodToWaterDisplay.text = "" + WoodToWaterPrice;
        StoneToWaterDisplay.text = "" + StoneToWaterPrice;
        FoodToUnitsDisplay.text = "" + FoodToUnitsPrice;
    }

    public void toggleShopMenu()
    {
        MusicContainer.MC.playSound(0);
        StoreScreen.SetActive(!PlayerManager.StoreMenuIsOpen);
        DisplayPanel.SetActive(!PlayerManager.StoreMenuIsOpen);
        PlayerManager.StoreMenuIsOpen = !PlayerManager.StoreMenuIsOpen;
    }

    public void placingTilesMode() //TODO MADDIE: Call this method from wherever the safety tile purchase button is, then call again when safety tile is placed
    {
        StoreScreen.SetActive(!PlayerManager.StoreMenuIsOpen);
        DisplayPanel.SetActive(!PlayerManager.StoreMenuIsOpen);
        currentlyPlacingBoughtTiles = !currentlyPlacingBoughtTiles;
    }

    public void pauseGame()
    {
        Debug.Log("Game pause hit");
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }
    }
    
    //Displays how much each resource costs at this point
    public static int getCurrentExchangePrice(Resource purchasing, Resource currency)
    {
        switch (purchasing)
        {
            case Resource.Food:
                switch (currency)
                {
                    case Resource.Stone:
                        return StoneToFoodPrice;
                    case Resource.Water:
                        return WaterToFoodPrice;
                    case Resource.Wood:
                        return WoodToFoodPrice;
                    default:
                        break;
                }
                break;
            case Resource.Stone:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToStonePrice;
                    case Resource.Water:
                        return WaterToStonePrice;
                    case Resource.Wood:
                        return WoodToStonePrice;
                    default:
                        break;
                }
                break;
            case Resource.Units:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToUnitsPrice;
                    default:
                        break;
                }
                break;
            case Resource.SafetyTile:
                switch (currency)
                {
                    case Resource.Stone:
                        return StoneToSafetyTilePrice;
                    default:
                        break;
                }
                break;
            case Resource.Water:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToWaterPrice;
                    case Resource.Stone:
                        return StoneToWaterPrice;
                    case Resource.Wood:
                        return WoodToWaterPrice;
                    default:
                        break;
                }
                break;
            case Resource.Wood:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToWoodPrice;
                    case Resource.Water:
                        return WaterToWoodPrice;
                    case Resource.Stone:
                        return StoneToWoodPrice;
                    default:
                        break;
                }
                break;
        }
        return -1;
    }

}

public enum Resource
{
    Wood,
    Food,
    Water,
    Units,
    Stone,
    SafetyTile
}
