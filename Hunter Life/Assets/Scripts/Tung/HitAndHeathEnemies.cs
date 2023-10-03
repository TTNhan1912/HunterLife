using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HitAndHeathEnemies : MonoBehaviour
{
    public Image blood;
    public float hit;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var name = collision.gameObject.tag;

        //khi bị tấn công
        if (collision.gameObject.CompareTag("player"))
        {
            BeingAttacked();
        }
    }

    private void BeingAttacked()
    {
        float oneTouch = 1f / hit;

        blood.fillAmount = blood.fillAmount - oneTouch;
        blood.fillAmount = blood.fillAmount;
        
    }
}
