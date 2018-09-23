using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var apples = GameObject.Find("apples");
        if (apples != null)
        {
            apples.SetActive(true);
            var text = apples.GetComponent<Text>();
            text.enabled = true;
            text.text = string.Format(text.text, PlayerPrefs.GetInt("Apples", 0));
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    public void StartGame()
    {
        PlayerPrefs.SetInt("Apples", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level00");
    }


    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }


}