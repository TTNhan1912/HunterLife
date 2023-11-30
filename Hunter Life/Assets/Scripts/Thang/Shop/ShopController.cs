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
        // Start is called before the first frame update
        void Start()
        {
            PrepareUI();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void PrepareUI()
        {
            shopUI.InitInventory(inventoryData.Size);
        }
    }
}
