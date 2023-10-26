using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
    
public class UIInventory : MonoBehaviour
{
    [SerializeField] UIInventoryItem itemPrefabs;

    [SerializeField] RectTransform contenPanel;

    [SerializeField]
    private UIInventoryDescription itemDescription;

    [SerializeField]
    private MouseFollower mouseFollower;

    List<UIInventoryItem> ListOfUIItem = new List<UIInventoryItem>();

    public Sprite image;
    public int quantity;
    public string title,description;


    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDiscription();
    }

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
        mouseFollower.Toggle(false);
        Debug.Log(" tha Click >>>>>>");
    }

    private void HandleSwap(UIInventoryItem obj)
    {
    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(image, quantity);
        Debug.Log("Dang keo >>>>>>");
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        itemDescription.SetDescription(image,title,description);
        ListOfUIItem[0].Select();

    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDiscription();

        ListOfUIItem[0].SetData(image,quantity);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
