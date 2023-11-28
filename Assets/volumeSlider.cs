using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class volumeSlider : MonoBehaviour
{
    [SerializeField] Slider vol;

    void Start()
    {

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        LoadVolume();
    }

    public void ChangeVolume()
    {

        AudioListener.volume = vol.value;

        AudioSource[] sources = FindObjectsOfType<AudioSource>();

        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].volume = vol.value;
        }

        SaveVolume();

    }

    private void LoadVolume()
    {

        vol.value = PlayerPrefs.GetFloat("musicVolume");

    }

    private void SaveVolume()
    {

        PlayerPrefs.SetFloat("musicVolume", vol.value);

    }
}
