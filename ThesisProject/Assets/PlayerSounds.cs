using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] AudioSource footstepAudioSource;
    [SerializeField] AudioSource idleSoundsAudioSource;

    [SerializeField] PlayerJump playerJump;
    bool isWalking = false;

    bool idle;
    private float idleTimer;
    [SerializeField] private float idleTimeThreshold = 5;


    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        idleTimer = 0.0f;
        idle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalking)
        {
            idleTimer += Time.deltaTime;
        } else
        {
            idleTimer = 0.0f;
            idle = false;
        }

        if (idleTimer >= idleTimeThreshold)
        {
            idle = true;
        }

        //TODO: separate hum audioSource from footstep audioSource
        if (isWalking && !footstepAudioSource.isPlaying)
        {
            footstepAudioSource.clip = SoundBank.SoundBankInstance.stepAudio;
            footstepAudioSource.Play();
        }
        else if (!isWalking && footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Stop();
        }
        else if (isWalking && !playerJump.IsGrounded)
        {
            footstepAudioSource.Stop();
        }

    }

    private void OnMovement(InputValue input)
    {
        // Getting movement input values (x and y axes)
        isWalking = true;
        idle = false;
        idleTimer = 0f;
        Debug.Log("oN MOVEMENT");
    }
    private void OnMovementStop(InputValue input)
    {
        isWalking = false;
    }

    private void OnJump(InputValue input)
    {
        idle = false;
        idleTimer = 0f;
    }

    private void FixedUpdate()
    {
        if (idle && !idleSoundsAudioSource.isPlaying)
        {
            int amountOfSounds = SoundBank.SoundBankInstance.idleSounds.Length;
            idleSoundsAudioSource.clip = SoundBank.SoundBankInstance.idleSounds[Random.Range(0, amountOfSounds)];
            idleSoundsAudioSource.Play();
            idle = false;
            idleTimer = 0f;
        }
        else if (isWalking && idleSoundsAudioSource.isPlaying)
        {
            idleSoundsAudioSource.Stop();
            Debug.Log("I AM TRYING TO STOP THE AUDIO SOURCE");
        }
    }
}
