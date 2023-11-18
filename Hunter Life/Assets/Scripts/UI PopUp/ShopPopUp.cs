using UnityEngine;

public class ShopPopUp : MonoBehaviour
{
    public GameObject miniMap, Setting, inventory;

    public void ShowInventory()
    {
        inventory.SetActive(true);
        Setting.SetActive(false);
        miniMap.SetActive(false);

    }
    public void ShowMiniMap()
    {

        miniMap.SetActive(true);
        Setting.SetActive(false);

    }

    public void ShowSetting()
    {
        miniMap.SetActive(false);
        Setting.SetActive(true);

    }
}
