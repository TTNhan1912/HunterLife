using TMPro;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public TMP_Text coint;
    MissionController missionController;
    private float valueMission = 0f;
    private int valueSave = 0;
    public static float valueAll = 0f;
    // Start is called before the first frame update
    void Start()
    {
        missionController = FindObjectOfType<MissionController>();

    }

    // Update is called once per frame
    void Update()
    {
        valueMission = missionController.GetCoins();
        SavePositionCoin.coinn = valueSave;
        valueAll = valueMission + valueSave;

        coint.text = valueAll + "";
    }
}
