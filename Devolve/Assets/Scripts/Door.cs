using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private int Required = 1;

    private int current;

    private Vector3 target;

    private void Start()
    {
        target = transform.position;
    }

    public void Open()
    {
        current++;
        if (current >= Required)
        {

        }
    }

    private void Update()
    {
        if (current >= Required)
        {
            transform.position = Vector3.MoveTowards(transform.position, target + Vector3.down, 0.1f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        }
    }

    public void Close()
    {
        current--;
    }

}