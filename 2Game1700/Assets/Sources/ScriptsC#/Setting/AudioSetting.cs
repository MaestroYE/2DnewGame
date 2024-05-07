using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private string _NameSetting = "Music";
    private static float _musicVolume;

    private void Start()
    {
        LoadSetting();
    }

    public void SetVolumeMusic(float volume)
    {
        _musicVolume = volume;
        audioMixer.SetFloat(_NameSetting, volume);
    }

    private void LoadSetting()
    {
        musicVolumeSlider.value = _musicVolume;
        audioMixer.SetFloat(_NameSetting, _musicVolume);
    }
}
