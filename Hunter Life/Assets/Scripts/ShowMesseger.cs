using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMesseger : MonoBehaviour
{
    public GameObject messengerPanel;
    private void Update()
    {
        // Kiểm tra sự kiện click chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Đã Click");
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        // Xử lý logic khi click chuột
        Debug.Log("Mouse left click detected!");
        messengerPanel.SetActive(true);
    }
}
