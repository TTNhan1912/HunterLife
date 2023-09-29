﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CharAndNPC
{
    public class NPCStandController : MonoBehaviour
    {
        public GameObject Panel;
        public TMP_Text contentLabel;
        public string[] content;
        private int index;
        public GameObject button;

        private int checkBtnClick2Time;

        public float wordSpeed;
        //private Animator animator;
        private BoxCollider2D npcBox;
        private PlayerMovement playerSpeed;
        private bool isAfterTouchChar;

        private void Start()
        {
            npcBox = GetComponent<BoxCollider2D>();
            //animator = GetComponent<Animator>();
            checkBtnClick2Time = 0;
            isAfterTouchChar = false;
            // Truy cập biến của PlayerInteraction.cs 
            playerSpeed = FindObjectOfType<PlayerMovement>();
            if (playerSpeed != null) { }
            else
            {
                Debug.Log("không truy cập được PlayerMovement");
            }
        }

        private void Update()
        {
            button.SetActive(false);
            if (contentLabel.text == content[index])
            {
                button.SetActive(true);
            }
        }

        IEnumerator Typing()
        {
            foreach (char letter in content[index].ToCharArray())
            {
                contentLabel.text += letter;
                yield return new WaitForSeconds(wordSpeed);
            }
        }

        public void NextLine()
        {
            button.SetActive(false);
            if (index < content.Length - 1)
            {
                index++;
                contentLabel.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                Debug.Log("ko hiện chữ tiếp theo dc");
            }
        }

        // bắt sự kiện 2 box va chạm nhau
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var name = collision.gameObject.tag;

            //khi nhân vật chạm npc
            if (collision.gameObject.CompareTag("player"))
            {
                if (!isAfterTouchChar)
                {
                    PanelHandler();
                    // dừng di chuyển char
                    playerSpeed.setSpeedRun(0f);
                }
            }
        }
        // thao tác với panel 
        private void PanelHandler()
        {
            Debug.Log("đang đứng");
            Panel.SetActive(true);
            StartCoroutine(Typing());
        }

        public void checkClick()
        {
            checkBtnClick2Time++;
            Debug.Log("lần nhân thứ: " + checkBtnClick2Time);
            // muốn nhập bao nhiêu text cũng được, không cần if từ 1 tới n...
            for (int i = 0; i < content.Length; i++)
            {
                if (checkBtnClick2Time == i)
                {
                    NextLine();
                }
            }
            if (checkBtnClick2Time == content.Length)
            {
                Debug.Log("đã click");
                playerSpeed.setSpeedRun(5f);
                Debug.Log("đang chạy");
                //tắt panel
                Panel.SetActive(false);
                isAfterTouchChar = true;
                //npc đi xuyên qua char
             //   npcBox.isTrigger = true;
                // xóa npc sau 3s
              //  Destroy(gameObject, 3);
            }
        }
    }
}