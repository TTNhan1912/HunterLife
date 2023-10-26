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

    public Sprite image, image2;
    public int quantity;
    public string title,description;

    private int currentlyDraggedItemIndex = -1;

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

    private void HandleShowItemActio(UIInventoryItem inventoryItemUI)
    {
    }

    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {

        mouseFollower.Toggle(false);
        Debug.Log(" tha Click >>>>>>");
    }

    private void HandleSwap(UIInventoryItem inventoryItemUI)
    {
        int index = ListOfUIItem.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            return;
        }
        ListOfUIItem[currentlyDraggedItemIndex]
            .SetData(index == 0 ? image : image2, quantity);
        ListOfUIItem[index]
            .SetData(currentlyDraggedItemIndex == 0 ? image : image2, quantity);
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;



    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = ListOfUIItem.IndexOf(inventoryItemUI);
        if (index == -1) return;
        currentlyDraggedItemIndex = index;

        mouseFollower.Toggle(true);
        mouseFollower.SetData(index == 0 ? image : image2, quantity);
        Debug.Log("Dang keo >>>>>>");
    }

    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        itemDescription.SetDescription(image,title,description);
        ListOfUIItem[0].Select();

    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDiscription();

        ListOfUIItem[0].SetData(image,quantity);
        ListOfUIItem[1].SetData(image2,quantity);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
