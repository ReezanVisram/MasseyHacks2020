using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public GameObject quitPanel;

    void Update() {
        if (Input.GetKeyDown("escape")) {
            OpenQuitPanel();
        }
    }

    public void OpenQuitPanel() {
        quitPanel.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void CloseQuitPanel() {
        quitPanel.SetActive(false);
    }
}
