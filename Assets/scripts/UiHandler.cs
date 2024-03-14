using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas pauseCanvas;
    public Canvas winCanvas;
    public CinemachineVirtualCamera startCamera;

    

    private void Awake()
    {
        startCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(false);
       
    }

    public void StartButtonPress()
    {
        startCanvas.gameObject.SetActive(false);
        startCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        Player.paused = true;
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        Player.paused = false;
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Win()
    {
        startCamera.gameObject.SetActive(true);
        winCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}
