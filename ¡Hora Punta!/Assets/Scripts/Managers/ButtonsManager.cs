using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionsPanel;

    public AudioManager audioManager;

    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void OpenOptions(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);

        panel.SetActive(true);
        audioManager.PlaySoundButton(); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
