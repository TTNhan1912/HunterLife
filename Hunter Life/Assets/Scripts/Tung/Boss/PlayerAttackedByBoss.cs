using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackedByBoss : MonoBehaviour
{
    // Start is called before the first frame update
    // cs này gắn dô player
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BossAttack"))
        {
            Debug.Log("Player bị boss chém");
        }

        else if (other.gameObject.CompareTag("BossBullet"))
        {
            Debug.Log("Player bị boss bắn trúng");
            Destroy(other.gameObject);
        }
    }
}
