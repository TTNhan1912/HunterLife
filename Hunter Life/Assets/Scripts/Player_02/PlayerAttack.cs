using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  private GameObject attackArea = default;
  public GameObject AXe;


  private bool attacking = false;
  private double _doubleClickTimeLimit = 0.25f;

  private float timeToAttack = 0.1f;

  private float time = 0f;

  private Animator ani;

  // Start is called before the first frame update
  void Start()
  {
    ani = GetComponent<Animator>();
    attackArea = transform.GetChild(0).gameObject;
      StartCoroutine(ClickListener());
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
    //  Attack();
      //  ani.Play("Char_Attack_LR");





    }
    else if (attacking)
    {

      time += Time.deltaTime;
      if (time >= timeToAttack)
      {
        time = 0f;
        attacking = false;
        //  attacking2=true;

        attackArea.SetActive(attacking);
        //  AXe.SetActive(attacking2);
      }
    }

  }

  private void Attack()
  {
    /*ani.Play("Char_Attack_LR");*/

    attacking = true;
    //   attacking2 = false;

    attackArea.SetActive(attacking);
    //  AXe.SetActive(attacking2);

  }
  private IEnumerator ClickListener()
  {
    while (enabled)
    {
      if (Input.GetMouseButtonDown(0))
      {
        yield return MouseClick();
      }
      yield return null;
    }

  }

  private IEnumerator MouseClick()
  {
    yield return new WaitForEndOfFrame();

    float timeCount = 0;
    while (timeCount < _doubleClickTimeLimit)
    {
      if (Input.GetMouseButtonDown(0))
      {
        DoubleClick();
        yield break;
      }

      timeCount += Time.deltaTime;
      yield return null;
    }
    SingleClick();


  }
  private void DoubleClick()
  {
     Attack();
     if (attacking)
    {

      time += Time.deltaTime;
      if (time >= timeToAttack)
      {
        time = 0f;
        attacking = false;
        //  attacking2=true;

        attackArea.SetActive(attacking);
        //  AXe.SetActive(attacking2);
      }
    }
  }
  private void SingleClick()
  {
    Debug.Log("sss");
  }







}
