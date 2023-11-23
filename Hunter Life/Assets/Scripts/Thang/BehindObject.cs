using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindObject : MonoBehaviour
{
    //[SerializeField]private GameObject transparentObj;
    [SerializeField] private Renderer test;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("isCollide");
            Color color = test.GetComponent<Renderer>().material.color;
            color.a = 0.5f;
            test.GetComponent<Renderer>().material.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Color color = test.GetComponent<Renderer>().material.color;
        color.a = 1f;
        test.GetComponent<Renderer>().material.color = color;
    }
}
