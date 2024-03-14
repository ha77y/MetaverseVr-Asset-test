using System;
using Cinemachine;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas pauseCanvas;
    public Canvas winCanvas;
    public CinemachineVirtualCamera startCamera;

    private PlayerInputMap _input;

    private void Awake()
    {
        startCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(false);
        _input = new PlayerInputMap();
    }

    public void StartButtonPress()
    {
        startCanvas.gameObject.SetActive(false);
        startCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Win()
    {
        winCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
       // if () ;
    }
}
