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

        public Transform player;
        public GameObject NotNear;
        public GameObject Near;
        private bool isNear = false;
        // được nhấn F hay không
        private bool isPanelActive = false;

        private void Start()
        {
            npcBox = GetComponent<BoxCollider2D>();
            //animator = GetComponent<Animator>();
            checkBtnClick2Time = 0;
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

            if (!isPanelActive)
            {
                float distance = Vector2.Distance(transform.position, player.position);
                if (distance > 2f)
                {
                    isNear = false;
                    NotNear.SetActive(true);
                    Near.SetActive(false);
                }
                else
                {
                    isNear = true;
                    NotNear.SetActive(false);
                    Near.SetActive(true);
                }

                if (isNear && Input.GetKeyDown(KeyCode.F))
                {
                    PanelHandler();
                    playerSpeed.setSpeedRun(0f);
                }
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

        // thao tác với panel 
        private void PanelHandler()
        {
            Debug.Log("đang đứng");
            Panel.SetActive(true);
            index = 0;
            StartCoroutine(Typing());
            isPanelActive = true;
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
                contentLabel.text = "";
                isPanelActive = false;
                checkBtnClick2Time = 0;
            }
        }
    }
}