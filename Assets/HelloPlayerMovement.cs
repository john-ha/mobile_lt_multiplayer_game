using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class HelloPlayerMovement : SimulationBehaviour
{
    private CharacterController _controller;
    public float JumpForce = 5f;
    public float GravityValue = -9.81f;

    private Vector3 velocity;
    private bool _jumpPressed;

    public float PlayerSpeed = 2f;

    public void ResetAll()
    {
        velocity = Vector3.zero;
        _jumpPressed = false;
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpPressed = true;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }

        if (_controller.isGrounded)
        {
            velocity = new Vector3(0, -1, 0);
        }

        velocity.y += GravityValue * Runner.DeltaTime;
        if (_jumpPressed && _controller.isGrounded)
        {
            velocity.y += JumpForce;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Runner.DeltaTime * PlayerSpeed;
        _controller.Move(move + velocity * Runner.DeltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        _jumpPressed = false;
    }
}
