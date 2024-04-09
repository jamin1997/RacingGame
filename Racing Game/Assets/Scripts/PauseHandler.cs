using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public GameObject PauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
    }
}
