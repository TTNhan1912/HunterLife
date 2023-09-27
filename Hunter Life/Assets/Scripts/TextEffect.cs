using UnityEngine;
using TMPro;

public class TextEffect : MonoBehaviour
{
    public TMP_Text textComponent;
    public string fullText;
    public float delayBetweenCharacters = 0.1f;

    private string currentText;
    private float timer;

    private void Start()
    {
        currentText = "";
        timer = 0f;
    }

    private void Update()
    {
        if (currentText.Length < fullText.Length)
        {
            timer += Time.deltaTime;

            if (timer >= delayBetweenCharacters)
            {
                currentText += fullText[currentText.Length];
                textComponent.text = currentText;
                timer = 0f;
            }
        }
    }
}