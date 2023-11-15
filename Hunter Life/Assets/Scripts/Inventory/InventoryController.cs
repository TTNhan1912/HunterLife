using Inventory.Model;
using Inventory.UI;
using System;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private UIInventory inventoryUI;

        [SerializeField]
        private InventorySO inventoryData;



        void Start()
        {
            PrepareUI();
            //  inventoryData.Initialize();
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
            throw new NotImplementedException();
        }

        private void HandleSwapItem(int itemIndex_1, int itemIndex_2)
        {
            throw new NotImplementedException();
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
            inventoryUI.UpdateDesciption(itemindex, item.IteamImage, item.name, item.Description);





        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (inventoryUI.isActiveAndEnabled == false)
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
}