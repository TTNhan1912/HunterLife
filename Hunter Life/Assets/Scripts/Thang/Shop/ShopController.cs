﻿using System;
using Inventory.Model;
using Shop.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private UIShop shopUI;

    [SerializeField]
    public InventorySO inventoryData;
    public ShopController shopController;

    public ItemSO newScriptableObjectt;

    public List<InventoryItem> initalItems = new List<InventoryItem>();

    public Login login { get; private set; }
    public ItemSO itemSO;

    private bool browseStock;


    // Start is called before the first frame update
    void Start()
    {
        browseStock = false;
        PrepareUI();
        PrepareInventoryData();
    }

    // Update is called once per frame
    void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.X))
        {
            PrepareInventoryData();
            if (shopUI.isActiveAndEnabled == false && browseStock == true)
            {
                shopUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    shopUI.UpdateData(item.Key,
                      item.Value.itemSO.IteamImage,
                      item.Value.quantity);
                }
            }
            else
            {
                shopUI.Hide();
                browseStock = false;
                // Time.timeScale = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interact"))
        {
            browseStock = true;
        }
    }


    public void PrepareInventoryData()
    {
        inventoryData.Initialize();
        inventoryData.OnInventoryUpdated += UpdateInventoryUI;


        // Kiểm tra và thêm newScriptableObject vào danh sách
        if (newScriptableObjectt != null)
        {
            // Tạo một InventoryItem mới và thêm vào danh sách
            InventoryItem newItem = new InventoryItem
            {
                itemSO = newScriptableObjectt,
                quantity = newScriptableObjectt.quantity, // Số lượng bạn muốn thêm vào danh sách
            };

            initalItems.Add(newItem);
        }

        foreach (InventoryItem item in initalItems)
        {
            if (item.IsEmty)
                continue;
            inventoryData.AddItem(item);
        }

    }

    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        shopUI.ResetAllItem();
        foreach (var item in inventoryState)
        {
            shopUI.UpdateData(item.Key, item.Value.itemSO.IteamImage, item.Value.price);
        }
    }
    private void UpdateInventoryUIAPI(Dictionary<int, InventoryAPI> inventoryStatee)
    {
        shopUI.ResetAllItem();
        foreach (var item in inventoryStatee)
        {
            shopUI.UpdateData(item.Key, item.Value.itemSOAPI.IteamImageAPI, item.Value.priceAPI);
        }
    }

    private void PrepareUI()
    {
        shopUI.InitInventory(inventoryData.Size);
        shopUI.OnDescipttionRequested += HandleDesciptionRequets;
        shopUI.OnItemActionRequested += HandleItemActionRequets;



    }

    private void HandleItemActionRequets(int itemindex)
    {
        throw new NotImplementedException();
    }



    private void HandleDesciptionRequets(int itemindex)
    {
        InventoryItem inventoryItem = inventoryData.GetItemAt(itemindex);
        if (inventoryItem.IsEmty)
        {
            shopUI.ResetSelection();
            return;

        }

        ItemSO item = inventoryItem.itemSO;
        //  TestModel model;

        shopUI.UpdateDesciption(itemindex, item.IteamImage, item.Name, item.Description, item.price);
    }
}