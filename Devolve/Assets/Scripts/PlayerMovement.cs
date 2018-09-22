using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D HeadPart;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private float MaxVelocityChange = 50.0f;

    [SerializeField]
    private float MaxVelocity = 100.0f;

    [SerializeField]
    private PlayerController Controller;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // HeadPart.AddForce(new Vector2(10, 0));
        CheckSplit();
    }


    private void CheckSplit()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Controller.Split();
        }
    }

    void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        Vector2 velocity = HeadPart.velocity;

        Vector2 targetVelocity = new Vector3(Input.GetAxis(("Horizontal")), Input.GetAxis(("Vertical")));
        //Vector3 targetVelocity = new Vector3(controller.Input.GetAxis(Assets.Scripts.InputLayout.ActionType.MOVE_RIGHT), 0, controller.Input.GetAxis(Assets.Scripts.InputLayout.ActionType.MOVE_FORWARD));
        if (targetVelocity.magnitude >= 1)
            targetVelocity.Normalize();

        targetVelocity *= Speed;

        if (!Controller.IsGrounded())
        {
            targetVelocity.y = 0;
        }

        // Apply a force that attempts to reach our target velocity
        Vector2 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -MaxVelocityChange, MaxVelocityChange);
        velocityChange.y = Mathf.Clamp(velocityChange.y, -MaxVelocityChange, MaxVelocityChange);
        HeadPart.AddForce(velocityChange, ForceMode2D.Force);

        if (Math.Abs(HeadPart.velocity.x) > MaxVelocity)
        {
            HeadPart.velocity = new Vector2(Math.Sign(HeadPart.velocity.x) * MaxVelocity, HeadPart.velocity.y);
        }

        // Animator.SetFloat("Speed", Mathf.Min((velocity.magnitude / Speed) + 1, 2));
    }

}

