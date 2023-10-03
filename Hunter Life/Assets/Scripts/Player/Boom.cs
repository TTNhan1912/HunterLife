using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("BoomNo", 1f);
    }


    private void BoomNo()
    {
        ani.SetBool("IsBoomNo", true);
        Destroy(gameObject, 0.5f);
    }


}
