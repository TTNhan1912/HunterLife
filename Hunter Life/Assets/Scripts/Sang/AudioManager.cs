using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    // panel nền tối
    public GameObject nightPanel;
    // thời gian tồn tại panel
    private float transitionTime = 180f;
    // đã đến tối hay chưa
    private bool isNight = false;

    // thời gian
    [SerializeField] TextMeshProUGUI timeText;
    float elapsedTime;
    float maxTime = 1440f;

    public Transform rotatingImage;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayDayMusic();
        elapsedTime = 6 * 60;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > maxTime)
        {
            elapsedTime = 0f;
        }

        int m = Mathf.FloorToInt(elapsedTime / 60);
        int s = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", m, s);

        // Hiển thị panel khi đạt 17
        if (m == 17)
        {
            StartCoroutine(FadeInPanel());
        }

        // Ẩn panel khi đạt 4
        if (m == 4)
        {
            StartCoroutine(FadeOutPanel());
        }

        // chạy nhạc buổi tối khi 9h tối
        if (m == 19 && s == 0)
        {
            if (!isNight)
            {
                isNight = true;
                PlayNightMusic();
                rotatingImage.transform.Rotate(new Vector3(0, 0, -100f));
            }
        }

        /*if(m == 12 && s == 0)
        {
            rotatingImage.transform.Rotate(new Vector3(0, 0, -50f));
        }*/

        //chạy nhạc buổi sáng khi 6h sáng
        if(m == 6 && s == 0)
        {
            if (isNight)
            {
                isNight = false;
                PlayDayMusic();
                rotatingImage.transform.Rotate(new Vector3(0, 0, 100f));
            }
        }

        /*if (m == 1 && s == 0)
        {
            rotatingImage.transform.Rotate(new Vector3(0, 0, 50f));
        }*/
    }

    // panel hiện dần
    private IEnumerator FadeInPanel()
    {
        CanvasGroup canvasGroup = nightPanel.GetComponent<CanvasGroup>();
        float elapsedTime = 0f;

        while (elapsedTime < transitionTime)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    // panel tắt dần
    private IEnumerator FadeOutPanel()
    {
        CanvasGroup canvasGroup = nightPanel.GetComponent<CanvasGroup>();
        float elapsedTime = 0f;

        while (elapsedTime < transitionTime)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    // chạy nhạc buổi tối
    private void PlayNightMusic()
    {
       PlayMusic("Night");
    }

    // chạy nhạc buổi sáng
    private void PlayDayMusic()
    {
       PlayMusic("Farm");
    }

    // nhạc nền
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("không có sound");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    // Tiếng game
    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("không có sound");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    // bấm nút tắt nhạc nền
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    // bấm nút tắt âm thanh
    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
