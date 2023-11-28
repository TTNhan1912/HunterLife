using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField edtEmail, edtPassword;
    public TMP_Text txtError;
    public Selectable fisrt;
    private EventSystem eventSystem;
    public static LoginResponseMoel loginResponse;
    public static List<TestModel> testModelAPI;
    public static Test01model test01Model1;
    public static Login loginIntance;

    public string idItem;
    public string ItemName;
    public string ItemNameID;
    public string ItemNameDescription;
    public int ItemNameQuantity;


    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        // fisrt.Select();
    }

    private void Awake()
    {
        if (loginIntance == null)
        {
            loginIntance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Input.GetKeyDown(KeyCode.Tab))
                {
                    Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                    if (next != null)
                    {
                        next.Select();
                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                    if (next != null)
                    {
                        next.Select();
                    }
                }*/
        if (Input.GetKeyDown(KeyCode.K))
        {
            test();
            // Debug.Log("id item name la :" + ItemName);
        }
    }

    public void CheckLogin()
    {
        StartCoroutine(LoginUser());
        LoginUser();
    }

    IEnumerator LoginUser()
    {
        //…
        var email = edtEmail.text;
        var pass = edtPassword.text;


        UserModel userModel = new UserModel(email, pass);
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("https://hunterlife-253b1afa0da4.herokuapp.com/api/users/login", "POST");
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
            loginResponse = JsonConvert.DeserializeObject<LoginResponseMoel>(jsonString);
            if (loginResponse.status)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                txtError.text = loginResponse.message;
            }
        }
        request.Dispose();


    }


    public void test()
    {
        StartCoroutine(GetDataFromNodeJS());
        GetDataFromNodeJS();
    }

    IEnumerator GetDataFromNodeJS()
    {
        var id = "654507e7644da551c636056c";
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
            testModelAPI = JsonConvert.DeserializeObject<List<TestModel>>(jsonString);

            //   Debug.Log(test01Model.itemname);

            foreach (TestModel model in testModelAPI)
            {
                Debug.Log($"_id: {model._id}");
                Debug.Log($"Item Name: _id: {model.itemName._id}," +
                    $" ItemName: {model.itemName.itemName}, Description: {model.itemName.description}, " +
                    $"Consumable: {model.itemName.consumable}, Image: {model.itemName.image}");
                Debug.Log($"Quantity: {model.quantity}");

                /*  idItem += model._id;
                  ItemNameID += model.itemName._id;
                  ItemName += model.itemName.itemName;
                  ItemNameDescription += model.itemName.description;
                  ItemNameQuantity += model.quantity;*/


            }


        }
        request.Dispose();
    }

}
