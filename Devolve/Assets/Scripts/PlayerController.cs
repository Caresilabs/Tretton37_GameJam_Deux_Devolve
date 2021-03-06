﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Transform[] Parts;

    private Stack<PartController> currentParts;

    private int MaxNumOfParts { get { return Parts.Length; } }

    private bool IsOnlyHead { get { return currentParts.Count == 1; } }

    private PartController head;

    // Use this for initialization
    void Start()
    {
        this.head = Parts[0].GetComponent<PartController>();
        this.currentParts = new Stack<PartController>();
        foreach (var part in Parts)
        {
            currentParts.Push(part.GetComponent<PartController>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnlyHead)
        {
            head.SpriteRenderer.flipX = head.Body.velocity.x < -0.1f;
        }
        else
        {
            var avgPoint = currentParts.Average(x => x.transform.position.x);
            head.SpriteRenderer.flipX = avgPoint > head.transform.position.x;
        }
    }

    public void Split()
    {
        if (!IsOnlyHead)
        {
            PartController part = currentParts.Pop();
            part.Split();
            currentParts.Peek().Joint.enabled = false;
        }
    }

    public bool IsGrounded()
    {
        foreach (var part in currentParts)
        {
            if (part.IsGrounded)
                return true;
        }
        return false;
    }

    internal void Merge(PartController source, PartController toMerge)
    {
        if (source != currentParts.Peek())
            return;

        currentParts.Peek().Merge(toMerge);
        currentParts.Push(toMerge);
    }
}