using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CharAndNPC
{
    public class CheckBtnContinueClick : MonoBehaviour
    {
        private bool isClickBtnContinue;
        private Player player;
        private NPCController npc;
        

        // Start is called before the first frame update
        void Start()
        {
            isClickBtnContinue = false;
            // Truy cập biến của Player.cs 
            player = FindObjectOfType<Player>();
            if (player != null)
            {
                Debug.Log("truy cập player thành công");
            }
            else
            {
                Debug.Log("không truy cập được player");
            }

            // Truy cập biến của Player.cs 
            npc = FindObjectOfType<NPCController>();
            if (npc != null)
            {
                Debug.Log("truy cập NPC thành công");
            }
            else
            {
                Debug.Log("không truy cập được NPC");
            }

            player.setSpeedRun(0f);
            player.isAfterTouchNPC = false;
            Debug.Log("đang đứng");
        }
        void Update()
        {
           
        }

        public void checkClick()
        {
            isClickBtnContinue = true;
            Debug.Log("đã click");
            player.setSpeedRun(1f);
            player.isClickBtn= true;
            Debug.Log("đang chạy");
           

        }
    }
}
