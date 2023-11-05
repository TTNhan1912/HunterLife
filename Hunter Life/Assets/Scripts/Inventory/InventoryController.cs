using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] 
    private UIInventory inventoryUI;

    [SerializeField]
    private InventorySO inventoryData;


    
    void Start()
    {
        NewMethod();
        //  inventoryData.Initialize();
    }

    private void NewMethod()
    {
        inventoryUI.InitInventory(inventoryData.Size);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.UpdateData(item.Key,
                        item.Value.itemSO.IteamImage,
                        item.Value.quantity);

                }


            }

            else
            {
                inventoryUI.Hide();
               // Time.timeScale = 1;
            }
        }

    }



}
