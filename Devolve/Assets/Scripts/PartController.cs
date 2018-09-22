using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    [SerializeField]
    public DistanceJoint2D Joint;

    [SerializeField]
    public SpriteRenderer SpriteRenderer;

    [SerializeField]
    private bool ShouldFlip = false;

    [SerializeField]
    private Rigidbody2D Body;

    [SerializeField] private LayerMask m_WhatIsGround;

    private const float k_GroundedRadius = .2f;

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.

    // Use this for initialization
    void Start()
    {
        m_GroundCheck = transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      //  if (ShouldFlip)
       //     SpriteRenderer.flipX = Body.velocity.x < -.5f;

        IsGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                IsGrounded = true;
        }
    }



}