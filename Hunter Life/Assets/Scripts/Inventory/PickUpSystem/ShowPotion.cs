using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public int Key ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void LoadQuantityPotion()
    { 
        bool isActiveInHierarchy = canvans.activeInHierarchy;
        // Load danh sách ScriptableObject từ thư mục Resources
        ItemSO[] scriptableObjects = Resources.LoadAll<ItemSO>("DataItemAPI");

        foreach (var item in inventoryData.GetCurrentInventoryState())
        {             
            
            if ("651ff3786d1b88d6eb0d18e4" == item.Value.itemSO.idName)
            {
                LifePot = item.Value.itemSO.quantity;
                
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
        }

        if (isActiveInHierarchy)
        {
            TextLifePot1.text = 0 + "";
            return;
        }
        else
        {
            TextLifePot2.text = 0 + "";
            return;
        }
    }

    public void LoadQuantityKey()
    {
        bool isActiveInHierarchy = canvans.activeInHierarchy;
          // Load danh sách ScriptableObject từ thư mục Resources
        ItemSO[] scriptableObjects = Resources.LoadAll<ItemSO>("DataItemAPI");

        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
           
            if ("6574bc92db53a20b56ab4326" == item.Value.itemSO.idName)
            {
                Key = item.Value.itemSO.quantity;
                
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

        if (isActiveInHierarchy)
        {
            TextLifeKey1.text = 0 + "";
            return;
        }
        else
        {

            TextLifeKey2.text = 0 + "";
            return;
        }


    }
}
