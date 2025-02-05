using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] Rigidbody characterRB;
    [SerializeField] float jumpVelocity = 200;
    [SerializeField] float isGroundedDistance = 0.7f;
    [SerializeField] bool debugMode = false;
    public bool IsGrounded { get; private set; } = true;

    void Start()
    {

    }

    void Update()
    {
        //Debug.Log(IsGrounded);
        if (debugMode)
        {
            Debug.DrawRay(transform.position, Vector3.down, Color.white, isGroundedDistance);
        }

        if (!IsGrounded)
        {
            CheckIsGrounded();
        }
    }

    private void OnJump(InputValue inputValue)
    {
        if (Physics.Raycast(transform.position, Vector3.down, isGroundedDistance))
        {
            characterRB.AddForce(Vector3.up * jumpVelocity);
            IsGrounded = false;
            Debug.Log(IsGrounded);

        }
    }

    private void CheckIsGrounded()
    {
        //check does not work, as soon as player jumps, this if statement is triggered and sets IsGrounded back to true
        if (Physics.Raycast(transform.position, Vector3.down, isGroundedDistance))
        {
            IsGrounded = true;
        }
    }
}
