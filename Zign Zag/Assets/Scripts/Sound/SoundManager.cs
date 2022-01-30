using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    
    public Sprite onvoice, offvoice;
    public AudioSource audioSource;
    public AudioClip movementClip,collectClip;
    public Button soundButton;

    bool _muted = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        else
        {
            LoadSettings();
        }
        UpdateIcon();
        AudioListener.pause = _muted;
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    private void UpdateIcon()
    {
        if (_muted == false)
        {
            soundButton.GetComponent<Image>().sprite = onvoice;
            
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = offvoice;
        }
    }

    public void AudioController()
    {
        if (_muted == false)
        {
            _muted = true;
            AudioListener.pause = true;
        }
        else
        {
            _muted = false;
            AudioListener.pause = false;
        }
        SaveSettings();
        UpdateIcon();
    }
    private void LoadSettings()
    {
        _muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void SaveSettings()
    {
        PlayerPrefs.SetInt("muted", _muted ? 1 : 0);
    }
}
