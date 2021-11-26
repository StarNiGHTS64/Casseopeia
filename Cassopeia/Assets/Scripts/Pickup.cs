using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public InventoryCTRL Inventory;
    public GameObject PickedItem;

    void Start(){
        Inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryCTRL>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            for (int i = 0; i < Inventory.Slots.Length; i++)
            {
                if (Inventory.Taken[i] == false)
                 {
                    Inventory.Taken[i] = true;
                    Instantiate(PickedItem, Inventory.Slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                 }  
            }
        }
    }
}
