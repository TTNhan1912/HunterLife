using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text productTxt;
    [SerializeField] private TMP_Text priceTxt;
    //[SerializeField] private Image boder;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(Sprite sprite, int price)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.priceTxt.text = price + "";
    }


}
