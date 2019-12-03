using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class StoreManager : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
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
        updatePriceDisplays();
    }

    // Update is called once per frame
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
        StoreScreen.SetActive(!PlayerManager.StoreMenuIsOpen);
        DisplayPanel.SetActive(!PlayerManager.StoreMenuIsOpen);
        PlayerManager.StoreMenuIsOpen = !PlayerManager.StoreMenuIsOpen;
    }

    public static int getCurrentExchangePrice(Resource purchasing, Resource currency)
    {
        switch (purchasing)
        {
            case Resource.Food:
                switch (currency)
                {
                    case Resource.Stone:
                        return StoneToFoodPrice;
                        break;
                    case Resource.Water:
                        return WaterToFoodPrice;
                        break;
                    case Resource.Wood:
                        return WoodToFoodPrice;
                        break;
                    default:
                        break;
                }
                break;
            case Resource.Stone:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToStonePrice;
                        break;
                    case Resource.Water:
                        return WaterToStonePrice;
                        break;
                    case Resource.Wood:
                        return WoodToStonePrice;
                        break;
                    default:
                        break;
                }
                break;
            case Resource.Units:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToUnitsPrice;
                        break;
                    default:
                        break;
                }
                break;
            case Resource.Water:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToWaterPrice;
                        break;
                    case Resource.Stone:
                        return StoneToWaterPrice;
                        break;
                    case Resource.Wood:
                        return WoodToWaterPrice;
                        break;
                    default:
                        break;
                }
                break;
            case Resource.Wood:
                switch (currency)
                {
                    case Resource.Food:
                        return FoodToWoodPrice;
                        break;
                    case Resource.Water:
                        return WaterToWoodPrice;
                        break;
                    case Resource.Stone:
                        return StoneToWoodPrice;
                        break;
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
    Stone
}
