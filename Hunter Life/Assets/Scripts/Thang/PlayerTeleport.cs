using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter; 
    private GameObject transition;

    public Animator aniTransition;
    public float transitionTime = 1f;

    [SerializeField] private GameObject Loader;
    //[SerializeField] private GameObject Farm;
    //[SerializeField] private GameObject Road;
    //[SerializeField] private GameObject Town;
    //[SerializeField] private GameObject Dungeon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (currentTeleporter != null)
            {
                LoadingTransition();       
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            currentTeleporter = collision.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            currentTeleporter = null;
        }
    }

    public void LoadingTransition()
    {
        StartCoroutine(Loading());
    }

    //Transition Area
    IEnumerator Loading()
    {
        Loader.SetActive(true);
        //play animation
        aniTransition.SetTrigger("start");
        //teleport
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        //wait
        yield return new WaitForSeconds(transitionTime);
        Loader.SetActive(false);

    }

}
