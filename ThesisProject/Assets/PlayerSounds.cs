using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;

    [SerializeField] PlayerJump playerJump;
    bool isWalking = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking && !audioSource.isPlaying)
        {
            audioSource.clip = SoundBank.SoundBankInstance.stepAudio;
            audioSource.Play();
        } else if (!isWalking && audioSource.isPlaying) {
            audioSource.Stop();
        } else if(isWalking && !playerJump.IsGrounded)
        {
            audioSource.Stop();
        }
    }

    private void OnMovement(InputValue input)
    {
        // Getting movement input values (x and y axes)
        isWalking = true;
    }
    private void OnMovementStop(InputValue input)
    {
        isWalking = false;
    }
}
