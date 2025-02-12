using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public static SoundBank SoundBankInstance { get; private set; }
    public AudioClip stepAudio;
    public AudioClip[] idleSounds;

    
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (SoundBankInstance != null && SoundBankInstance != this)
        {
            Destroy(this);
        }
        else
        {
            SoundBankInstance = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
