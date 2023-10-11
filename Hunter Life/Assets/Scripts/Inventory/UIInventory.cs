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
            

        }
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
