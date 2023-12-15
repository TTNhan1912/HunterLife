﻿using Newtonsoft.Json;
using System.Collections;
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
                 Debug.Log(">>>>>>>>>>"+ loginResponse.chestmap);
                SceneManager.LoadScene(1);
            }
            else
            {
                txtError.text = loginResponse.message;
            }
        }
        request.Dispose();


    }


}
