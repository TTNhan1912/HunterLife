using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject Door, TreasureChestOpen, TreasureChestClose, TreasureChestIT;
    public PlayerLife playerLife;
    public GameObject open;
    public int numKey;
    public GameObject Key;
    public int numLifePot;
    public GameObject LifePot;
    bool Opench = true;
    int B =1;
    [SerializeField] private Transform viTri;
    [SerializeField] private Transform viTriKey;
    [SerializeField] private Transform viTriLifePot;
    public string key_Chest = "ChestMan_1";
    // Start is called before the first frame update
    void Start()
    {
         B = PlayerPrefs.GetInt(key_Chest, 1);
        if (B==1)
        {
            return;
        }
        else
        {
            Opench = false;
            TreasureChestOpen.SetActive(true);
            TreasureChestClose.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Opench && Door == null && playerLife.Key > 0 && collision.gameObject.CompareTag("player"))
        {

            Open();

        }
    }
    public void Open()
    {

        Opench = false;
        
        PlayerPrefs.SetInt(key_Chest, 0);
        playerLife.TongKey(-1);
        TreasureChestOpen.SetActive(true);
        TreasureChestClose.SetActive(false);
        GameObject Open2 = Instantiate(open, viTri.position, viTri.rotation);
        for (int i = 0; i < numKey; i++)
        {

            viTriKey.position += new Vector3(0, -i * 0.6f, 0);
            GameObject Key2 = Instantiate(Key, viTriKey.position, viTriKey.rotation);
        }
        for (int i = 0; i < numLifePot; i++)
        {
            viTriLifePot.position += new Vector3(0, -i * 0.6f, 0);
            GameObject LifePot2 = Instantiate(LifePot, viTriLifePot.position, viTriLifePot.rotation);
        }
        Debug.Log("///");



    }
}
