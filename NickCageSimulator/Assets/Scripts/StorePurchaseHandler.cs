using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StorePurchaseHandler : MonoBehaviour
{
    public Resource currency;
    public Resource purchasing;

    public void OnMouseDown(){
        Debug.Log("buying" + purchasing + " with " + currency);
        PlayerManager.PM.makePurchase(purchasing, currency);
    }
}
