using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] UIInventoryItem itemPrefabs;

    [SerializeField] RectTransform contenPanel;

    List<UIInventoryItem> ListOfUIItem = new List<UIInventoryItem>();


    public void InitInventory(int inventorysize)
    {
        for(int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefabs,Vector3.zero, Quaternion.identity);
           
            uiItem.transform.SetParent(contenPanel);
            ListOfUIItem.Add(uiItem);
            uiItem.OnItemclick += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseButtonClick += HandleShowItemActio;

        }
    }

    private void HandleShowItemActio(UIInventoryItem obj)
    {
    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
    }

    private void HandleSwap(UIInventoryItem obj)
    {
    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        Debug.Log("Test >>>>>>>>>>");
        Debug.Log(obj.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
