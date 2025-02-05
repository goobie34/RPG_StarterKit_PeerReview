using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TextMeshProUGUI masterVolTxt;
    [SerializeField] TextMeshProUGUI sfxVolTxt;
    [SerializeField] TextMeshProUGUI ambienceVolTxt;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume)
    {
        int volumeToInt = (int)Mathf.Clamp(volume * 10, 0, 20);
        masterVolTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        int volumeToInt = (int)Mathf.Clamp(volume * 10, 0, 20);
        sfxVolTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    public void SetAmbienceVolume(float volume)
    {
        int volumeToInt = (int)Mathf.Clamp(volume * 10, 0, 20);
        ambienceVolTxt.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);
    }

}
