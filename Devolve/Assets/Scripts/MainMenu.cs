using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("Level00");
    }


    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }


}