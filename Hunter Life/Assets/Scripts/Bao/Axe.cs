using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private bool attacking = false;
    private float timeToAttack = 0.4f;
     private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { 
       Attack();
        
            
        }else if (attacking)
        {

            time += Time.deltaTime;
            if(time>= timeToAttack)
            {
                time = 0f;
                attacking= false;
              //  attacking2=true;

              
               //  AXe.SetActive(attacking2);
            }
        }


    }
    public IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
       
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        float totalTime = 0f;

        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(toAngle, fromAngle, t);
            yield return null;
        }
        //  transform.rotation = Quaternion.Slerp(toAngle, fromAngle, 0.15f);
    }
     private void Attack()
    {
        /*ani.Play("Char_Attack_LR");*/

        attacking = true;
     //   attacking2 = false;

         StartCoroutine(RotateMe(-Vector3.back * 90, 0.2f));
      //  AXe.SetActive(attacking2);
              
        ;
      
        
    }
}
