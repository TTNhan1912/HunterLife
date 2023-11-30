using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImageFromURL : MonoBehaviour
{
    public string imageURL = "";
    public RawImage image;
    public static LoadImageFromURL instance;
    void Start()
    {
        imageURL = "https://firebasestorage.googleapis.com/v0/b/hunterlief-459aa.appspot.com/o/items%2F1701271749728-893168130%5B1920%20x%201080%5D%20Fly%20High.jfif?alt=media&token=4d9a4d2b-3737-403d-94da-e905403a2062";
        StartCoroutine(LoadImage(imageURL, image));
    }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    /*public void LoadImageURL(string image, RawImage images)
    {
        StartCoroutine(LoadImage(image, images));
    }*/

    IEnumerator LoadImage(string uri, RawImage image)
    {
        Debug.Log(">>>>>>" + uri);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError($"Error downloading image: {www.error}");
        }
        else
        {
            // Lấy texture từ response
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Gán texture cho đối tượng RawImage hoặc Image
            if (image != null)
            {
                image.texture = texture;
            }
        }
    }
}