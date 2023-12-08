using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManManager : MonoBehaviour
{
    public GameObject[] man = new GameObject[8];
    private int CurrentMappp = 0;
    public string key_Man = "man_save";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < man.Length; i++)
        {
            if (man[i] == null)
            {
              Save(i);


            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {

            Load();


        }
        if (Input.GetKeyDown(KeyCode.K))
         {

            PlayerPrefs.SetInt(key_Man, -1);
               PlayerPrefs.SetInt("ChestMan_1", 1);
                PlayerPrefs.SetInt("ChestMan_4", 1);
                  PlayerPrefs.SetInt("ChestMan_2", 1);
                    PlayerPrefs.SetInt("ChestMan_3", 1);
            

         }

    }
    public void Save(int currentMap)
    {

        int q = PlayerPrefs.GetInt(key_Man, 0);
        if (q < currentMap)
        {
            PlayerPrefs.SetInt(key_Man, currentMap);
            PlayerPrefs.Save();
            CurrentMappp = currentMap;
        }
        PlayerPrefs.SetInt(key_Man, currentMap);




    }
    public void Load()
    {
        int s = PlayerPrefs.GetInt(key_Man, 0);
        Debug.Log("///" + s);


    }
}
