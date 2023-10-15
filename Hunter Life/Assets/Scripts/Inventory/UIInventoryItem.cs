using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityTxt;
    [SerializeField] private Image boder;

    public event Action<UIInventoryItem> OnItemclick, OnItemDroppedOn,
        OnItemBeginDrag, OnItemEndDrag,OnRightMouseButtonClick;
    private bool emty = true;




    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
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

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantityTxt.text = quantity + "";
        emty = false;
    }

    public void Select()
    {
        boder.enabled = true;
    }

    public void OnBeginDrag()
    {
        if (emty)
        {
            return;
            OnItemBeginDrag?.Invoke(this);
        }
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPoinTerClick(BaseEventData data)
    {
        //if (emty) return;
        PointerEventData pointerdata = (PointerEventData) data;
        if(pointerdata.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseButtonClick?.Invoke(this);
            Debug.Log(">>>>>");  
        }
        else
        {
            OnItemclick?.Invoke(this);  
        }


    }


}
