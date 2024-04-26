using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionsPanel;

    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void OpenOptions(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
