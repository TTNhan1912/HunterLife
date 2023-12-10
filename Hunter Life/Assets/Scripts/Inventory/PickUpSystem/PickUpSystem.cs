using Inventory.Model;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        MissionController missioHandler = GetComponent<MissionController>();
        if (item != null)
        {
            ItemAPILogin.itemAPI.NewItemInventory(item.InventoryItem.id, item.Quantity);

            item.DestroyItem();
            missioHandler.Mission4Controller();
        }

    }





}
