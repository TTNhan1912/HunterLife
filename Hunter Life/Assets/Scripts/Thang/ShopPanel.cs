using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    private bool checker;
    // Start is called before the first frame update
    void Start()
    {
        checker = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!checker) 
        { 
            shopPanel.SetActive(false);
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                shopPanel.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                shopPanel.SetActive(false);
                checker = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("browseStock"))
        {
            checker = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("browseStock"))
    //    {
    //        shopPanel.SetActive(false);
    //    }
    //}
}
