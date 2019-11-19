using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject storeScreen;
    public GameObject brokenPurchaseButton;
    // Start is called before the first frame update
    void Start()
    {
        //storeScreen.GetComponent<Renderer>().enabled = false;
        storeScreen.SetActive(false);
        //brokenPurchaseButton.GetComponent<Renderer>().enabled = false;
        PlayerManager.StoreMenuIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        //storeScreen.GetComponent<Renderer>().enabled = !isOpen;
        //brokenPurchaseButton.GetComponent<Renderer>().enabled = !isOpen;
        storeScreen.SetActive(!PlayerManager.StoreMenuIsOpen);
        PlayerManager.StoreMenuIsOpen = !PlayerManager.StoreMenuIsOpen;
    }
}
