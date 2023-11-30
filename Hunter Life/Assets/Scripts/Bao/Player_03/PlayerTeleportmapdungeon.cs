using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportmapdungeon : MonoBehaviour
{
    private GameObject currentTeleporter;
    private GameObject transition;


    // public Animator aniTransition;
    public float transitionTime = 1f;

    public GameObject cam;

    private Vector3 Map, map1, map2, map3, map4, map5, map5A, map6, map7, map8, map9, map10, map3A;// =  new Vector3(x, y, -9);
    public GameObject itemman1, itemman2, itemman3, itemman4, itemman5, itemman3A, itemman6, itemman5A, itemman7, itemman8;

    [SerializeField] private GameObject Loader;


    // Start is called before the first frame update
    void Start()
    {
        Map = new Vector3(184.5f, 81.5f, -9f);
        map1 = new Vector3(184.5f, 81.5f, -9f);
        map2 = new Vector3(209f, 81.5f, -9f);
        map3 = new Vector3(233f, 81.5f, -9);
        map3A = new Vector3(258f, 81.5f, -9);
        map4 = new Vector3(233f, 64.36f, -9);
        map5 = new Vector3(233f, 50.5f, -9);
        map5A = new Vector3(232f, 34.5f, -9);
        map6 = new Vector3(260f, 50.5f, -9);
        map7 = new Vector3(288, 50.5f, -9);
        map8 = new Vector3(312, 50.5f, -9);


    }



    // Update is called once per frame
    void Update()


    {




        if (currentTeleporter != null)
        {
            LoadingTransition();
            // Vector3 originPosotion = cam.transform.position;
            changeMap(Map);
            // Debug.Log("VỊ trí x" + x);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            currentTeleporter = collision.gameObject;
            // Lấy layer của đối tượng
            int otherLayer = collision.gameObject.layer;


            // Kiểm tra layer và thực hiện xử lý
            if (otherLayer == LayerMask.NameToLayer("endman1"))
            {
                Map = map2;
                itemman2.SetActive(true);
                itemman1.SetActive(false);

            }
            else if (otherLayer == LayerMask.NameToLayer("startman2"))
            {
                Map = map1;
                itemman2.SetActive(false);
                itemman1.SetActive(true);
            }
            else if (otherLayer == LayerMask.NameToLayer("Endman2"))
            {
                Map = map3;
                itemman3.SetActive(true);
                itemman2.SetActive(false);

            }
            else if (otherLayer == LayerMask.NameToLayer("Startman3"))
            {
                Map = map2;
                itemman3.SetActive(false);
                itemman2.SetActive(true);

            }
            else if (otherLayer == LayerMask.NameToLayer("Endman3"))
            {
                Map = map3A;
                itemman3A.SetActive(true);
                itemman3.SetActive(false);
            }
            else if (otherLayer == LayerMask.NameToLayer("Startman3A"))
            {
                Map = map3;
                itemman3A.SetActive(false);
                itemman3.SetActive(true);
            }
            else if (otherLayer == LayerMask.NameToLayer("Sideman3"))
            {
                Map = map4;
                itemman4.SetActive(true);
                itemman3.SetActive(false);

            }
            else if (otherLayer == LayerMask.NameToLayer("Sideman4.1"))
            {

                Map = map3;
                itemman4.SetActive(false);
                itemman3.SetActive(true);

            }
            else if (otherLayer == LayerMask.NameToLayer("Sideman4.2"))
            {
                Map = map5;
                itemman5.SetActive(true);
                itemman4.SetActive(false);
            }
            else if (otherLayer == LayerMask.NameToLayer("Sideman5.1"))
            {
                Map = map4;
                itemman5.SetActive(false);
                itemman4.SetActive(true);
            }
             else if (otherLayer == LayerMask.NameToLayer("Sideman5.2"))
            {
                Map = map5A;
                itemman5.SetActive(false);
                itemman5A.SetActive(true);
            }
             else if (otherLayer == LayerMask.NameToLayer("Sideman5A"))
            {
                Map = map5;
                itemman5.SetActive(true);
                itemman5A.SetActive(false);
            }
             else if (otherLayer == LayerMask.NameToLayer("Endman5"))
            {
                Map = map6;
                itemman5.SetActive(false);
                itemman6.SetActive(true);
            }
             else if (otherLayer == LayerMask.NameToLayer("Startman6"))
            {
                Map = map5;
                itemman5.SetActive(true);
                itemman6.SetActive(false);
            }
             else if (otherLayer == LayerMask.NameToLayer("Endman6"))
            {
                Map = map7;
                itemman7.SetActive(true);
                itemman6.SetActive(false);
            }
             else if (otherLayer == LayerMask.NameToLayer("Startman7"))
            {
                Map = map6;
                itemman6.SetActive(true);
                itemman7.SetActive(false);
            }
             else if (otherLayer == LayerMask.NameToLayer("Endman7"))
            {
                Map = map8;
                itemman8.SetActive(true);
                itemman7.SetActive(false);
            }
             else if (otherLayer == LayerMask.NameToLayer("Startman8"))
            {
                Map = map7;
                itemman7.SetActive(true);
                itemman8.SetActive(false);
            }

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
    public void changeMap(Vector3 map)
    {
        cam.transform.position = map;
    }


    //Transition Area
    IEnumerator Loading()
    {
        Loader.SetActive(true);
        //play animation
        //  aniTransition.SetTrigger("start");
        //teleport
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        //wait
        yield return new WaitForSeconds(transitionTime);
        Loader.SetActive(false);

    }



}
