using System.Collections;
using System.Collections.Generic;
// using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator ani;
    public GameObject Heart1, Heart1half, Heart1empty;
    public GameObject Heart2, Heart2half, Heart2empty;
    public GameObject Heart3, Heart3half, Heart3empty;
    public GameObject Heart4, Heart4half, Heart4empty;
    public GameObject Heart5, Heart5half, Heart5empty;

    private int CharLife = 10;



    [SerializeField] private SimpleFlash flashEffect;
    // Start is called before the first frame update
    void Start()
    {

        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (CharLife)
        {
            case 0:
                ani.Play("Char_Die");
                Heart1empty.SetActive(true);
                break;
            case 10:
             
                break;
            case 9:
                Heart5half.SetActive(true);
                break;
            case 8:
                Heart5empty.SetActive(true);
                break;
            case 7:
                Heart4half.SetActive(true);
                break;
            case 6:
                Heart4empty.SetActive(true);
                break;
            case 5:
                Heart3half.SetActive(true);
                break;
            case 4:
                Heart3empty.SetActive(true);
                break;
            case 3:
                Heart2half.SetActive(true);
                break;
            case 2:
                Heart2empty.SetActive(true);
                break;
            case 1:
                Heart1half.SetActive(true);
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Slimebite"))
        {

            matmau(1);

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
