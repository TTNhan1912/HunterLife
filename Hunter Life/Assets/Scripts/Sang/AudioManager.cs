using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    // panel nền tối
    public GameObject nightPanel;
    // thời gian tồn tại panel
    private float transitionTime = 10f;

    private bool isNight = false;


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
        // ngày đêm
        StartCoroutine(StartDayNightCycle());

        PlayDayMusic();
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

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

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


    private IEnumerator StartDayNightCycle()
    {
        yield return new WaitForSeconds(5f);
        CanvasGroup canvasGroup = nightPanel.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;

        while (true)
        {
            float elapsedTime = 0f;

            while (elapsedTime < transitionTime)
            {
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / transitionTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            isNight = true; // Đã chuyển sang trời tối
            PlayNightMusic(); // Phát nhạc buổi tối

            yield return new WaitForSeconds(transitionTime);

            elapsedTime = 0f;

            while (elapsedTime < transitionTime)
            {
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            isNight = false; // Đã chuyển sang trời sáng
            PlayDayMusic(); // Phát lại nhạc ban đầu

            yield return new WaitForSeconds(transitionTime);
        }
    }

    private void PlayNightMusic()
    {
       PlayMusic("Night");
    }

    private void PlayDayMusic()
    {
       PlayMusic("Farm");
    }

}
