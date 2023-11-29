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
        public InventoryController inventoryController;

        public ItemSO newScriptableObjectt;

        public List<InventoryItem> initalItems = new List<InventoryItem>();
        // public List<InventoryAPI> initalItemsAPI = new List<InventoryAPI>();

        public Login login { get; private set; }
        public ItemSO itemSO;


        void Start()
        {
            PrepareUI();
            PrepareInventoryData();

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
                    quantity = 1 // Số lượng bạn muốn thêm vào danh sách
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
            inventoryUI.ResetAllItem();
            foreach (var item in inventoryState)
            {
                inventoryUI.UpdateData(item.Key, item.Value.itemSO.IteamImage, item.Value.quantity);
            }
        }
        private void UpdateInventoryUIAPI(Dictionary<int, InventoryAPI> inventoryStatee)
        {
            inventoryUI.ResetAllItem();
            foreach (var item in inventoryStatee)
            {
                inventoryUI.UpdateData(item.Key, item.Value.itemSOAPI.IteamImageAPI, item.Value.quantityAPI);
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

        public void LayAPI()
        {
            foreach (TestModel model in Login.testModelAPI)
            {
                Debug.Log($"_id: {model._id}");
                Debug.Log($"Item Name: _id: {model.itemName._id}," +
                    $" ItemName: {model.itemName.itemName}, Description: {model.itemName.description}, " +
                    $"Consumable: {model.itemName.consumable}, Image: {model.itemName.image}");
                Debug.Log($"Quantity: {model.quantity}");


            }

        }

        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.I))
            {

                PrepareInventoryData();

            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
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