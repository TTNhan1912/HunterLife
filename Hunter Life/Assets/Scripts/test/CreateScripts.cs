using Inventory;
using Inventory.Model;
using UnityEditor;
using UnityEngine;
public class CreateScripts : MonoBehaviour
{
    public ItemSO itemSO;

    public InventorySO inventoryData;

    // public ItemSO newScriptableObject;

    public InventoryController inventoryController;

    [MenuItem("Tools/Create My ScriptableObject")]

    public void CreateMyScriptableObject()
    {

        foreach (TestModel model in Login.testModel)
        {
            Debug.Log($"_id: {model._id}");
            Debug.Log($"Item Name: _id: {model._id}," +
                $" ItemName: {model.itemName.itemName}, Description: {model.itemName.description}, " +
                $" Image: {model}");
            ;

            // Tạo một ScriptableObject mới
            ItemSO newScriptableObject = ScriptableObject.CreateInstance<ItemSO>();

            newScriptableObject.Name += model.itemName.itemName;
            newScriptableObject.Description += model.itemName.description;


            // Lưu đối tượng vào thư mục Assets
            string assetPath = "Assets/Resources/DataItemAPI/" + model.itemName.itemName + ".asset";
            AssetDatabase.CreateAsset(newScriptableObject, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();


            InventoryController inventoryController = FindObjectOfType<InventoryController>();
            if (inventoryController != null)
            {
                inventoryController.newScriptableObjectt = newScriptableObject;
                inventoryController.PrepareInventoryData();
            }

            // Chọn đối tượng mới tạo trong Project window
            Selection.activeObject = newScriptableObject;

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
