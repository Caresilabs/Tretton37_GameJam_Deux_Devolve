using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    private float Speed;


    [SerializeField]
    private Text appleCounter;

    private int appleCount = 0;

   // private PlayerController controller;

    // Use this for initialization
    void Start () {
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        Instance = this;

        appleCount = PlayerPrefs.GetInt("Apples", 0);

        appleCounter.text = appleCount.ToString();
    }

    internal void PickUpApple()
    {
        appleCount++;
        appleCounter.text = appleCount.ToString();
    }

    internal void NextLevel()
    {
        PlayerPrefs.SetInt("Apples", appleCount);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
