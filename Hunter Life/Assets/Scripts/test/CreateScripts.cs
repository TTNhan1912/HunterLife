using Inventory.Model;
using UnityEditor;
using UnityEngine;

public class CreateScripts : MonoBehaviour
{
    public ItemSO itemSO;

    public InventorySO inventoryData;

    public ItemSO yourItemSO;

    [MenuItem("Tools/Create My ScriptableObject")]

    public void CreateMyScriptableObject()
    {

        foreach (TestModel model in Login.testModelAPI)
        {
            Debug.Log($"_id: {model._id}");
            Debug.Log($"Item Name: _id: {model.itemName._id}," +
                $" ItemName: {model.itemName.itemName}, Description: {model.itemName.description}, " +
                $"Consumable: {model.itemName.consumable}, Image: {model.itemName.image}");
            Debug.Log($"Quantity: {model.quantity}");

            // Tạo một ScriptableObject mới
            ItemSO newScriptableObject = ScriptableObject.CreateInstance<ItemSO>();

            newScriptableObject.Name += model.itemName.itemName;
            newScriptableObject.Description += model.itemName.description;


            // Lưu đối tượng vào thư mục Assets
            string assetPath = "Assets/Resources/DataItemAPI/" + model.itemName.itemName + ".asset";
            AssetDatabase.CreateAsset(newScriptableObject, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log(newScriptableObject);

            AddScriptableObjectToInventory(newScriptableObject);


            /*// Kiểm tra xem tham chiếu có tồn tại không
            if (myScriptableObject != null)
            {
                // Gọi hàm Initialize từ InventoryManager và truyền vào ItemSO
                myScriptableObject.Initialize(newScriptableObject);
            }
            else
            {
                Debug.LogError("Tham chiếu đến InventoryManager không tồn tại.");
            }*/



            //    ItemSO myItemSO = newScriptableObject;
            //   InventoryItem myInventoryItem = new InventoryItem(myItemSO, 10);

            //    myScriptableObject.AddItemAPI(newScriptableObject, 2);


            //   Debug.Log(myInventoryItem.itemSO.Name);
            //   Debug.Log(myInventoryItem.itemSO.IteamImage);

            // Chọn đối tượng mới tạo trong Project window
            Selection.activeObject = newScriptableObject;

        }


    }

    private void AddScriptableObjectToInventory(ItemSO itemSO)
    {
        if (inventoryData != null && itemSO != null)
        {
            inventoryData.AddItemSO(itemSO);
        }
        else
        {
            Debug.LogError("Tham chiếu đến InventoryData hoặc ItemSO không tồn tại.");
        }

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            CreateMyScriptableObject();
        }
    }

}
