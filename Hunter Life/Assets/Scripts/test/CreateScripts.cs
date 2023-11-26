using Inventory.Model;
using UnityEditor;
using UnityEngine;

public class CreateScripts : MonoBehaviour
{
    public ItemSO itemSO;

    [MenuItem("Tools/Create My ScriptableObject")]
    private static void CreateMyScriptableObject()
    {
        // Tạo một ScriptableObject mới
        ItemSO newScriptableObject = ScriptableObject.CreateInstance<ItemSO>();



        // Lưu đối tượng vào thư mục Assets
        string assetPath = "Assets/Resources/DataItem/NewData.asset";
        AssetDatabase.CreateAsset(newScriptableObject, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        // Chọn đối tượng mới tạo trong Project window
        Selection.activeObject = newScriptableObject;



    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            CreateMyScriptableObject();
        }
    }

}
