using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float DistanceFromTarget = 6;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
       // transform.position = new Vector3(Target.position.x, Target.position.y, -DistanceFromTarget);

        var newParallaxPos = transform.GetChild(1).transform.localPosition;
        newParallaxPos.x = -transform.localPosition.x * 0.05f;
        transform.GetChild(1).transform.localPosition = newParallaxPos;
    }



}