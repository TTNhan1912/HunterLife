using System.Collections;
using System.Collections.Generic;
// using TMPro;
using UnityEngine;



public class PlayerLife : MonoBehaviour
{
    private Animator ani;
    public GameObject heal = default;
    [SerializeField] private Transform viTriheal;



    public int CharLife = 10;
    public int CharLifeMax = 10;







    [SerializeField] private SimpleFlash flashEffect;
    // Start is called before the first frame update
    void Start()
    {

        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            CharLife = CharLife + 1;
            //  ani.Play("Char_Attack_LR");
            GameObject heal2 = Instantiate(heal, viTriheal.position, viTriheal.rotation);



        }





        if (CharLife == 0)
        {

            //    ani.Play("Player_Die");
        }
        //         Heart1empty.SetActive(true);



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Slimebite"))
        {
            matmau(1);
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            matmau(1);
        }
        if (collision.gameObject.CompareTag("BossBullet"))
        {
            matmau(1);
        }
         if (collision.gameObject.CompareTag("BossAttack"))
        {
            matmau(2);
        }


    }
    public void matmau(int dame)
    {
        flashEffect.Flash();

        //    Instantiate(PopUpDame,originPosotion,Quaternion.identity
        //    );

        StartCoroutine(ShakeOnce(0.16f, 0.012f));
        CharLife = CharLife - dame;

    }
    public IEnumerator ShakeOnce(float time, float magnitude)
    {
        Vector3 originPosotion = transform.position;
        float totalTime = 0f;

        while (totalTime < time)
        {
            totalTime += Time.deltaTime;
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;
            float z = Random.Range(-1, 1) * magnitude;

            transform.position += new Vector3(x, y, z);

            yield return null;
        }

        transform.position = originPosotion;


    }




}

