using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    [SerializeField]
    GameObject PauseUI;
    private bool Paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Paused = !Paused;
        }

        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;

        }

        if (!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

    public void Reprendre()
    {
        Paused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Paused = false;
    }

    public void Quitter()
    {
        Application.Quit();
    }
}



