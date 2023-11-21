using System;
using System.Collections.Generic;
using System.Linq;
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

        // ****
        public int AddItem(ItemSO itemSO, int quantity)
        {
            if (itemSO.IsStackable == false)
            {
                for (int i = 0; i < inventoryItems.Count; i++)
                {

                    while (quantity > 0 && IsInventoryFull() == false)
                    {
                        quantity -= AddItemToFirstFreeSlot(itemSO, quantity);
                    }
                    InformAboutChange();
                    return quantity;

                }
            }
            quantity = AddStackAbleItem(itemSO, quantity);
            InformAboutChange();
            return quantity;
        }

        private int AddItemToFirstFreeSlot(ItemSO itemSO, int quantity)
        {
            InventoryItem newItem = new InventoryItem
            {
                itemSO = itemSO,
                quantity = quantity
            };

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmty)
                {
                    inventoryItems[i] = newItem;
                    return quantity;
                }
            }
            return 0;
        }

        private bool IsInventoryFull()
            => inventoryItems.Where(item => item.IsEmty).Any() == false;

        private int AddStackAbleItem(ItemSO itemSO, int quantity)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].IsEmty)
                    continue;
                if (inventoryItems[i].itemSO.ID == itemSO.ID)
                {
                    int amountPossibleTotake =
                        inventoryItems[i].itemSO.MaxStackSize - inventoryItems[i].quantity;

                    if (quantity > amountPossibleTotake)
                    {
                        inventoryItems[i] = inventoryItems[i]
                            .ChangeQuantity(inventoryItems[i].itemSO.MaxStackSize);
                        quantity -= amountPossibleTotake;
                    }
                    else
                    {
                        inventoryItems[i] = inventoryItems[i]
                            .ChangeQuantity(inventoryItems[i].quantity + quantity);
                        InformAboutChange();
                        return 0;
                    }
                }
            }
            while (quantity > 0 && IsInventoryFull() == false)
            {
                int newQuantity = Mathf.Clamp(quantity, 0, itemSO.MaxStackSize);
                quantity -= newQuantity;
                AddItemToFirstFreeSlot(itemSO, newQuantity);
            }
            return quantity;
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















