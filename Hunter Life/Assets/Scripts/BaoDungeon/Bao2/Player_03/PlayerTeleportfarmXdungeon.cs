using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportfarmXdungeon : MonoBehaviour
{
    private GameObject currentTeleporter;

    [Header("player")]
    public GameObject PlayerDungeon;
    public GameObject PlayerFarm;
    [Header("Canvan")]
    public GameObject CanvanDungeon;
    public GameObject Canvan;
    [Header("Camera")]
    public GameObject CameraDungeon;
    public GameObject Camera;

   
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
        if (currentTeleporter != null)
        {
            LoadingTransition();
            // Vector3 originPosotion = cam.transform.position;

        }



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            currentTeleporter = null;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            int otherLayer = collision.gameObject.layer;

            if (otherLayer == LayerMask.NameToLayer("EnterDungeon"))
            {

                // itemman1.SetActive(false);
                Canvan.SetActive(false);
                Camera.SetActive(false);
                PlayerFarm.SetActive(false);
                CanvanDungeon.SetActive(true);
                CameraDungeon.SetActive(true);
                PlayerDungeon.SetActive(true);


                //thay mini map

            }
            else if (otherLayer == LayerMask.NameToLayer("OutDungeon"))
            {

                // itemman1.SetActive(false);
                CanvanDungeon.SetActive(false);
                CameraDungeon.SetActive(false);
                PlayerDungeon.SetActive(false);
                Canvan.SetActive(true);
                Camera.SetActive(true);
                PlayerFarm.SetActive(true);

                //thay mini map

            }
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
        
        //teleport

        //wait
        yield return new WaitForSeconds(transitionTime);
        Loader.SetActive(false);

    }

}
