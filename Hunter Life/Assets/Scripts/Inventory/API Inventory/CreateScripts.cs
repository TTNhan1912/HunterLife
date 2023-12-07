﻿using Inventory;
using Inventory.Model;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class CreateScripts : MonoBehaviour
{
    public ItemSO itemSO;

    public InventorySO inventoryData;

    public InventoryController inventoryController;


    public Sprite spriteRenderer;

    public static CreateScripts createScriptsIntance;



    [MenuItem("Tools/Create My ScriptableObject")]

    public void CreateMyScriptableObject()
    {
        StartCoroutine(LoadImageSprite());


    }

    IEnumerator LoadImageSprite()
    {
        InventoryController inventoryController = FindObjectOfType<InventoryController>();
        if (inventoryController != null)
        {
            // xóa dữ liệu túi đồ cũ
            inventoryController.initalItems.Clear();


            foreach (TestModel model in Login.testModel)
            {

                // Tạo một ScriptableObject mới
                ItemSO newScriptableObject = ScriptableObject.CreateInstance<ItemSO>();

                using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(model.itemName.image))
                {
                    yield return www.SendWebRequest();

                    if (www.result == UnityWebRequest.Result.Success)
                    {
                        // Tạo một sprite từ texture tải về
                        Texture2D texture = DownloadHandlerTexture.GetContent(www);
                        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                        // Gán sprite trực tiếp vào SpriteRenderer
                        spriteRenderer = sprite;
                        newScriptableObject.id += model._id;
                        newScriptableObject.Name += model.itemName.itemName;
                        newScriptableObject.Description += model.itemName.description;
                        newScriptableObject.itemImage = model.itemName.image;
                        newScriptableObject.IteamImage = spriteRenderer;
                        newScriptableObject.quantity += model.quantity;
                        newScriptableObject.price += model.itemName.price;


                        // Hoặc gán sprite trực tiếp vào một Sprite khác (không thông qua SpriteRenderer)
                        // this.GetComponent<SpriteRenderer>().sprite = sprite;
                    }
                    else
                    {
                        Debug.Log("Error loading image: " + www.error);
                    }
                }

                // Lưu đối tượng vào thư mục Assets
                string assetPath = "Assets/Resources/DataItemAPI/" + model.itemName.itemName + ".asset";
                AssetDatabase.CreateAsset(newScriptableObject, assetPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();


                //InventoryController inventoryController = FindObjectOfType<InventoryController>();
                //if (inventoryController != null)
                //{
                inventoryController.newScriptableObjectt = newScriptableObject;
                inventoryController.PrepareInventoryData();
                //}

                // Chọn đối tượng mới tạo trong Project window
                Selection.activeObject = newScriptableObject;

            }
        }
    }

    public void CreateMyScriptableObjectAllItem()
    {
        StartCoroutine(GetAllItemAPI());

    }

    IEnumerator GetAllItemAPI()
    {
        foreach (GetAllItemResponseModel model in Login.getAllItemResponse)
        {

            // Tạo một ScriptableObject mới
            ItemSO newScriptableObject = ScriptableObject.CreateInstance<ItemSO>();

            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(model.image))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    // Tạo một sprite từ texture tải về
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

                    // Gán sprite trực tiếp vào SpriteRenderer
                    spriteRenderer = sprite;
                    newScriptableObject.id += model._id;
                    newScriptableObject.Name += model.itemName;
                    newScriptableObject.Description += model.description;
                    newScriptableObject.itemImage = model.image;
                    newScriptableObject.IteamImage = spriteRenderer;
                    newScriptableObject.price += model.price;


                    // Hoặc gán sprite trực tiếp vào một Sprite khác (không thông qua SpriteRenderer)
                    // this.GetComponent<SpriteRenderer>().sprite = sprite;
                }
                else
                {
                    Debug.Log("Error loading image: " + www.error);
                }
            }

            // Lưu đối tượng vào thư mục Assets
            string assetPath = "Assets/Resources/DataAllItemAPI/" + model.itemName + ".asset";
            AssetDatabase.CreateAsset(newScriptableObject, assetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();




            // Chọn đối tượng mới tạo trong Project window
            Selection.activeObject = newScriptableObject;

        }

    }

    private void Awake()
    {
        if (createScriptsIntance == null)
        {
            createScriptsIntance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            CreateMyScriptableObject();
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            CreateMyScriptableObjectAllItem();
        }
    }

}