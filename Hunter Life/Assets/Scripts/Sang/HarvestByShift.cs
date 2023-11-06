using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestByShift : MonoBehaviour
{
    public GameObject riuPrefab; // Kéo prefab của cây rìu vào đây trong Unity Editor

    private GameObject currentRiu;

    void Update()
    {
        // Kiểm tra xem người chơi có đang giữ phím Shift hay không
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Nếu chưa có cây rìu, tạo mới
            if (currentRiu == null)
            {
                currentRiu = Instantiate(riuPrefab);
            }

            // Lấy vị trí của con trỏ chuột trong không gian thế giới
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Đảm bảo rằng cây rìu chỉ di chuyển trong mặt phẳng 2D

            // Di chuyển cây rìu đến vị trí con trỏ chuột
            currentRiu.transform.position = mousePosition;
        }
        else
        {
            // Nếu không giữ phím Shift, hủy cây rìu nếu có
            if (currentRiu != null)
            {
                Destroy(currentRiu);
                currentRiu = null;
            }
        }
    }
}
