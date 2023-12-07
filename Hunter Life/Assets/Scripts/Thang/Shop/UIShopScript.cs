using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class UIShopScript : MonoBehaviour
    {
        [SerializeField] UIShopItem itemPrefabs;
        [SerializeField] RectTransform contenPanel;
        [SerializeField]
        private UIShopDescription itemDescription;
        [SerializeField]
        private MouseFollower mouseFollower;
        List<UIShopItem> ListOfUIItem = new List<UIShopItem>();
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
            Hide();
            mouseFollower.Toggle(false);
            itemDescription.ResetDiscription();
        }

        public void InitInventory(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UIShopItem uiItem = Instantiate(itemPrefabs, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contenPanel);
                ListOfUIItem.Add(uiItem);
            }
        }

        internal void UpdateDesciption(int itemindex, Sprite iteamImage, string name, string description)
        {
            itemDescription.SetDescription(iteamImage, name, description);
            DeselectAllItems();
            ListOfUIItem[itemindex].Select();
        }

        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
        {
            if (ListOfUIItem.Count > itemIndex)
            {
                ListOfUIItem[itemIndex].SetData(itemImage, itemQuantity);
            }
        }

        public void ResetSelection()
        {
            itemDescription.ResetDiscription();
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (UIShopItem item in ListOfUIItem)
            {
                item.Deselect();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        internal void ResetAllItem()
        {
            foreach (var item in ListOfUIItem)
            {
                item.ResetData();
                item.Deselect();
            }
        }
    }
}
