using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

  private Animator anim;
 
  public AudioSource CutTreeSound;
  
  public GameObject wood = default;
  private int lifeTree_Snow = 5;

  [SerializeField] private Transform viTri;
  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();

  }

  // Update is called once per frame
  private void OnTriggerEnter2D(Collider2D collision)
  {
    string nameTree = collision.attachedRigidbody.gameObject.name;
    if (collision.gameObject.CompareTag("axe"))
    {
      lifeTree_Snow = lifeTree_Snow - 1;
     
      CutTreeSound.Play();
      StartCoroutine(ShakeOnce(0.2f, 0.012f));
      if (lifeTree_Snow == 0)
      {
        TreeToWood();
        Destroy(gameObject);
        lifeTree_Snow = 5;

      }

    }



  }
  private void TreeToWood()
  {
    /*ani.Play("Char_Attack_LR");*/

    GameObject woodfall = Instantiate(wood, viTri.position, viTri.rotation);


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
