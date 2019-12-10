using UnityEngine;

//The purpose of this class is to trigger purchase request from the button
public class StorePurchaseHandler : MonoBehaviour
{
    public Resource currency;
    public Resource purchasing;

    public void OnMouseDown(){
        PlayerManager.PM.makePurchase(purchasing, currency);
    }
}
