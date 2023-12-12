﻿using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ItemAPILogin : MonoBehaviour
{
    public static Test01model test01Model1;
    public static List<TestModel> testModel;
    public static List<GetAllItemResponseModel> getAllItemResponse;
    public static ItemAPILogin itemAPI;
    public static List<ShopItemResponseModel>  shopItemResponseModel;


    // Start is called before the first frame update
    void Start()
    {
        GetAllItem();
        test();
        GetAllItemShop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            test();
            // Debug.Log("id item name la :" + ItemName);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GetAllItem();
            // Debug.Log("id item name la :" + ItemName);
        }
    }

    private void Awake()
    {
        if (itemAPI == null)
        {
            itemAPI = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // lấy vật phẩm của người chơi
    public void test()
    {
        StartCoroutine(GetDataFromNodeJS());
        GetDataFromNodeJS();
    }

    IEnumerator GetDataFromNodeJS()
    {
        var id = "654507e7644da551c636056c";

        //if (Login.loginResponse != null)
        //{
        //    id = Login.loginResponse.id;
        //    Debug.Log("id1" + id);
        //    Debug.Log("Login");
        //}

        //if (Register.registerResponseMoel != null)
        //{
        //    id = Register.registerResponseMoel.id;
        //    Debug.Log("Register" + id);
        //}
        TestResponseModel userModel = new TestResponseModel(id);

        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("https://hunterlife-253b1afa0da4.herokuapp.com/api/users/getitemsinventory", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            // Đây là cách giải mã mảng JSON thành một danh sách đối tượng TestModel
            testModel = JsonConvert.DeserializeObject<List<TestModel>>(jsonString);

            //   Debug.Log(test01Model.itemname);
            CreateScripts.createScriptsIntance.CreateMyScriptableObject();

        }
        request.Dispose();
    }

    // lấy tất cả vật phẩm của game
    public void GetAllItem()
    {
        StartCoroutine(GetAll());
        GetAll();
    }

    IEnumerator GetAll()
    {
        var request = new UnityWebRequest("https://hunterlife-253b1afa0da4.herokuapp.com/api/users/items", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            // Đây là cách giải mã mảng JSON thành một danh sách đối tượng TestModel
            getAllItemResponse = JsonConvert.DeserializeObject<List<GetAllItemResponseModel>>(jsonString);

            //   Debug.Log(test01Model.itemname);
            CreateScripts.createScriptsIntance.CreateMyScriptableObjectAllItem();




        }
        request.Dispose();
    }

    // thêm vật phẩm vào túi đồ
    public void NewItemInventory(string itemName, int quantity)
    {
        StartCoroutine(ItemInventory(itemName, quantity));
        ItemInventory(itemName, quantity);
    }

    IEnumerator ItemInventory(string itemName, int quantity)
    {
        var userName = "654507e7644da551c636056c";

        //if (Login.loginResponse != null)
        //{
        //    id = Login.loginResponse.id;
        //    Debug.Log("id1" + id);
        //    Debug.Log("Login");
        //}

        //if (Register.registerResponseMoel != null)
        //{
        //    id = Register.registerResponseMoel.id;
        //    Debug.Log("Register" + id);
        //}
        NewItemsInventoryModel userModel = new NewItemsInventoryModel(userName, itemName, quantity);

        string jsonStringRequest = JsonConvert.SerializeObject(userModel);
        var request = new UnityWebRequest("https://hunterlife-253b1afa0da4.herokuapp.com/api/users/newitemsinventory", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            // Đây là cách giải mã mảng JSON thành một danh sách đối tượng TestModel
            NewItemsInventoryResponesModel newItemsInventoryRespones = JsonConvert.DeserializeObject<NewItemsInventoryResponesModel>(jsonString);

            if (newItemsInventoryRespones.status)
            {
                test();
                Debug.Log("Add thành công");
            }
            else
            {
                Debug.Log("Add thất bại");
            }


        }
        request.Dispose();
    }

    // xóa vật phẩm trong túi đồ
    public void DeleteItemInventory(string itemName, int quantity)
    {
        StartCoroutine(deleteItemInventory(itemName, quantity));
        deleteItemInventory(itemName, quantity);
    }

    IEnumerator deleteItemInventory(string itemName, int quantity)
    {
        var userName = "654507e7644da551c636056c";

        //if (Login.loginResponse != null)
        //{
        //    id = Login.loginResponse.id;
        //    Debug.Log("id1" + id);
        //    Debug.Log("Login");
        //}

        //if (Register.registerResponseMoel != null)
        //{
        //    id = Register.registerResponseMoel.id;
        //    Debug.Log("Register" + id);
        //}
        NewItemsInventoryModel userModel = new NewItemsInventoryModel(userName, itemName, quantity);

        string jsonStringRequest = JsonConvert.SerializeObject(userModel);
        var request = new UnityWebRequest("https://hunterlife-253b1afa0da4.herokuapp.com/api/users/deleteItemByQuantity", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            // Đây là cách giải mã mảng JSON thành một danh sách đối tượng TestModel
            NewItemsInventoryResponesModel newItemsInventoryRespones = JsonConvert.DeserializeObject<NewItemsInventoryResponesModel>(jsonString);

            if (newItemsInventoryRespones.status)
            {
                test();
                Debug.Log("Add thành công");
            }
            else
            {
                Debug.Log("Add thất bại");
            }


        }
        request.Dispose();
    }

    // lấy danh sách vật phẩm cửa hàng
    public void GetAllItemShop()
    {
        StartCoroutine(GetAllShop());
        GetAllShop();
    }

    IEnumerator GetAllShop()
    {
        var request = new UnityWebRequest("https://hunterlife-253b1afa0da4.herokuapp.com/api/users/shop", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            // Đây là cách giải mã mảng JSON thành một danh sách đối tượng TestModel
            shopItemResponseModel = JsonConvert.DeserializeObject<List<ShopItemResponseModel>>(jsonString);

            //   Debug.Log(test01Model.itemname);
            foreach (ShopItemResponseModel model in shopItemResponseModel)
            {
                Debug.Log($"_id: {model._id}");
                Debug.Log($"Item Name: _id: {model.itemName._id}," +
                    $" ItemName: {model.itemName.itemName}, Description: {model.itemName.description}, " +
                    $"Consumable: {model.itemName.consumable}, Image: {model.itemName.image}");
                Debug.Log($"Quantity: {model.quantity}");
            }




        }
        request.Dispose();
    }

}
