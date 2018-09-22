using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    [SerializeField]
    public Joint2D Joint;

    [SerializeField]
    public SpriteRenderer SpriteRenderer;

    [SerializeField]
    private bool ShouldFlip = false;

    [SerializeField]
    public Rigidbody2D Body;

    [SerializeField] private LayerMask m_WhatIsGround;

    private const float k_GroundedRadius = .2f;

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.

    private bool isSeperated = false;
    private float splitDelay = 0;

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
        splitDelay += Time.fixedDeltaTime;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                IsGrounded = true;
        }
    }

    public void Split()
    {
        splitDelay = 0;
        Joint.enabled = false;
        isSeperated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSeperated && splitDelay > 0.5f && collision.transform.CompareTag("Player") && !collision.transform.Equals(this))
        {
            GameObject.FindObjectOfType<PlayerController>().Merge(collision.transform.GetComponent<PartController>(), this);
        }
    }

    internal void Merge(PartController part)
    {
        isSeperated = false;
        Joint.enabled = true;
        Joint.connectedBody = part.Body;
    }
}