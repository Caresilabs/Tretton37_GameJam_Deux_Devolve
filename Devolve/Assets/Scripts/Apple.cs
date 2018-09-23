using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    float offset;

    private void Start()
    {
        offset = Random.Range(0f, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.Instance.PickUpApple();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position += new Vector3(0,Mathf.Sin(Time.realtimeSinceStartup*5 + offset) * 0.005f,0);
    }

}