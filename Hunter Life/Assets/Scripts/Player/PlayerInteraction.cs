using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // tương tác với NPC
    private bool isTouchNPC;
    public bool isAfterTouchNPC;
    public bool isClickBtn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // bắt sự kiện va chạm NPC
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var name = collision.gameObject.tag;

        //khi nhân vật chạm npc
        if (collision.gameObject.CompareTag("npc"))
        {
            if (!isTouchNPC)
            {
                isTouchNPC = true;
            }
        }
    }
}
