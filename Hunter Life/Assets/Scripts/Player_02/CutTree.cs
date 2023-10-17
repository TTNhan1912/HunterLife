using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{

  private Animator anim;
  public int life;
  public AudioSource CutTreeSound;
  private bool treedie = false;
  public GameObject wood = default;
  private int lifeTree_Snow = 3;

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
      anim.Play("Tree_cut");
      CutTreeSound.Play();
      StartCoroutine(ShakeOnce(0.2f, 0.009f));
      if (lifeTree_Snow == 0)
      {
        TreeToWood();
        Destroy(gameObject);
        lifeTree_Snow = 3;

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
      float x = Random.Range(-1, 2) * magnitude;
      float y = Random.Range(-1, 2) * magnitude;
      float z = Random.Range(-1, 2) * magnitude;

      transform.position += new Vector3(x, 0, z);

      yield return null;

    }

    transform.position = originPosotion;


  }


}
