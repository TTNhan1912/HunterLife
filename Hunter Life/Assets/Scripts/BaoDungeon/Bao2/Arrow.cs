using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
     private Rigidbody2D rb;
    public float speed = 5f; // Tốc độ của viên đạn
    public float forceMagnitude = 10f; // Lực của viên đạn

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Áp dụng lực xuất phát cho mũi tên khi nó được tạo ra
        rb.AddForce(transform.right * forceMagnitude, ForceMode2D.Impulse);
    }
    //  public void SetDirection(Vector2 newDirection)
    // {
    //     direction = newDirection;
    // }
    void OnTriggerEnter2D(Collider2D other)
{      
    // Kiểm tra nếu mũi tên va chạm vào một vật thể
    if (other.CompareTag("enemy3"))
    {
        // Gán mũi tên là con của vật thể đó
       transform.parent = other.transform;
          StickToTarget();

        // Tắt Rigidbody để mũi tên không bị ảnh hưởng bởi vật lý
        Destroy(rb);

        // Tắt script điều khiển để mũi tên không di chuyển nữa (nếu cần)
        // Destroy(GetComponent<Arrow>());
    }
     if (other.CompareTag("tuong"))
    {
        // Gán mũi tên là con của vật thể đó
       transform.parent = other.transform;
       

        // Tắt Rigidbody để mũi tên không bị ảnh hưởng bởi vật lý
        Destroy(rb);

        // Tắt script điều khiển để mũi tên không di chuyển nữa (nếu cần)
        // Destroy(GetComponent<Arrow>());
    }
}
void StickToTarget()
{
    Vector2 averagePosition = (transform.position + transform.parent.position) / 2f;
    transform.position = averagePosition;
}
}
