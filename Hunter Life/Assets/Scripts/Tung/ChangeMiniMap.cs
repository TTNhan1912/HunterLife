using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMiniMap : MonoBehaviour
{
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;

    private bool isChange4to1 = true;
    private bool isChange1to2 = true;
    private bool isChange2to3 = true;
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
        if (collision.gameObject.CompareTag("Map4vsMap1"))
        {
            Change1vs4();
        }
        else if (collision.gameObject.CompareTag("Map1vsMap2"))
        {
            Change1vs2();
        }
        else if (collision.gameObject.CompareTag("Map2vsMap3"))
        {
            Change2vs3();
        }
    }

    private void Change1vs4()
    {
        if (isChange4to1)
        {
            Debug.Log("chuyển từ map 4 sang map 1");
            map1.SetActive(true);
            map2.SetActive(false);
            map3.SetActive(false);
            map4.SetActive(false);
        }
        else
        {
            Debug.Log("chuyển từ map 1 sang map 4");
            map1.SetActive(false);
            map2.SetActive(false);
            map3.SetActive(false);
            map4.SetActive(true);
        }
        isChange4to1 = !isChange4to1;
    }

    private void Change1vs2()
    {
        if (isChange1to2)
        {
            Debug.Log("chuyển từ map 1 sang map2");
            map1.SetActive(false);
            map2.SetActive(true);
            map3.SetActive(false);
            map4.SetActive(false);
        }
        else
        {
            Debug.Log("chuyển từ map 2 sang map 1");
            map1.SetActive(true);
            map2.SetActive(false);
            map3.SetActive(false);
            map4.SetActive(false);
        }
        isChange1to2 = !isChange1to2;
    }

    private void Change2vs3()
    {
        if (isChange2to3)
        {
            Debug.Log("chuyển từ map 2 sang map 3");
            map1.SetActive(false);
            map2.SetActive(false);
            map3.SetActive(true);
            map4.SetActive(false);
        }
        else
        {
            Debug.Log("chuyển từ map 3 sang map 2");
            map1.SetActive(false);
            map2.SetActive(true);
            map3.SetActive(false);
            map4.SetActive(false);
        }
        isChange2to3 = !isChange2to3;
    }
}
