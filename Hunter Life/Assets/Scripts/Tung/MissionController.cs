using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissionController : MonoBehaviour
{
    // khai báo bảng nv
    public GameObject listMission;
    private bool isActive = false;
    // khai báo text tên nv
    public TMP_Text missionName1, missionName4;//, missionName2, missionName3,missionName5,missionName6,missionName7;
    //khai báo text tiến độ nv
    public TMP_Text missionProgress1, missionProgress4;//, missionProgress2, missionProgress3 missionProgress5, missionProgress6, missionProgress7;
    // khai báo biến đếm tiến độ
    private int progress1, progress2, progress3, progress4, progress5, progress6, progress7 = 0;
    //khai báo btn nhận thưởng
    public Button btn1, btn4;//, btn2, btn3,btn5, btn6, btn7;
    // khai báo chữ của btn
    public Text btn1Text, btn4Text;//, btn2Text, btn3Text, btn5Text, btn6Text, btn7Text;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("VillageChief"))
        {
            //Mission1Controller();
        }
    }

    public void Mission1Controller()
    {
        if(progress1>=1)
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



    public void RewardMission1()
    {
        btn1Text.text = "Đã nhận thưởng";
    }

    public void RewardMission4()
    {
        btn4Text.text = "Đã nhận thưởng";
    }
}
