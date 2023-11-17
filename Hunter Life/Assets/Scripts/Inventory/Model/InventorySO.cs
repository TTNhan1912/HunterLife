using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{

    [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        [field: SerializeField]
        private List<InventoryItem> inventoryItems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;

        public void Initialize()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(InventoryItem.GetEmtyItem());
            }
        }

        public void AddItem(ItemSO itemSO, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmty)
                {
                    inventoryItems[i] = new InventoryItem
                    {
                        itemSO = itemSO,
                        quantity = quantity,
                    };
                    return;
                }

            }
        }

        public void AddItem(InventoryItem item)
        {
            AddItem(item.itemSO, item.quantity);
        }

        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmty)
                    continue;
                returnValue[i] = inventoryItems[i];
            }
            return returnValue;
        }

        public InventoryItem GetItemAt(int itemindex)
        {
            return inventoryItems[itemindex];

        }

        public void SwapItems(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem item1 = inventoryItems[itemIndex_1];
            inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
            inventoryItems[itemIndex_2] = item1;
            InformAboutChange();


        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
        }
    }

    [System.Serializable]
    public struct InventoryItem
    {
        public int quantity;
        public ItemSO itemSO;
        public bool IsEmty => itemSO == null;

        public InventoryItem ChangeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                itemSO = this.itemSO,
                quantity = newQuantity,
            };
        }

        public static InventoryItem GetEmtyItem() => new InventoryItem
        {
            itemSO = null,
            quantity = 0,
        };



    }
}















