using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackyUnitPurchase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attempt to purchase unit.");
            if (PlayerManager.PM.prevTile != null)
            {
                PlayerManager.PM.purchaseUnit();
                PlayerManager.PM.resetPM();
            }
            else Debug.Log("Please select tile to place new unit on");
        }
    }
}
