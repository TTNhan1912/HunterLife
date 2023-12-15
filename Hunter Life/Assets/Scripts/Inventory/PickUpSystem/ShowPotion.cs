using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Pathfinding.RaycastModifier;

public class ShowPotion : MonoBehaviour
{
    public static ShowPotion playerLife;
    public InventorySO inventoryData;

    public GameObject canvans;
    public TextMeshProUGUI TextLifePot1;
    public TextMeshProUGUI TextLifePot2;

    public TextMeshProUGUI TextLifeKey1;
    public TextMeshProUGUI TextLifeKey2;

    public int LifePot;
    public int Key;

    private int intPot;
    private int intKey;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(LifePot != intPot)
        {
            bool isActiveInHierarchy = canvans.activeInHierarchy;
            if (isActiveInHierarchy)
            {
                TextLifePot1.text = LifePot + "";
                intPot = LifePot;
               
            }
            else
            {
                TextLifePot2.text = LifePot + "";
                intPot = LifePot;
               
            }
        }

        if(Key != intKey)
        {
            bool isActiveInHierarchy = canvans.activeInHierarchy;
            
            if (isActiveInHierarchy)
            {
                TextLifeKey1.text = Key + "";
               intKey = Key;
            }
            else
            {
                TextLifeKey2.text = Key + "";
                intKey = Key;
            }
        }
   
    }


    private void Awake()
    {
        if (playerLife == null)
        {
            playerLife = this;
        }
        else
        {
            Debug.Log("Nulllll");
        }
    }

    public void ShowPot()
    {
        bool isActiveInHierarchy = canvans.activeInHierarchy;
        if (isActiveInHierarchy)
        {
            TextLifePot1.text = LifePot + "";
        }
        else
        {
            TextLifePot2.text = LifePot + "";
           
        }
    }

    public void ShowKey()
    {
        bool isActiveInHierarchy = canvans.activeInHierarchy;

        if (isActiveInHierarchy)
        {
            TextLifeKey1.text = Key + "";
            
        }
        else
        {
            TextLifeKey2.text = Key + "";
        }
    }
    public void LoadQuantityPotion(int quantity)
    {
        bool isActiveInHierarchy = canvans.activeInHierarchy;      
       
        LifePot += quantity;
        if (isActiveInHierarchy)
        {
            TextLifePot1.text = LifePot + "";
            return;
        }
        else
        {
            TextLifePot2.text = LifePot + "";
            return;
        }
    } 

public void LoadQuantityKey(int quantity)
    {
        bool isActiveInHierarchy = canvans.activeInHierarchy;
        Key += quantity;
        if (isActiveInHierarchy)
        {
            TextLifeKey1.text = Key + "";
            return;
        }
        else
        {
            TextLifeKey2.text = Key + "";
            return;
        }             
        }
    
}
