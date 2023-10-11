using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] 
    private UIInventory inventoryUI;

    private int inventorysize = 20;
    
    void Start()
    {
        inventoryUI.InitInventory(inventorysize);    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                Time.timeScale = 0;
            }
            else
            {
                inventoryUI.Hide();
                Time.timeScale = 1;
            }
        }

    }



}
