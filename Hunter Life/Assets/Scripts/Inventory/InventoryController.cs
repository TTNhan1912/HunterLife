using Inventory.Model;
using Inventory.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private UIInventory inventoryUI;

        [SerializeField]
        private InventorySO inventoryData;

        public List<InventoryItem> initalItems = new List<InventoryItem>();

        private Login login;

        void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in initalItems)
            {
                if (item.IsEmty)
                    continue;
                inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            inventoryUI.ResetAllItem();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.itemSO.IteamImage, item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            inventoryUI.InitInventory(inventoryData.Size);
            inventoryUI.OnDescipttionRequested += HandleDesciptionRequets;
            inventoryUI.OnSwapItem += HandleSwapItem;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnItemActionRequested += HandleItemActionRequets;



        }

        private void HandleItemActionRequets(int itemindex)
        {
            throw new NotImplementedException();
        }

        private void HandleDragging(int itemindex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemindex);

            if (inventoryItem.IsEmty)
                return;


        }

        private void HandleSwapItem(int itemIndex_1, int itemIndex_2)
        {
            inventoryData.SwapItems(itemIndex_1, itemIndex_2);



        }

        private void HandleDesciptionRequets(int itemindex)
        {
            InventoryItem inventoryItem = inventoryData.GetItemAt(itemindex);
            if (inventoryItem.IsEmty)
            {
                inventoryUI.ResetSelection();
                return;

            }

            ItemSO item = inventoryItem.itemSO;
            //  TestModel model;

            inventoryUI.UpdateDesciption(itemindex, item.IteamImage, item.name, item.Description);





        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {

                // GetComponent<Login>().test();
                if (inventoryUI.isActiveAndEnabled == false)
                {
                    inventoryUI.Show();
                    //  login.test();
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
}