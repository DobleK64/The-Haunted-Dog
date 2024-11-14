using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pentagrams;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            pentagrams.SetActive(false);
        }
    }
}
