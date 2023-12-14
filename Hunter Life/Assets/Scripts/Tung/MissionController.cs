﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    // khai báo bảng nv
    public GameObject listMission;
    private bool isActive = false;
    // khai báo text tên nv
    public TMP_Text missionName1, missionName2, missionName3, missionName4, missionName5, missionName6, missionName7;
    //khai báo text tiến độ nv
    public TMP_Text missionProgress1, missionProgress2, missionProgress3, missionProgress4, missionProgress5, missionProgress6, missionProgress7;
    // khai báo biến đếm tiến độ
    private int progress1, progress2, progress3, progress4, progress5, progress6, progress7 = 0;
    //khai báo btn nhận thưởng
    public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7;
    // khai báo chữ của btn
    public Text btn1Text, btn2Text, btn3Text, btn4Text, btn5Text, btn6Text, btn7Text;

    //Nhận thưởng
    public GameObject PanelGeward;
    public TMP_Text contentBonus;
    // 
    private int getCoinsByMission;

    public int GetCoins()
    {
        //Debug.Log("Lấy coin:" + getCoinsByMission);
        return getCoinsByMission;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //GetCoins();
        //Debug.Log("Giá trị bên mission: " + getCoinsByMission);
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isActive)
            {
                listMission.SetActive(true);
            }
            else
            {
                listMission.SetActive(false);
            }
            isActive = !isActive;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("VillageChief"))
    //    {
    //        //Mission1Controller();
    //    }
    //}

    public void Mission1Controller()
    {
        if (progress1 >= 1)
        {
            return;
        }
        progress1++;
        missionProgress1.text = "(" + progress1 + "/1)";
        if (progress1 == 1)
        {
            missionName1.color = Color.blue;
            missionProgress1.color = Color.blue;
            btn1.interactable = true;
            btn1Text.color = Color.white;
        }
    }

    public void Mission2Controller()
    {
        if (progress2 >= 1)
        {
            return;
        }
        progress2++;
        missionProgress2.text = "(" + progress2 + "/1)";
        if (progress2 == 1)
        {
            missionName2.color = Color.blue;
            missionProgress2.color = Color.blue;
            btn2.interactable = true;
            btn2Text.color = Color.white;
        }
    }

    public void Mission3Controller()
    {
        if (progress3 >= 10)
        {
            return;
        }
        progress3++;
        missionProgress3.text = "(" + progress3 + "/10)";
        if (progress3 == 10)
        {
            missionName3.color = Color.blue;
            missionProgress3.color = Color.blue;
            btn3.interactable = true;
            btn3Text.color = Color.white;
        }
    }

    public void Mission4Controller()
    {
        if (progress4 >= 150)
        {
            return;
        }
        progress4++;
        missionProgress4.text = "(" + progress4 + "/150)";
        if (progress4 == 150)
        {
            missionName4.color = Color.blue;
            missionProgress4.color = Color.blue;
            btn4.interactable = true;
            btn4Text.color = Color.white;
        }
    }

    public void Mission5Controller()
    {
        if (progress5 >= 75)
        {
            return;
        }
        progress5++;
        missionProgress1.text = "(" + progress5 + "/75)";
        if (progress5 == 75)
        {
            missionName5.color = Color.blue;
            missionProgress5.color = Color.blue;
            btn5.interactable = true;
            btn5Text.color = Color.white;
        }
    }

    public void Mission6Controller()
    {
        if (progress6 >= 5)
        {
            return;
        }
        progress6++;
        missionProgress6.text = "(" + progress6 + "/5)";
        if (progress6 == 5)
        {
            missionName6.color = Color.blue;
            missionProgress6.color = Color.blue;
            btn6.interactable = true;
            btn6Text.color = Color.white;
        }
    }

    public void Mission7Controller()
    {
        if (progress7 >= 20)
        {
            return;
        }
        progress7++;
        missionProgress7.text = "(" + progress7 + "/20)";
        if (progress7 == 20)
        {
            missionName7.color = Color.blue;
            missionProgress7.color = Color.blue;
            btn7.interactable = true;
            btn7Text.color = Color.white;
        }
    }


    public void RewardMission1()
    {
        showGeward(10);
        btn1Text.text = "Đã nhận thưởng";
    }

    public void RewardMission2()
    {
        showGeward(10);
        btn2Text.text = "Đã nhận thưởng";
    }

    public void RewardMission3()
    {
        showGeward(20);
        btn3Text.text = "Đã nhận thưởng";
    }

    public void RewardMission4()
    {
        showGeward(75);
        btn4Text.text = "Đã nhận thưởng";
    }

    public void RewardMission5()
    {
        showGeward(30);
        btn5Text.text = "Đã nhận thưởng";
    }

    public void RewardMission6()
    {
        showGeward(50);
        btn6Text.text = "Đã nhận thưởng";
    }

    public void RewardMission7()
    {
        showGeward(80);
        btn7Text.text = "Đã nhận thưởng";
    }

    private void showGeward(int value)
    {
        PanelGeward.SetActive(true);
        contentBonus.text = "" + value;
        // cộng coins từ nhiệm vụ
        //getCoinsByMission += value;
        SavePositionCoin.coinn += value;
    }


}
