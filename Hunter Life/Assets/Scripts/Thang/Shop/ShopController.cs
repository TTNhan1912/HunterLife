using Inventory.UI;
using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inventory
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField]
        private UIShopScript shopUI;

        [SerializeField]
        private InventorySO inventoryData;

        public List<InventoryItem> initalItems = new List<InventoryItem>();

        private bool isCollide = false;
        // Start is called before the first frame update
        void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (shopUI.isActiveAndEnabled == false && isCollide == true)
                {
                    shopUI.Show();
                    //  login.test();
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
                    isCollide = false;
                    // Time.timeScale = 1;
                }
            }
        }

        private void PrepareInventoryData()
        {
            inventoryData.Initialize();
            inventoryData.OnInventoryUpdated += UpdateShopUI;
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
                shopUI.UpdateData(item.Key, item.Value.itemSO.IteamImage, item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            shopUI.InitInventory(inventoryData.Size);
        }

        private void UpdateShopUI(Dictionary<int, InventoryItem> inventoryState)
        {
            foreach (var item in inventoryState)
            {
                shopUI.UpdateData(item.Key, item.Value.itemSO.IteamImage, item.Value.quantity);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("browseStock"))
            {
                isCollide = true;
                Debug.Log("ISCOLLIDE");
            }
        }
    }
}
