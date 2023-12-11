using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.UI
{
    public class UIShopDescription : MonoBehaviour
    {
        [SerializeField]
        private Image itemImage;

        [SerializeField]
        private TMP_Text title;

        [SerializeField]
        private TMP_Text description;

        private int currentTotal = 0;

        [SerializeField] private TMP_Text total;
        [SerializeField] private TMP_Text btnIncrease;
        [SerializeField] private TMP_Text btnDecrease;
        [SerializeField] private TMP_Text btnPurchase;

        public void Awake()
        {
            ResetDiscription();
        }

        public void ResetDiscription()
        {
            itemImage.gameObject.SetActive(false);
            title.text = "";
            description.text = "";
            total.text = "";
        }
        public void SetDescription(Sprite sprite, string itemname, string itemdesciption, string itemPrice)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            title.text = itemname;
            description.text = itemdesciption;

            int price = int.Parse(itemPrice);

            currentTotal = price;

            total.text = itemPrice;

            
        }

        public void increase()
        {
            // Chuyển đổi total.text từ kiểu string sang kiểu int
            int price = int.Parse(total.text);

            // Thêm giá trị mới vào currentTotal
            currentTotal += price;

            // Hiển thị giá trị mới trong total.text
            total.text = currentTotal.ToString();

            // Cập nhật lại dữ liệu
            SetDescription(itemImage.sprite, title.text, description.text, total.text);
            Debug.Log("Pressed!");
        }
    }
}
