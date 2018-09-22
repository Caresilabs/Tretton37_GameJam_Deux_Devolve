using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private float DistanceFromTarget = 6;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, -DistanceFromTarget);
    }



}