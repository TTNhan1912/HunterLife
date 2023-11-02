using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private SimpleFlash flashEffect;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
  {
    string name = collision.attachedRigidbody.gameObject.name;
    if (collision.gameObject.CompareTag("Slimebite"))
    {
            flashEffect.Flash();
   
    //    Instantiate(PopUpDame,originPosotion,Quaternion.identity
    //    );
     
      StartCoroutine(ShakeOnce(0.16f, 0.012f));
    

    }


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
