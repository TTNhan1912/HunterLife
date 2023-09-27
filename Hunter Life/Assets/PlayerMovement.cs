using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    public Rigidbody2D rigidbody2D;
    public Animator ani;
    Vector2 movement;   



    // Update is called once per frame
    void Update() // theo frame
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        ani.SetFloat("Horizontal", movement.x);
        ani.SetFloat("Vertical", movement.y);
        ani.SetFloat("Speed", movement.sqrMagnitude );

    }

    private void FixedUpdate() // 50 lần mỗi giây
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.deltaTime);
    }


}
