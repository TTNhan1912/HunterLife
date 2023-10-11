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
            uiItem.OnItemclick += HandleBeginDrag;
            uiItem.OnItemclick += HandleSwap;
            uiItem.OnItemclick += HandleEndDrag;
            uiItem.OnItemclick += HandleShowItemActio;

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
