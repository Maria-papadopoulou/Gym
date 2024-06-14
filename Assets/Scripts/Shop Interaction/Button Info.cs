using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    private void Update()
    {
        ShopManager shopManagerScript = ShopManager.GetComponent<ShopManager>();
        PriceTxt.text = "Price: $" + shopManagerScript.shopItems[1, ItemID - 1].ToString();  // Adjusted to match the array index
        QuantityTxt.text = shopManagerScript.shopItems[2, ItemID - 1].ToString();  // Adjusted to match the array index
    }
}
