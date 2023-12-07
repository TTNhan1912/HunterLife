using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text productTxt;
    [SerializeField] private TMP_Text priceTxt;
    [SerializeField] private Image boder;

    public event Action<UIShopItem> OnItemclick, OnRightMouseButtonClick;

    private bool emty = true;

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

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        emty = true;
    }

    public void Deselect()
    {
        boder.enabled = (false);
    }

    public void Select()
    {
        boder.enabled = true;
    }


    public void OnPointerClick(PointerEventData pointerdata)
    {
        if (pointerdata.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseButtonClick?.Invoke(this);
        }
        else
        {
            OnItemclick?.Invoke(this);
        }
    }


}
