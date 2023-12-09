using System.Collections;
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
    public Camera CameraDungeonCanvas;
    public GameObject Camera;

    private Item itemAPI;

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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentTeleporter != null)
            {
                LoadingTransition();
                // Vector3 originPosotion = cam.transform.position;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter"))
        {
            int otherLayer = collision.gameObject.layer;

            if (otherLayer == LayerMask.NameToLayer("EnterDungeon"))
            {


                Canvan.SetActive(false);
                Camera.SetActive(false);

                //  Canvas canvas = GetComponent<Canvas>();
                //  canvas.worldCamera = CameraDungeonCanvas;

                transform.position += new Vector3(0, -2, 0);
                PlayerFarm.SetActive(false);
                CanvanDungeon.SetActive(true);
                CameraDungeon.SetActive(true);
                PlayerDungeon.SetActive(true);

                CreateScripts.createScriptsIntance.CreateMyScriptableObject();
                //thay mini map

            }
            else if (otherLayer == LayerMask.NameToLayer("OutDungeon"))
            {


                CanvanDungeon.SetActive(false);
                CameraDungeon.SetActive(false);
                transform.position += new Vector3(0, 2, 0);
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
