using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody2D rigidbody2D;
    public Animator ani;
    Vector2 movement;

    //tạo getter setter để gọi speedRun mà ko cần public
    public float getSpeedRun()
    {
        return moveSpeed;
    }
    public void setSpeedRun(float speedRun)
    {
        this.moveSpeed = speedRun;
    }


    // Update is called once per frame
    void Update() // theo frame
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        ani.SetFloat("Horizontal", movement.x);
        ani.SetFloat("Vertical", movement.y);
        ani.SetFloat("Speed", movement.sqrMagnitude );
        //tùng
        moveSpeed = getSpeedRun();

    }

    private void FixedUpdate() // 50 lần mỗi giây
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.deltaTime);
    }


}
