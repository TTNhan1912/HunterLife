using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sell.UI
{
    public class UISellDescription : MonoBehaviour
    {
        [SerializeField]
        private Image itemImage;

        [SerializeField]
        private TMP_Text title;

        [SerializeField]
        private TMP_Text description;

        private int currentTotal = 0;
        private int initialPrice;

        [SerializeField] private TMP_Text total;
        [SerializeField] private TMP_Text btnIncrease;
        [SerializeField] private TMP_Text btnDecrease;
        [SerializeField] private TMP_Text btnPurchase;


        // Start is called before the first frame update
        void Start()
        {
            ResetDiscription();
        }

        // Update is called once per frame
        void Update()
        {

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

            //  initialPrice = int.Parse(itemPrice);

            total.text = itemPrice;
        }

        public void increase()
        {

            currentTotal += initialPrice;

            Debug.Log(initialPrice);

            total.text = currentTotal.ToString();


            SetDescription(itemImage.sprite, title.text, description.text, currentTotal.ToString());

        }

        public void decrease()
        {

            currentTotal -= initialPrice;

            Debug.Log(initialPrice);

            total.text = currentTotal.ToString();


            SetDescription(itemImage.sprite, title.text, description.text, currentTotal.ToString());

        }
    }
}
