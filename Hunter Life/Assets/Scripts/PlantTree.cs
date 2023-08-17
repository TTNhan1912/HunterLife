using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTree : MonoBehaviour
{
    public GameObject treePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Kiểm tra sự kiện click chuột trái
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("ArableLand")) // Kiểm tra xem có bấm vào ô đất không
            {
                // Tạo một cây hoặc đối tượng tại vị trí click
                Instantiate(treePrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
