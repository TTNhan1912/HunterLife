using Inventory.Model;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            ItemAPILogin.itemAPI.NewItemInventory(item.InventoryItem.idName, item.Quantity);

            item.DestroyItem();

        }

    }





}
