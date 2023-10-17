using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ore : MonoBehaviour
{
  private bool hit = false;
  private int lifeore = 5;





  void Start()
  {

  }
  void Update()
  {



  }

  // Update is called once per frame
  private void OnTriggerEnter2D(Collider2D collision)
  {
    string nameTree = collision.attachedRigidbody.gameObject.name;
    if (collision.gameObject.CompareTag("axe"))
    {
      lifeore = lifeore - 1;
     
     // CutTreeSound.Play();
      StartCoroutine(ShakeOnce(0.2f, 0.009f));
      if (lifeore == 0)
      {
       // TreeToWood();
        Destroy(gameObject);
        lifeore = 5;

      }

    }
  }

  public IEnumerator ShakeOnce(float time, float magnitude)
  {
    Vector3 originPosotion = transform.position;
    float totalTime = 0f;

    while (totalTime < time)
    {
      totalTime += Time.deltaTime;
      float x = Random.Range(-1, 2) * magnitude;
      float y = Random.Range(-1, 2) * magnitude;
      float z = Random.Range(-1, 2) * magnitude;

      transform.position += new Vector3(x, 0, z);

      yield return null;

    }

    transform.position = originPosotion;


  }




}
