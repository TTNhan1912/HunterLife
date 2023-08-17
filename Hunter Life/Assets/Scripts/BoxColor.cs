using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColor : MonoBehaviour
{
    private Color originalColor;
    public Color highlightColor = Color.red;
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.color; // Lấy màu gốc từ Renderer
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = highlightColor; // Thay đổi màu khi chuột di chuyển đến
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor; // Khôi phục màu khi chuột rời khỏi
    }
}
