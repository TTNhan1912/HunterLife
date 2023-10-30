using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField] 
    private List<InventoryItem> inventoryItems;

    [field: SerializeField]
    public int Size { get; private set; } = 10;

    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for(int i = 0; i < Size; i++)
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
            }

        }
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



}

[SerializeField]
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














