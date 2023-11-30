using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIShopScript : MonoBehaviour
    {
        [SerializeField] UIShopItem itemPrefabs;
        List<UIShopItem> ListOfUIItem = new List<UIShopItem>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitInventory(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UIShopItem uiItem = Instantiate(itemPrefabs, Vector3.zero, Quaternion.identity);
                ListOfUIItem.Add(uiItem);
            }
        }
    }
}
