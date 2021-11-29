using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCTRL : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject[] Slots;
    public bool[] Taken;

    public void openInventory()
    { 
        Inventory.SetActive(!Inventory.activeSelf);
    }
    
}
