using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject messegerCloud;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // bắt sự kiện 2 box va chạm nhau
    private void OnCollisionEnter2D(Collision2D collision)
        {
            var name = collision.gameObject.tag;

            //khi nhân vật chạm npc
            if (collision.gameObject.CompareTag("player"))
                {
                    messegerCloud.SetActive(true);
                }

        }
       }
