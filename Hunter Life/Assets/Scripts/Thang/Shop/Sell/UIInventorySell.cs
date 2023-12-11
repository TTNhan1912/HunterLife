using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sell.UI
{
    public class UIInventorySell : MonoBehaviour
    {
        [SerializeField] UISellItem itemPrefabs;

        [SerializeField] RectTransform contenPanel;

        [SerializeField]
        private UISellDescription itemDescription;

        [SerializeField]
        private MouseFollower mouseFollower;

        List<UISellItem> ListOfUIItem = new List<UISellItem>();

        private int currentlyDraggedItemIndex = -1;

        public event Action<int> OnDescipttionRequested, OnItemActionRequested;

        // Start is called before the first frame update
        void Start()
        {
            Hide();
            mouseFollower.Toggle(false);
            itemDescription.ResetDiscription();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitInventory(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                UISellItem uiItem = Instantiate(itemPrefabs, Vector3.zero, Quaternion.identity);

                uiItem.transform.SetParent(contenPanel);
                ListOfUIItem.Add(uiItem);
                uiItem.OnItemclick += HandleItemSelection;
                uiItem.OnRightMouseButtonClick += HandleShowItemAction;

            }
        }
        internal void UpdateDesciption(int itemindex, Sprite iteamImage, string name, string description, string price)
        {
            itemDescription.SetDescription(iteamImage, name, description, price);
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


        private void HandleShowItemAction(UISellItem inventoryItemUI)
        {
        }

        private void HandleItemSelection(UISellItem inventoryItemUI)
        {
            int index = ListOfUIItem.IndexOf(inventoryItemUI);
            if (index == -1) return;
            OnDescipttionRequested?.Invoke(index);

        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();

        }

        public void ResetSelection()
        {
            itemDescription.ResetDiscription();
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (UISellItem item in ListOfUIItem)
            {
                item.Deselect();
            }
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

        internal void UpdateData(int key, Coroutine coroutine, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
