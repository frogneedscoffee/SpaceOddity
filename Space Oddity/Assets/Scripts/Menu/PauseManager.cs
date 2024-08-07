using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject Btnpause;
    [SerializeField] private GameObject PauseMenu;

    SerialPort puerto;
    public void Start()
    {
        puerto = FindObjectOfType<PlayerMov>().puerto2;

        puerto.ReadTimeout = 40;

        if (puerto.IsOpen)
        {
            puerto.Close();
            Debug.Log("puerto succesfully closed");

            if (!puerto.IsOpen)
            {
                puerto.Open();
            }
        }

        else
        {
            puerto.Open();
        }
    }

    public void PauseBtn()
    {
        Btnpause.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        Btnpause.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void RestartBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   

    public void LevelsBtn(string SceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void ExitBtn()
    {
        Debug.Log("ClosingApp");
        Application.Quit();
    }
}
